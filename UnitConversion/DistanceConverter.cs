using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between distance units.
/// </summary>
/// <remarks>
/// The base unit is the metre. Inch, foot, yard and mile use the international definitions (1 in = 0.0254 m); the astronomical unit and the light year use their IAU definitions.
/// </remarks>
public class DistanceConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (m).
    /// </summary>
    public DistanceConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public DistanceConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one m. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("m")
    {
        { new UnitFactorSynonyms("m", "metre", "meter", "metres", "meters"), 1 },
        { new UnitFactorSynonyms("km", "kilometre", "kilometer", "kilometres", "kilometers"), 1d / 1000 },
        { new UnitFactorSynonyms("cm", "centimetre", "centimeter", "centimetres", "centimeters"), 100 },
        { new UnitFactorSynonyms("mm", "millimetre", "millimeter", "millimetres", "millimeters"), 1000 },
        { new UnitFactorSynonyms("µm", "μm", "um", "micrometre", "micrometer", "micron"), 1_000_000 },
        { new UnitFactorSynonyms("nm", "nanometre", "nanometer"), 1_000_000_000 },
        { new UnitFactorSynonyms("in", "inch", "inches"), 1d / 0.0254 },
        { new UnitFactorSynonyms("ft", "foot", "feet"), 1d / 0.3048 },
        { new UnitFactorSynonyms("yd", "yard", "yards"), 1d / 0.9144 },
        { new UnitFactorSynonyms("mile", "miles", "mi"), 1d / 1609.344 },
        { new UnitFactorSynonyms("nmi", "nautical mile", "nautical miles"), 1d / 1852 },
        { new UnitFactorSynonyms("au", "astronomical unit"), 1d / 149_597_870_700 },
        { new UnitFactorSynonyms("ly", "light year", "light-year", "lightyear"), 1d / 9_460_730_472_580_800 },
    };
}
