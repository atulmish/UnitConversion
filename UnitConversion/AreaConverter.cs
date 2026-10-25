using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between area units.
/// </summary>
/// <remarks>
/// The base unit is the square metre. Imperial units derive from the international foot (0.3048 m); the acre is 4046.8564224 m².
/// </remarks>
public class AreaConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (m²).
    /// </summary>
    public AreaConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public AreaConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one m². Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("m²")
    {
        { new UnitFactorSynonyms("m²", "m2", "square metre", "square meter", "square metres", "square meters", "sq m", "centiare"), 1 },
        { new UnitFactorSynonyms("km²", "km2", "square kilometre", "square kilometer", "sq km", "kilometre"), 1d / 1_000_000 },
        { new UnitFactorSynonyms("cm²", "cm2", "square centimetre", "square centimeter", "sq cm", "centimetre"), 10_000 },
        { new UnitFactorSynonyms("mm²", "mm2", "square millimetre", "square millimeter", "sq mm", "millimetre"), 1_000_000 },
        { new UnitFactorSynonyms("a", "are"), 0.01 },
        { new UnitFactorSynonyms("ha", "hectare", "hectares"), 0.0001 },
        { new UnitFactorSynonyms("ac", "acre", "acres"), 1d / 4046.8564224 },
        { new UnitFactorSynonyms("in²", "in2", "sq in", "square inch", "square inches"), 1d / 0.00064516 },
        { new UnitFactorSynonyms("ft²", "ft2", "square foot", "square feet", "sq ft"), 1d / 0.09290304 },
        { new UnitFactorSynonyms("yd²", "yd2", "sq yd", "square yard", "square yards"), 1d / 0.83612736 },
        { new UnitFactorSynonyms("mi²", "mi2", "sq mi", "square mile", "square miles"), 1d / 2_589_988.110336 },
    };
}
