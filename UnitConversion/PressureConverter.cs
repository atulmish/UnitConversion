using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between pressure units.
/// </summary>
/// <remarks>
/// The base unit is the pascal. The standard atmosphere is 101 325 Pa, the torr is 1/760 of it, the conventional millimetre of mercury is 133.322387415 Pa and the conventional inch of mercury 3386.389 Pa. The psi is one pound-force (4.4482216152605 N) per square inch.
/// </remarks>
public class PressureConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (Pa).
    /// </summary>
    public PressureConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public PressureConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one Pa. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("Pa")
    {
        { new UnitFactorSynonyms("Pa", "pascal", "pascals"), 1 },
        { new UnitFactorSynonyms("hPa", "hectopascal"), 0.01 },
        { new UnitFactorSynonyms("kPa", "kilopascal"), 0.001 },
        { new UnitFactorSynonyms("MPa", "megapascal"), 1d / 1_000_000 },
        { new UnitFactorSynonyms("bar"), 1d / 100_000 },
        { new UnitFactorSynonyms("mbar", "millibar"), 0.01 },
        { new UnitFactorSynonyms("atm", "standard atmosphere"), 1d / 101_325 },
        { new UnitFactorSynonyms("psi", "pound per square inch"), 0.00064516 / 4.4482216152605 },
        { new UnitFactorSynonyms("torr"), 760d / 101_325 },
        { new UnitFactorSynonyms("mmHg", "millimetre of mercury", "millimeter of mercury"), 1d / 133.322387415 },
        { new UnitFactorSynonyms("inHg", "inch of mercury"), 1d / 3386.389 },
    };
}
