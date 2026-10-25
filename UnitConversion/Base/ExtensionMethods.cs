using System;

namespace UnitConversion.Base;

/// <summary>
/// Helpers for conversion results.
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Formerly the lower bound of the "close enough" window. No longer used.
    /// </summary>
    [Obsolete("No longer used. CheckCloseEnoughValue now snaps only floating-point noise.")]
    public const double lowerBoundEpsilon = 0.99999;

    /// <summary>
    /// Formerly the upper bound of the "close enough" window. No longer used.
    /// </summary>
    [Obsolete("No longer used. CheckCloseEnoughValue now snaps only floating-point noise.")]
    public const double upperBoundEpsilon = 0.999999999;

    // A value this close (relative to its size) to a whole number is floating-point noise.
    private const double RelativeTolerance = 1e-12;

    /// <summary>
    /// Removes floating-point noise from a result: a value that differs from a whole number only by
    /// rounding error (such as 2.9999999999999996) becomes that whole number. Every other value,
    /// including small ones, is returned unchanged.
    /// </summary>
    /// <param name="value">The result to check.</param>
    /// <returns>The whole number the value is a rounding error of, or the value itself.</returns>
    public static double CheckCloseEnoughValue(this double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
        {
            return value;
        }

        var rounded = Math.Round(value);
        if (rounded != 0 && Math.Abs(value - rounded) <= Math.Abs(rounded) * RelativeTolerance)
        {
            return rounded;
        }

        return value;
    }
}
