using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitConversionTests;

/// <summary>
/// Conversions checked against the published definitions of each unit, written independently of the
/// library's tables. Every row also runs in reverse.
/// </summary>
[TestClass]
public class ReferenceConversionTests
{
    // converter, from unit, to unit, amount in "from", expected amount in "to"
    [TestMethod]
    // Distance (international yard and pound agreement of 1959; IAU 2012 astronomical unit; Julian light year)
    [DataRow("Distance", "in", "mm", 1.0, 25.4)]
    [DataRow("Distance", "ft", "m", 1.0, 0.3048)]
    [DataRow("Distance", "yd", "m", 1.0, 0.9144)]
    [DataRow("Distance", "mile", "m", 1.0, 1609.344)]
    [DataRow("Distance", "mi", "km", 1.0, 1.609344)]
    [DataRow("Distance", "nmi", "m", 1.0, 1852.0)]
    [DataRow("Distance", "au", "m", 1.0, 149597870700.0)]
    [DataRow("Distance", "ly", "m", 1.0, 9460730472580800.0)]
    [DataRow("Distance", "km", "m", 1.0, 1000.0)]
    [DataRow("Distance", "cm", "mm", 1.0, 10.0)]
    [DataRow("Distance", "um", "mm", 1000.0, 1.0)]
    [DataRow("Distance", "nm", "um", 1000.0, 1.0)]
    // Mass
    [DataRow("Mass", "lb", "kg", 1.0, 0.45359237)]
    [DataRow("Mass", "oz", "g", 1.0, 28.349523125)]
    [DataRow("Mass", "st", "kg", 1.0, 6.35029318)]
    [DataRow("Mass", "short ton", "kg", 1.0, 907.18474)]
    [DataRow("Mass", "long ton", "kg", 1.0, 1016.0469088)]
    [DataRow("Mass", "t", "kg", 1.0, 1000.0)]
    [DataRow("Mass", "ct", "g", 1.0, 0.2)]
    [DataRow("Mass", "gr", "mg", 1.0, 64.79891)]
    [DataRow("Mass", "quintal", "kg", 1.0, 100.0)]
    [DataRow("Mass", "g", "mg", 1.0, 1000.0)]
    [DataRow("Mass", "mg", "ug", 1.0, 1000.0)]
    [DataRow("Mass", "short ton", "lb", 1.0, 2000.0)]
    [DataRow("Mass", "long ton", "lb", 1.0, 2240.0)]
    // Area
    [DataRow("Area", "acre", "m2", 1.0, 4046.8564224)]
    [DataRow("Area", "ha", "m2", 1.0, 10000.0)]
    [DataRow("Area", "a", "m2", 1.0, 100.0)]
    [DataRow("Area", "km2", "m2", 1.0, 1000000.0)]
    [DataRow("Area", "ft2", "m2", 1.0, 0.09290304)]
    [DataRow("Area", "yd2", "m2", 1.0, 0.83612736)]
    [DataRow("Area", "in2", "cm2", 1.0, 6.4516)]
    [DataRow("Area", "mi2", "km2", 1.0, 2.589988110336)]
    [DataRow("Area", "acre", "ft2", 1.0, 43560.0)]
    [DataRow("Area", "sq mi", "acre", 1.0, 640.0)]
    // Volume (US customary from the US gallon of 231 in3; imperial from the 4.54609 L gallon)
    [DataRow("Volume", "US gallon", "l", 1.0, 3.785411784)]
    [DataRow("Volume", "US quart", "l", 1.0, 0.946352946)]
    [DataRow("Volume", "US pint", "l", 1.0, 0.473176473)]
    [DataRow("Volume", "US cup", "ml", 1.0, 236.5882365)]
    [DataRow("Volume", "US fl oz", "ml", 1.0, 29.5735295625)]
    [DataRow("Volume", "US tbsp", "ml", 1.0, 14.78676478125)]
    [DataRow("Volume", "US tsp", "ml", 1.0, 4.92892159375)]
    [DataRow("Volume", "imperial gallon", "l", 1.0, 4.54609)]
    [DataRow("Volume", "imperial quart", "l", 1.0, 1.1365225)]
    [DataRow("Volume", "imperial pint", "l", 1.0, 0.56826125)]
    [DataRow("Volume", "imperial fl oz", "ml", 1.0, 28.4130625)]
    [DataRow("Volume", "ft3", "l", 1.0, 28.316846592)]
    [DataRow("Volume", "in3", "ml", 1.0, 16.387064)]
    [DataRow("Volume", "m3", "l", 1.0, 1000.0)]
    [DataRow("Volume", "US gallon", "US quart", 1.0, 4.0)]
    [DataRow("Volume", "US quart", "US pint", 1.0, 2.0)]
    [DataRow("Volume", "US pint", "US cup", 1.0, 2.0)]
    [DataRow("Volume", "US cup", "US fl oz", 1.0, 8.0)]
    [DataRow("Volume", "imperial gallon", "imperial quart", 1.0, 4.0)]
    [DataRow("Volume", "imperial pint", "imperial fl oz", 1.0, 20.0)]
    [DataRow("Volume", "cc", "ml", 1.0, 1.0)]
    // Time
    [DataRow("Time", "min", "s", 1.0, 60.0)]
    [DataRow("Time", "h", "s", 1.0, 3600.0)]
    [DataRow("Time", "d", "s", 1.0, 86400.0)]
    [DataRow("Time", "wk", "d", 1.0, 7.0)]
    [DataRow("Time", "y", "d", 1.0, 365.0)]
    [DataRow("Time", "leap year", "d", 1.0, 366.0)]
    [DataRow("Time", "ms", "s", 1000.0, 1.0)]
    [DataRow("Time", "us", "ns", 1.0, 1000.0)]
    [DataRow("Time", "ds", "ms", 1.0, 100.0)]
    // Temperature
    [DataRow("Temperature", "celsius", "fahrenheit", 100.0, 212.0)]
    [DataRow("Temperature", "celsius", "kelvin", 0.0, 273.15)]
    [DataRow("Temperature", "fahrenheit", "celsius", -40.0, -40.0)]
    [DataRow("Temperature", "kelvin", "fahrenheit", 273.15, 32.0)]
    // Speed
    [DataRow("Speed", "km/h", "m/s", 3.6, 1.0)]
    [DataRow("Speed", "mph", "m/s", 1.0, 0.44704)]
    [DataRow("Speed", "kn", "m/s", 1.0, 1852.0 / 3600.0)]
    [DataRow("Speed", "ft/s", "m/s", 1.0, 0.3048)]
    [DataRow("Speed", "mph", "km/h", 60.0, 96.56064)]
    // Pressure
    [DataRow("Pressure", "atm", "Pa", 1.0, 101325.0)]
    [DataRow("Pressure", "bar", "Pa", 1.0, 100000.0)]
    [DataRow("Pressure", "psi", "Pa", 1.0, 6894.757293168361)]
    [DataRow("Pressure", "torr", "Pa", 1.0, 101325.0 / 760.0)]
    [DataRow("Pressure", "mmHg", "Pa", 1.0, 133.322387415)]
    [DataRow("Pressure", "inHg", "Pa", 1.0, 3386.389)]
    [DataRow("Pressure", "kPa", "Pa", 1.0, 1000.0)]
    [DataRow("Pressure", "MPa", "kPa", 1.0, 1000.0)]
    [DataRow("Pressure", "hPa", "mbar", 1.0, 1.0)]
    [DataRow("Pressure", "atm", "torr", 1.0, 760.0)]
    // Energy
    [DataRow("Energy", "cal", "J", 1.0, 4.184)]
    [DataRow("Energy", "kcal", "J", 1.0, 4184.0)]
    [DataRow("Energy", "BTU", "J", 1.0, 1055.05585262)]
    [DataRow("Energy", "Wh", "J", 1.0, 3600.0)]
    [DataRow("Energy", "kWh", "MJ", 1.0, 3.6)]
    [DataRow("Energy", "eV", "J", 1.0, 1.602176634e-19)]
    [DataRow("Energy", "ft-lbf", "J", 1.0, 1.3558179483314004)]
    [DataRow("Energy", "kJ", "J", 1.0, 1000.0)]
    // Power
    [DataRow("Power", "hp", "W", 1.0, 745.69987158227022)]
    [DataRow("Power", "PS", "W", 1.0, 735.49875)]
    [DataRow("Power", "BTU/h", "W", 1.0, 1055.05585262 / 3600.0)]
    [DataRow("Power", "kW", "W", 1.0, 1000.0)]
    [DataRow("Power", "MW", "kW", 1.0, 1000.0)]
    [DataRow("Power", "GW", "MW", 1.0, 1000.0)]
    [DataRow("Power", "milliwatt", "W", 1000.0, 1.0)]
    // Digital storage
    [DataRow("DigitalStorage", "B", "bit", 1.0, 8.0)]
    [DataRow("DigitalStorage", "kB", "B", 1.0, 1000.0)]
    [DataRow("DigitalStorage", "KiB", "B", 1.0, 1024.0)]
    [DataRow("DigitalStorage", "MiB", "KiB", 1.0, 1024.0)]
    [DataRow("DigitalStorage", "GiB", "MiB", 1.0, 1024.0)]
    [DataRow("DigitalStorage", "GB", "MB", 1.0, 1000.0)]
    [DataRow("DigitalStorage", "TB", "GB", 1.0, 1000.0)]
    [DataRow("DigitalStorage", "PiB", "TiB", 1.0, 1024.0)]
    [DataRow("DigitalStorage", "Mbit", "kB", 1.0, 125.0)]
    [DataRow("DigitalStorage", "Gbit", "MB", 8.0, 1000.0)]
    // Angle
    [DataRow("Angle", "degree", "rad", 180.0, System.Math.PI)]
    [DataRow("Angle", "turn", "degree", 1.0, 360.0)]
    [DataRow("Angle", "grad", "degree", 1.0, 0.9)]
    [DataRow("Angle", "arcmin", "degree", 60.0, 1.0)]
    [DataRow("Angle", "arcsec", "arcmin", 60.0, 1.0)]
    [DataRow("Angle", "rad", "turn", 2 * System.Math.PI, 1.0)]
    public void MatchesTheReferenceValue(string converter, string from, string to, double amount, double expected)
    {
        var forward = ConverterFactory.Create(converter, from, to);
        AssertClose(expected, forward.LeftToRight(amount), $"{amount} {from} in {to}");
        AssertClose(amount, forward.RightToLeft(expected), $"{expected} {to} in {from}");
    }

    private static void AssertClose(double expected, double actual, string what)
    {
        var tolerance = System.Math.Abs(expected) * 1e-12;
        Assert.IsTrue(
            System.Math.Abs(expected - actual) <= tolerance,
            $"{what}: expected {expected:R}, got {actual:R}");
    }
}
