using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactors : Dictionary<UnitFactorSynonyms, double> {
        public UnitFactors(string baseUnit) {
            BaseUnit = baseUnit;
        }

        private string _baseUnit;
        public string BaseUnit {
            get {
                return _baseUnit;
            }
            private set {
                _baseUnit = value;
            }
        }

        // Find the key or null for a given unit
        internal UnitFactorSynonyms FindUnit(UnitFactorSynonyms synonyms) {
            return this.Keys.FirstOrDefault(factor => factor.Contains(synonyms));
        }

        // Get the factor for a given unit
        internal double FindFactor(UnitFactorSynonyms synonyms) {
            var unit = this.FirstOrDefault(factor => factor.Key.Contains(synonyms));
            if (unit.Key == null) {
                throw new UnitNotSupportedException(synonyms.ToString());
            }
            return unit.Value;
        }
    }
}
