using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CiaranONeill.NPV.Silverlight
{
    /// <summary>
    /// Helper class to simplify the calling of services and returning Tasks
    /// </summary>
    /// <typeparam name="TServiceClient">The ServiceClient - a concrete WCF service client (generated from Add Service Reference...)</typeparam>
    /// <typeparam name="TResult">The type of result that is expected from GetTask</typeparam>
    public class TaskHelper<TServiceClient, TResult>
    {
        // TODO: how to constrain TServiceClient?
        private readonly TServiceClient _serviceClient;

        // Stores the TaskCompletionSource. Results in a build error if this is strongly typed to TaskCompletionSource...
        //private object o;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="serviceClient"></param>
        public TaskHelper(TServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        /// <summary> 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="parameter"></param>
        /// <param name="methodName">
        /// The method to call on the service will be based on convention
        /// i.e. if the service method is GetRandomData, the calling method should be GetRandomData
        /// The method names GetRandomDataAsync and GetRandomDataCompleted will then be inferred
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Not sure if doing this way is a good idea but lets try it out
        /// </remarks>
        public Task<TResult> GetTask<TResult>(object[] parameters, [CallerMemberName]string methodName = null)
        {
            var tcs = new TaskCompletionSource<TResult>();

            var t = typeof(TServiceClient);
            //var method = t.GetMethod(methodName + "Async", new Type[]{});
            var methods = t.GetMethods();
            var length = parameters != null ? parameters.Length : 0;
            var asyncMethod = methods.First(x => x.Name == methodName + "Async" && x.GetParameters().Count() == length);

            // Set up an event handler for the Completed event
            var completedEvent = t.GetEvent(methodName + "Completed");

            var eventParams = completedEvent.EventHandlerType.GetMethod("Invoke").GetParameters().Select(p => Expression.Parameter(p.ParameterType, "p")).ToArray();
            Action<object, EventArgs> completedAction = (s, e) =>
            {
                // Get properties via reflection
                //var properties = e.GetType().GetProperties();
                //var error = properties.First(x => x.Name == "Error").GetValue(e, null) as Exception;
                //var cancelled = (bool)properties.First(x => x.Name == "Cancelled").GetValue(e, null);
                //var result = properties.First(x => x.Name == "Result").GetValue(e, null);
                
                dynamic d = (dynamic)e;

                // Standard TCS now...
                if (d.Error != null)
                    tcs.TrySetException(d.Error);
                else if (d.Cancelled)
                    tcs.TrySetCanceled();
                else
                    tcs.TrySetResult((TResult)d.Result);
            };
            // http://stackoverflow.com/questions/3772005/how-to-dynamically-subscribe-to-an-event
            var exp = Expression.Call(Expression.Constant(completedAction), completedAction.GetType().GetMethod("Invoke"), eventParams);
            var l = Expression.Lambda(exp, eventParams);
            var handler = Delegate.CreateDelegate(completedEvent.EventHandlerType, l.Compile(), "Invoke", false);
            completedEvent.AddEventHandler(_serviceClient, handler);
            //var handler = Delegate.CreateDelegate(completedEvent.EventHandlerType, this, typeof(TaskHelper<TResult>).GetMethod("AsyncCompletedHandler"));
            //completedEvent.AddEventHandler(_serviceClient, handler);

            // Invoke the Async method
            asyncMethod.Invoke(_serviceClient, parameters);

            // Promoting TCS to a private field results in build error. Why? Store in object temporarily
            //o = tcs;

            return tcs.Task;
        }

        /// <summary>
        /// Handler that will be invoked once the async call is completed. Calls TaskCompletionSource.TrySetResult in order to complete the Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void AsyncCompletedHandler(object sender, EventArgs e)
        //{
        //    // Promoting TCS to a private field results in build error, so cast o back to it now
        //    var tcs = (TaskCompletionSource<TResult>)o;

        //    // Get properties via reflection
        //    var properties = e.GetType().GetProperties();
        //    var error = properties.First(x => x.Name == "Error").GetValue(e, null) as Exception;
        //    var cancelled = (bool)properties.First(x => x.Name == "Cancelled").GetValue(e, null);
        //    var result = properties.First(x => x.Name == "Result").GetValue(e, null);

        //    // Standard TCS now...
        //    if (error != null)
        //        tcs.TrySetException(error);
        //    else if (cancelled)
        //        tcs.TrySetCanceled();
        //    else
        //        tcs.TrySetResult((TResult)result);
        //}
    }
}