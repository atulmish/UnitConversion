using System;

using UnitConversion.Base;

namespace UnitConversion {
    public class DistanceConverter : BaseUnitConverter {
        UnitFactors units = new UnitFactors("m") {
            { new UnitFactorSynonyms("m", "metre"), 1 },
            { new UnitFactorSynonyms("km", "kilometre"), 0.001 },
            { new UnitFactorSynonyms("cm", "centimetre"), 100 },
            { new UnitFactorSynonyms("mm", "millimetre"), 1000 },
            { new UnitFactorSynonyms("ft", "foot", "feet"), 1250d / 381 },
            { new UnitFactorSynonyms("yd", "yard"), 1250d / 1143 },
            { "mile", 125d / 201168 },
            { new UnitFactorSynonyms("in", "inch"), 5000d / 127 },
        };

        public DistanceConverter(string leftUnit, string rightUnit) {
            Instantiate(units, leftUnit, rightUnit);
        }
        public DistanceConverter() {
            Instantiate(units);
        }
    }
}
