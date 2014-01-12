using System;

namespace CiaranONeill.NPV.Calculator
{
    public static class Guard
    { 
        public static void IsInRange(double input, string name, double lower, double upper) 
        {
            if (input <= lower || input > upper)
                throw new ArgumentException(string.Format("{0} must be between {1} and {2}", name, lower, upper), name);
        }

        public static void GreaterThan(int input, string name, int lower)
        {
            if (input <= lower)
                throw new ArgumentException(string.Format("{0} must be greater than {1}", name, lower), name);
        }
    }
}