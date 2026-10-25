using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between speed units.
/// </summary>
/// <remarks>
/// The base unit is the metre per second. The knot is one nautical mile (1852 m) per hour.
/// </remarks>
public class SpeedConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (m/s).
    /// </summary>
    public SpeedConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public SpeedConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one m/s. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("m/s")
    {
        { new UnitFactorSynonyms("m/s", "mps", "metre per second", "meter per second", "metres per second", "meters per second"), 1 },
        { new UnitFactorSynonyms("km/h", "kph", "kmh", "kmph", "kilometre per hour", "kilometer per hour", "kilometres per hour", "kilometers per hour"), 3600d / 1000 },
        { new UnitFactorSynonyms("mph", "mi/h", "mile per hour", "miles per hour"), 3600d / 1609.344 },
        { new UnitFactorSynonyms("kn", "kt", "knot", "knots"), 3600d / 1852 },
        { new UnitFactorSynonyms("ft/s", "fps", "foot per second", "feet per second"), 1d / 0.3048 },
    };
}
