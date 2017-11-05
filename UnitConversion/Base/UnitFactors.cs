using System.Collections.Generic;
using System.Linq;

namespace UnitConversion.Base {
    public class UnitFactors : Dictionary<UnitFactorSynonyms, double> {
        public UnitFactors(string baseUnit) {
            BaseUnit = baseUnit;
        }

        public string BaseUnit { get; private set; }

        // Find the key or null for a given unit
        internal UnitFactorSynonyms FindUnit(UnitFactorSynonyms synonyms) {
            return Keys.FirstOrDefault(factor => factor.Contains(synonyms));
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
