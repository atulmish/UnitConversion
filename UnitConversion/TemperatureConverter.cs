using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between temperature scales.
/// </summary>
/// <remarks>
/// Scales are not related by a single factor, so conversions use formulas (see <see cref="TemperatureHelper"/>).
/// Scale names ignore case. The base scale is Celsius.
/// </remarks>
public class TemperatureConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right scales are both Celsius.
    /// </summary>
    public TemperatureConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two scales.
    /// </summary>
    /// <param name="leftUnit">The scale on the left: celsius, fahrenheit or kelvin (also °C, °F, K).</param>
    /// <param name="rightUnit">The scale on the right.</param>
    /// <exception cref="UnitNotSupportedException">A scale is not supported by this converter.</exception>
    public TemperatureConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    /// <inheritdoc />
    protected override double Convert(double value, string startUnit, string endUnit) =>
        TemperatureHelper.AToB(value, startUnit, endUnit);

    // The factors are placeholders: temperature conversions use formulas, not factors.
    private static UnitFactors CreateUnits() => new UnitFactors("celsius")
    {
        { new UnitFactorSynonyms("celsius", "Celsius", "°C", "°c", "C", "c"), 1 },
        { new UnitFactorSynonyms("fahrenheit", "Fahrenheit", "°F", "°f", "F", "f"), 1 },
        { new UnitFactorSynonyms("Kelvin", "kelvin", "°K", "°k", "K", "k"), 1 },
    };
}
