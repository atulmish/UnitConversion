using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConversion.Base;

/// <summary>
/// Temperature scales do not differ by a single factor, so they are converted with formulas.
/// </summary>
#pragma warning disable CA2211 // public mutable fields are part of the published API
public class TemperatureHelper
{
    /// <summary>
    /// The names of the Celsius scale.
    /// </summary>
    public static List<string> Celsius = new List<string> { "celsius", "Celsius", "°C", "°c", "C", "c" };

    /// <summary>
    /// The names of the Fahrenheit scale.
    /// </summary>
    public static List<string> Fahrenheit = new List<string> { "fahrenheit", "Fahrenheit", "°F", "°f", "F", "f" };

    /// <summary>
    /// The names of the Kelvin scale.
    /// </summary>
    public static List<string> Kelvin = new List<string> { "Kelvin", "kelvin", "°K", "°k", "K", "k" };
#pragma warning restore CA2211

    /// <summary>
    /// Converts a temperature between two scales. Scale names are matched ignoring case.
    /// </summary>
    /// <param name="value">The temperature in <paramref name="startUnit"/>.</param>
    /// <param name="startUnit">The scale of <paramref name="value"/>.</param>
    /// <param name="endUnit">The scale to convert to.</param>
    /// <returns>The temperature in <paramref name="endUnit"/>. The value is returned unchanged when both are the same scale.</returns>
    public static double AToB(double value, string startUnit, string endUnit)
    {
        // Reference: https://www.thoughtco.com/temperature-conversion-formulas-609324
        if (Is(Celsius, startUnit) && Is(Fahrenheit, endUnit))
        {
            // Celsius to Fahrenheit: °F = 9/5 (°C) + 32
            return ((9d / 5) * value) + 32;
        }

        if (Is(Kelvin, startUnit) && Is(Fahrenheit, endUnit))
        {
            // Kelvin to Fahrenheit: °F = 9/5 (K - 273.15) + 32
            return ((9d / 5) * (value - 273.15)) + 32;
        }

        if (Is(Fahrenheit, startUnit) && Is(Celsius, endUnit))
        {
            // Fahrenheit to Celsius: °C = 5/9 (°F - 32)
            return (5d / 9) * (value - 32);
        }

        if (Is(Celsius, startUnit) && Is(Kelvin, endUnit))
        {
            // Celsius to Kelvin: K = °C + 273.15
            return value + 273.15;
        }

        if (Is(Kelvin, startUnit) && Is(Celsius, endUnit))
        {
            // Kelvin to Celsius: °C = K - 273.15
            return value - 273.15;
        }

        if (Is(Fahrenheit, startUnit) && Is(Kelvin, endUnit))
        {
            // Fahrenheit to Kelvin: K = 5/9 (°F - 32) + 273.15
            return ((5d / 9) * (value - 32)) + 273.15;
        }

        // Both units are the same scale.
        return value;
    }

    private static bool Is(List<string> names, string unit) =>
        names.Contains(unit, StringComparer.OrdinalIgnoreCase);
}
