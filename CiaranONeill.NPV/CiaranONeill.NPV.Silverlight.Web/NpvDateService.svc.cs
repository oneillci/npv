using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using CiaranONeill.NPV.Calculator;

namespace CiaranONeill.NPV.Silverlight.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NpvDateService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NpvDateService.svc or NpvDateService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NpvDateService
    {
        private readonly IDateRollCalculator _dateRollCalculator;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="dateRollCalculator"></param>
        public NpvDateService(IDateRollCalculator dateRollCalculator)
        {
            _dateRollCalculator = dateRollCalculator;
        }

        [OperationContract]
        public IEnumerable<DateTime> GetDates(RolloverType period)
        {
            return _dateRollCalculator.GetDates(period);
        }
    }
}
