using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between time units.
/// </summary>
/// <remarks>
/// The base unit is the second. A minute is 60 s, an hour 3600 s, a day 86 400 s and a week 7 days. A year is 365 days and a leap year 366 days.
/// </remarks>
public class TimeConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (s).
    /// </summary>
    public TimeConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public TimeConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one s. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("s")
    {
        { new UnitFactorSynonyms("s", "sec", "second", "seconds", "secs"), 1 },
        { new UnitFactorSynonyms("ds", "decisecond", "deci-second"), 10 },
        { new UnitFactorSynonyms("cs", "centisecond", "centi-second"), 100 },
        { new UnitFactorSynonyms("ms", "millisecond", "milli-second", "milliseconds"), 1_000 },
        { new UnitFactorSynonyms("us", "µs", "μs", "microsecond", "micro-second", "microseconds"), 1_000_000 },
        { new UnitFactorSynonyms("ns", "nanosecond", "nano-second", "nanoseconds"), 1_000_000_000 },
        { new UnitFactorSynonyms("min", "minute", "minutes", "mins"), 1d / 60 },
        { new UnitFactorSynonyms("h", "hr", "hrs", "hour", "hours"), 1d / 3600 },
        { new UnitFactorSynonyms("d", "day", "days"), 1d / 86400 },
        { new UnitFactorSynonyms("wk", "week", "weeks"), 1d / 604800 },
        { new UnitFactorSynonyms("y", "year", "years"), 1d / 31536000 },
        { new UnitFactorSynonyms("leap year", "leap-year"), 1d / 31622400 },
    };
}
