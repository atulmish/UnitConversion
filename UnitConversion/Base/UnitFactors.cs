using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactors : Dictionary<UnitFactorKeys, double> {
        public UnitFactors(string baseUnit) {
            BaseUnit = baseUnit;
        }

        protected string BaseUnit;

        /// <summary>
        /// Find if the given unit is supported
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsUnit(UnitFactorKeys key) {
            return this.Any(factor => factor.Key.Contains(key));
        }

        /// <summary>
        /// Find if the given unit is supported
        /// </summary>
        /// <param name="synonym"></param>
        /// <returns></returns>
        public bool ContainsUnit(string synonym) {
            return ContainsUnit((UnitFactorKeys)synonym);
        }
    }
}
