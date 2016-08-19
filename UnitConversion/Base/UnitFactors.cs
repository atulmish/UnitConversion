using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactors : Dictionary<UnitFactorSynonyms, double> {
        public UnitFactors(string baseUnit) {
            BaseUnit = baseUnit;
        }

        protected string BaseUnit;

        // Find the key or null for a given unit
        internal UnitFactorSynonyms FindUnit(UnitFactorSynonyms key) {
            return this.Keys.FirstOrDefault(factor => factor.Contains(key));
        }

        // Get the factor for a given unit
        internal double FindFactor(UnitFactorSynonyms key) {
            var unit = this.FirstOrDefault(factor => factor.Key.Contains(key));
            if (unit.Key == null) {
                throw new UnitNotSupportedException(key.ToString());
            }
            return unit.Value;
        }
    }
}
