using UnitConversion.Base;

namespace UnitConversion;

/// <summary>
/// Converts between digital storage units.
/// </summary>
/// <remarks>
/// The base unit is the byte (8 bits). Decimal prefixes (kB, MB, GB, TB, PB) are powers of 1000 and binary prefixes (KiB, MiB, GiB, TiB, PiB) are powers of 1024. Unit names ignore case, so bits are available only as 'bit' and the prefixed bit units kbit, Mbit and Gbit (never 'b' or 'Kb').
/// </remarks>
public class DigitalStorageConverter : BaseUnitConverter
{
    /// <summary>
    /// Creates a converter whose left and right units are both the base unit (B).
    /// </summary>
    public DigitalStorageConverter()
    {
        Instantiate(CreateUnits());
    }

    /// <summary>
    /// Creates a converter between two units.
    /// </summary>
    /// <param name="leftUnit">The unit on the left. Any synonym of a supported unit.</param>
    /// <param name="rightUnit">The unit on the right. Any synonym of a supported unit.</param>
    /// <exception cref="UnitNotSupportedException">A unit is not supported by this converter.</exception>
    public DigitalStorageConverter(string leftUnit, string rightUnit)
    {
        Instantiate(CreateUnits(), leftUnit, rightUnit);
    }

    // Each factor is how many of the unit make up one B. Definitions are exact (see docs/units.md).
    private static UnitFactors CreateUnits() => new UnitFactors("B")
    {
        { new UnitFactorSynonyms("B", "byte", "bytes"), 1 },
        { new UnitFactorSynonyms("bit", "bits"), 8 },
        { new UnitFactorSynonyms("kbit", "kilobit", "kilobits"), 8d / 1_000 },
        { new UnitFactorSynonyms("Mbit", "megabit", "megabits"), 8d / 1_000_000 },
        { new UnitFactorSynonyms("Gbit", "gigabit", "gigabits"), 8d / 1_000_000_000 },
        { new UnitFactorSynonyms("kB", "KB", "kilobyte", "kilobytes"), 1d / 1_000 },
        { new UnitFactorSynonyms("MB", "megabyte", "megabytes"), 1d / 1_000_000 },
        { new UnitFactorSynonyms("GB", "gigabyte", "gigabytes"), 1d / 1_000_000_000 },
        { new UnitFactorSynonyms("TB", "terabyte", "terabytes"), 1d / 1_000_000_000_000 },
        { new UnitFactorSynonyms("PB", "petabyte", "petabytes"), 1d / 1_000_000_000_000_000 },
        { new UnitFactorSynonyms("KiB", "kibibyte", "kibibytes"), 1d / 1024 },
        { new UnitFactorSynonyms("MiB", "mebibyte", "mebibytes"), 1d / 1_048_576 },
        { new UnitFactorSynonyms("GiB", "gibibyte", "gibibytes"), 1d / 1_073_741_824 },
        { new UnitFactorSynonyms("TiB", "tebibyte", "tebibytes"), 1d / 1_099_511_627_776 },
        { new UnitFactorSynonyms("PiB", "pebibyte", "pebibytes"), 1d / 1_125_899_906_842_624 },
    };
}
