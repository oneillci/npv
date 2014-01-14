using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace CiaranONeill.NPV.Silverlight.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NpvService
    {
        [OperationContract]
        public string DoWork()
        {
            return "Hello from WCF";
        }

        [OperationContract]
        public Customer[] GetCustomers(Customer customer)
        {
            return new[]
            {
                new Customer { Id = 1, Name = "Ciaran" },
                new Customer { Id = 2, Name = "Stevie G" }
            };
        }
    }
}
