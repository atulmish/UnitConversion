using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between volume units.
/// </summary>
/// <remarks>
/// The base unit is the litre. Cubic units derive from the metre, foot and inch; the US customary units from the US gallon (231 in³ = 3.785411784 L); the imperial units from the imperial gallon (4.54609 L).
/// </remarks>
public class VolumeConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (l).
    /// </summary>
    public VolumeConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public VolumeConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one l. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("l")
    {
        { new UnitFactorSynonyms("l", "L", "lt", "ltr", "liter", "litre", "liters", "litres", "dm³", "dm3", "cubic decimetre", "cubic decimeter"), 1 },
        { new UnitFactorSynonyms("ml", "millilitre", "milliliter", "millilitres", "milliliters"), 1000 },
        { new UnitFactorSynonyms("cl", "centilitre", "centiliter"), 100 },
        { new UnitFactorSynonyms("dl", "decilitre", "deciliter"), 10 },
        { new UnitFactorSynonyms("m³", "m3", "cubic metre", "cubic meter"), 0.001 },
        { new UnitFactorSynonyms("cm³", "cm3", "cubic centimetre", "cubic centimeter", "cc"), 1000 },
        { new UnitFactorSynonyms("mm³", "mm3", "cubic millimetre", "cubic millimeter"), 1_000_000 },
        { new UnitFactorSynonyms("ft³", "ft3", "cubic foot", "cubic feet", "cu ft"), 1d / 28.316846592 },
        { new UnitFactorSynonyms("in³", "in3", "cu in", "cubic inch", "cubic inches"), 1d / 0.016387064 },
        { new UnitFactorSynonyms("imperial pint", "imperial pt", "imperial p"), 1d / 0.56826125 },
        { new UnitFactorSynonyms("imperial quart", "imperial qt"), 1d / 1.1365225 },
        { new UnitFactorSynonyms("imperial gallon", "imperial gal"), 1d / 4.54609 },
        { new UnitFactorSynonyms("imperial fluid ounce", "imperial fl oz"), 1d / 0.0284130625 },
        { new UnitFactorSynonyms("US teaspoon", "US tsp"), 1d / 0.00492892159375 },
        { new UnitFactorSynonyms("US tablespoon", "US tbsp"), 1d / 0.01478676478125 },
        { new UnitFactorSynonyms("US fluid ounce", "US fl oz"), 1d / 0.0295735295625 },
        { new UnitFactorSynonyms("US cup"), 1d / 0.2365882365 },
        { new UnitFactorSynonyms("US pint", "US pt", "US p"), 1d / 0.473176473 },
        { new UnitFactorSynonyms("US quart", "US qt"), 1d / 0.946352946 },
        { new UnitFactorSynonyms("US gallon", "US gal"), 1d / 3.785411784 },
    };
}
