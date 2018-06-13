using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConversion.Base
{
    public static class ExtensionMethods
    {
        public const double lowerBoundEpsilon = 0.99999;
        public const double upperBoundEpsilon = 0.999999999;

        /// <summary>
        /// Return close enough value
        /// </summary>
        /// <param name="value">result value to be check</param>
        /// <returns>Closed value</returns>
        public static double CheckCloseEnoughValue(this double value)
        {
            double diff = value - Math.Floor(value);
            if (diff > lowerBoundEpsilon && diff < upperBoundEpsilon)
                return Math.Ceiling(value);
            return value;
        }
    }
}
