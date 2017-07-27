using UnitConversion.Base;

namespace UnitConversion
{
    public class AreaConverter : BaseUnitConverter {
        UnitFactors units = new UnitFactors("m") {
            { new UnitFactorSynonyms("m2", "square metre", "centiare"), 1 },
            { new UnitFactorSynonyms("km2", "kilometre"), 0.000001 },
            { new UnitFactorSynonyms("cm2", "centimetre"), 10000 },
            { new UnitFactorSynonyms("mm2", "millimetre"), 1000000 },
            { new UnitFactorSynonyms("ft2", "square foot", "square feet", "sq ft"), 1d /  0.3048 /  0.3048 },
            { new UnitFactorSynonyms("yd2", "sq yd", "square yard"), 1d /  0.9144 /  0.9144},
            { new UnitFactorSynonyms("a", "are"), 0.01 },
            { new UnitFactorSynonyms("ha", "hectare"), 0.0001 },
            { new UnitFactorSynonyms("in2", "sq in", "square inch"), 1d / 0.00064516 },
            { new UnitFactorSynonyms("mi2", "sq mi", "square mile"), 1d / 2589988.110336 },

        };

        public AreaConverter(string leftUnit, string rightUnit) {
            Instantiate(units, leftUnit, rightUnit);
        }
        public AreaConverter() {
            Instantiate(units);
        }
    }
}
