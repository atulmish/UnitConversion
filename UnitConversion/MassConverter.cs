using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between mass units.
/// </summary>
/// <remarks>
/// The base unit is the kilogram. The pound is defined as 0.45359237 kg and the avoirdupois units are derived from it. The short ton is 2000 lb and the long ton is 2240 lb.
/// </remarks>
public class MassConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (kg).
    /// </summary>
    public MassConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public MassConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one kg. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("kg")
    {
        { new UnitFactorSynonyms("kg", "kilogram", "kilograms"), 1 },
        { new UnitFactorSynonyms("gram", "g", "grams"), 1000 },
        { new UnitFactorSynonyms("mg", "milligram", "milligrams"), 1_000_000 },
        { new UnitFactorSynonyms("µg", "μg", "ug", "microgram", "micrograms"), 1_000_000_000 },
        { new UnitFactorSynonyms("t", "tonne", "tonnes", "metric ton"), 0.001 },
        { new UnitFactorSynonyms("quintal"), 0.01 },
        { new UnitFactorSynonyms("ct", "carat"), 5000 },
        { new UnitFactorSynonyms("gr", "grain"), 1d / 0.00006479891 },
        { new UnitFactorSynonyms("lb", "lbs", "pound", "pounds"), 1d / 0.45359237 },
        { new UnitFactorSynonyms("oz", "ounce", "ounces"), 1d / 0.028349523125 },
        { new UnitFactorSynonyms("st", "stone"), 1d / 6.35029318 },
        { new UnitFactorSynonyms("short ton", "net ton", "us ton"), 1d / 907.18474 },
        { new UnitFactorSynonyms("long ton", "weight ton", "gross ton", "imperial ton"), 1d / 1016.0469088 },
    };
}
