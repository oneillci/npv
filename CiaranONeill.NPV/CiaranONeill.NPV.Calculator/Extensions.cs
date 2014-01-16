using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiaranONeill.NPV.Calculator
{
    public static class Extensions
    {
        public static int DaysInYear(this DateTime date)
        {
            int days = 0;
            for (int i = 1; i <= 12; i++)
            {
                days += DateTime.DaysInMonth(date.Year, i);
            }
            return days;
        }
    }
}
