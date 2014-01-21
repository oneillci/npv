using System.Collections.Generic;

namespace CiaranONeill.NPV.Calculator
{
    public class NpvResponse
    {
        public IList<Npv> NetPresentValues { get; set; }

        public NpvResponse()
        {
            NetPresentValues = new List<Npv>();
        }
    }
}