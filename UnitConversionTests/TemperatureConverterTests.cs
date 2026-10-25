using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion;

namespace UnitConversionTests;

[TestClass]
public class TemperatureConverterTests
{
    [TestMethod]
    [DataRow("celsius", "fahrenheit", 0.0, 32.0)]
    [DataRow("celsius", "fahrenheit", 100.0, 212.0)]
    [DataRow("celsius", "fahrenheit", -40.0, -40.0)]
    [DataRow("celsius", "kelvin", 0.0, 273.15)]
    [DataRow("celsius", "kelvin", -273.15, 0.0)]
    [DataRow("fahrenheit", "celsius", 212.0, 100.0)]
    [DataRow("fahrenheit", "celsius", 32.0, 0.0)]
    [DataRow("fahrenheit", "kelvin", 32.0, 273.15)]
    [DataRow("kelvin", "celsius", 373.15, 100.0)]
    [DataRow("kelvin", "fahrenheit", 0.0, -459.67)]
    public void ConvertsBetweenScales(string from, string to, double input, double expected)
    {
        var converter = new TemperatureConverter(from, to);

        Assert.AreEqual(expected, converter.LeftToRight(input), 1e-9);
        Assert.AreEqual(input, converter.RightToLeft(expected), 1e-9);
    }

    [TestMethod]
    [DataRow("CELSIUS", "FAHRENHEIT")]
    [DataRow("Celsius", "Fahrenheit")]
    [DataRow("°C", "°F")]
    [DataRow("°c", "°f")]
    [DataRow("C", "F")]
    [DataRow("c", "f")]
    public void ScaleNamesIgnoreCase(string from, string to)
    {
        // Unit lookup has always ignored case; the conversion itself used to be case-sensitive and
        // silently returned the input unchanged for names such as "CELSIUS".
        Assert.AreEqual(212.0, new TemperatureConverter(from, to).LeftToRight(100), 1e-9);
    }

    [TestMethod]
    [DataRow("K", "c", 273.15, 0.0)]
    [DataRow("°K", "°C", 273.15, 0.0)]
    [DataRow("KELVIN", "CELSIUS", 273.15, 0.0)]
    public void KelvinNames(string from, string to, double input, double expected)
    {
        Assert.AreEqual(expected, new TemperatureConverter(from, to).LeftToRight(input), 1e-9);
    }

    [TestMethod]
    public void ConvertingAScaleToItselfChangesNothing()
    {
        Assert.AreEqual(21.5, new TemperatureConverter("celsius", "celsius").LeftToRight(21.5));
        Assert.AreEqual(21.5, new TemperatureConverter("kelvin", "kelvin").LeftToRight(21.5));
    }

    [TestMethod]
    public void RoundsWhenAsked()
    {
        Assert.AreEqual(98.6, new TemperatureConverter("celsius", "fahrenheit").LeftToRight(37.0, 1));
    }
}
