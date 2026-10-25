using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between power units.
/// </summary>
/// <remarks>
/// The base unit is the watt. The mechanical horsepower is 745.69987158227022 W, the metric horsepower (PS) is 735.49875 W and one BTU (International Table) per hour is 1055.05585262 / 3600 W. The symbols mW (milliwatt) and MW (megawatt) differ only in case, so the milliwatt is available only by name.
/// </remarks>
public class PowerConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (W).
    /// </summary>
    public PowerConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public PowerConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one W. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("W")
    {
        { new UnitFactorSynonyms("W", "watt", "watts"), 1 },
        { new UnitFactorSynonyms("milliwatt", "milliwatts"), 1000 },
        { new UnitFactorSynonyms("kW", "kilowatt", "kilowatts"), 0.001 },
        { new UnitFactorSynonyms("MW", "megawatt", "megawatts"), 1d / 1_000_000 },
        { new UnitFactorSynonyms("GW", "gigawatt", "gigawatts"), 1d / 1_000_000_000 },
        { new UnitFactorSynonyms("hp", "horsepower", "mechanical horsepower"), 1d / 745.69987158227022 },
        { new UnitFactorSynonyms("PS", "metric horsepower"), 1d / 735.49875 },
        { new UnitFactorSynonyms("BTU/h", "btu/hr", "btu per hour"), 3600d / 1055.05585262 },
    };
}
