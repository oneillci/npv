using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CiaranONeill.NPV.Calculator;

namespace CiaranONeill.NPV.Silverlight.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NpvService
    {
        private readonly INpvCalculator _npvCalculator;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="calculator"></param>
        public NpvService(INpvCalculator calculator)
        {
            // Would be nice to get Autofac to inject a simple / complex calculator - how to do via WCF?
            _npvCalculator = calculator;
        }

        [OperationContract]
        public string DoWork()
        {
            return "Hello from WCF";
        }

        [OperationContract]
        public IEnumerable<double> GetRandomData()
        {
            return _npvCalculator.GetRandomData();
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
