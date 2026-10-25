using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between angle units.
/// </summary>
/// <remarks>
/// The base unit is the degree. A full turn is 360 degrees, 2π radians and 400 gradians; an arcminute is 1/60 of a degree and an arcsecond 1/3600.
/// </remarks>
public class AngleConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (degree).
    /// </summary>
    public AngleConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public AngleConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one degree. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("degree")
    {
        { new UnitFactorSynonyms("degree", "deg", "°", "degrees"), 1 },
        { new UnitFactorSynonyms("rad", "radian", "radians"), System.Math.PI / 180 },
        { new UnitFactorSynonyms("grad", "gradian", "gon", "gradians"), 400d / 360 },
        { new UnitFactorSynonyms("turn", "revolution", "rev", "turns"), 1d / 360 },
        { new UnitFactorSynonyms("arcmin", "arcminute", "arcminutes"), 60 },
        { new UnitFactorSynonyms("arcsec", "arcsecond", "arcseconds"), 3600 },
    };
}
