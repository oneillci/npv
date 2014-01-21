using System;
using System.Collections.Generic;
using System.Linq;

namespace CiaranONeill.NPV.Calculator
{
    public class NpvRequest
    {
        public double InitialInvestment { get; set; }
        public IList<Cashflow> Cashflows { get; set; }
        public RolloverType RollType { get; set; }
        public double LowerRate { get; set; }
        public double UpperRate { get; set; }
        public double Increment { get; set; }
    }
}
