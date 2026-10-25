using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between energy units.
/// </summary>
/// <remarks>
/// The base unit is the joule. The calorie is the thermochemical calorie (4.184 J), the BTU is the International Table BTU (1055.05585262 J), the electronvolt is 1.602176634e-19 J and the foot-pound force is 0.3048 m × 4.4482216152605 N.
/// </remarks>
public class EnergyConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (J).
    /// </summary>
    public EnergyConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public EnergyConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one J. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("J")
    {
        { new UnitFactorSynonyms("J", "joule", "joules"), 1 },
        { new UnitFactorSynonyms("kJ", "kilojoule", "kilojoules"), 0.001 },
        { new UnitFactorSynonyms("MJ", "megajoule", "megajoules"), 1d / 1_000_000 },
        { new UnitFactorSynonyms("cal", "calorie", "calories"), 1d / 4.184 },
        { new UnitFactorSynonyms("kcal", "kilocalorie", "kilocalories"), 1d / 4184 },
        { new UnitFactorSynonyms("Wh", "watt hour", "watt-hour"), 1d / 3600 },
        { new UnitFactorSynonyms("kWh", "kilowatt hour", "kilowatt-hour"), 1d / 3_600_000 },
        { new UnitFactorSynonyms("BTU", "british thermal unit"), 1d / 1055.05585262 },
        { new UnitFactorSynonyms("eV", "electronvolt"), 1d / 1.602176634e-19 },
        { new UnitFactorSynonyms("ft-lbf", "ft lbf", "foot-pound", "foot pound force"), 1d / (0.3048 * 4.4482216152605) },
    };
}
