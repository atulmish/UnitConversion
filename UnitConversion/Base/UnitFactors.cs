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
        public UnitFactorKeys FindUnit(UnitFactorKeys key) {
            return this.Keys.FirstOrDefault(factor => factor.Contains(key));
        }

        /// <summary>
        /// Find if the given unit is supported
        /// </summary>
        /// <param name="synonym"></param>
        /// <returns></returns>
        public UnitFactorKeys FindUnit(string synonym) {
            return FindUnit((UnitFactorKeys)synonym);
        }
    }
}
