using System;
using System.Linq;
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
        private object o;

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
        public Task<TResult> GetTask<TResult>(object parameter, [CallerMemberName]string methodName = null)
        {
            var tcs = new TaskCompletionSource<TResult>();

            var t = typeof(TServiceClient);
            //var method = t.GetMethod(methodName + "Async", new Type[]{});
            var methods = t.GetMethods();
            var asyncMethod = methods.First(x => x.Name == methodName + "Async" && x.GetParameters().Count() == 0);

            // Set up an event handler for the Completed event
            var eventInfo = t.GetEvent(methodName + "Completed");
            var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, typeof(TaskHelper<TServiceClient, TResult>).GetMethod("AsyncCompletedHandler"));
            eventInfo.AddEventHandler(_serviceClient, handler);

            // Invoke the Async method
            asyncMethod.Invoke(_serviceClient, null);

            // Promoting TCS to a private field results in build error. Why? Store in object temporarily
            o = tcs;

            return tcs.Task;
        }

        /// <summary>
        /// Handler that will be invoked once the async call is completed. Calls TaskCompletionSource.TrySetResult in order to complete the Task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AsyncCompletedHandler(object sender, EventArgs e)
        {
            // Promoting TCS to a private field results in build error, so cast o back to it now
            var tcs = (TaskCompletionSource<TResult>)o;

            // Get properties via reflection
            var properties = e.GetType().GetProperties();
            var error = properties.First(x => x.Name == "Error").GetValue(e, null) as Exception;
            var cancelled = (bool)properties.First(x => x.Name == "Cancelled").GetValue(e, null);
            var result = properties.First(x => x.Name == "Result").GetValue(e, null);

            // Standard TCS now...
            if (error != null)
                tcs.TrySetException(error);
            else if (cancelled)
                tcs.TrySetCanceled();
            else
                tcs.TrySetResult((TResult)result);
        }
    }
}