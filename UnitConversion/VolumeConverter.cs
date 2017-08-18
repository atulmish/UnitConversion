using UnitConversion.Base;

namespace UnitConversion
{
    public class VolumeConverter : BaseUnitConverter
    {
        UnitFactors units = new UnitFactors("m³") {
            { new UnitFactorSynonyms("m³", "m3", "cubic metre"), 1 },
            { new UnitFactorSynonyms("km³", "km3", "cubic kilometre"), 0.000000001 },
            { new UnitFactorSynonyms("cm³", "cm3", "cubic centimetre"), 1000000 },
            { new UnitFactorSynonyms("mm³", "mm3", "cubic millimetre"), 1000000000 },
            { new UnitFactorSynonyms("ft³", "ft3", "cubic foot", "cubic feet"), 1d /  0.3048 /  0.3048 / 0.3048 },
            { new UnitFactorSynonyms("yd³", "yd3", "cubic yard"), 1d /  0.9144 /  0.9144 / 0.9144},
            { new UnitFactorSynonyms("l", "L", "litre"), 1000 },            
            { new UnitFactorSynonyms("in³", "in3", "cubic inch"), 1d / 0.000016387064 },
            { new UnitFactorSynonyms("mi³", "mi3", "cubic mile"), 1d / 4168181825.440579584},

        };

        public VolumeConverter(string leftUnit, string rightUnit)
        {
            Instantiate(units, leftUnit, rightUnit);
        }
        public VolumeConverter()
        {
            Instantiate(units);
        }
    }
}
