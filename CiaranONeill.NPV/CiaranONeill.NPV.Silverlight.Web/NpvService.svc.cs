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
        public IEnumerable<double> GetRandomData(bool loadKnownValues)
        {
            return _npvCalculator.GetRandomData(loadKnownValues);
        }

        [OperationContract]
        public double CalculateNpv(IList<Cashflow> npvData, double rate, RolloverType rolloverType, bool useXnpvFormula)
        {
            return _npvCalculator.CalculateNpv(npvData, rate, rolloverType, useXnpvFormula);
        }

        [OperationContract]
        public double CalculateNpvForNpvRequest(NpvRequest request, bool useXnpvFormula)
        {
            return _npvCalculator.CalculateNpvForNpvRequest(request, useXnpvFormula);
        }
    }        
}
