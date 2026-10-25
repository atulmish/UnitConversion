using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConversion.Base;

/// <summary>
/// The conversion factors of a converter: for every unit, how many of that unit make up one base unit.
/// </summary>
public class UnitFactors : Dictionary<UnitFactorSynonyms, double>
{
    /// <summary>
    /// Creates an empty table of factors.
    /// </summary>
    /// <param name="baseUnit">The name of the unit every other factor is relative to. It has a factor of 1.</param>
    public UnitFactors(string baseUnit)
    {
        BaseUnit = baseUnit ?? throw new ArgumentNullException(nameof(baseUnit));
    }

    /// <summary>
    /// The unit every other factor is relative to.
    /// </summary>
    public string BaseUnit { get; }

    // Find the key, or null, for a given unit.
    internal UnitFactorSynonyms? FindUnit(UnitFactorSynonyms synonyms) =>
        Keys.FirstOrDefault(factor => factor.Contains(synonyms));

    // Get the factor for a given unit.
    internal double FindFactor(UnitFactorSynonyms synonyms)
    {
        var unit = this.FirstOrDefault(factor => factor.Key.Contains(synonyms));
        if (unit.Key == null)
        {
            throw new UnitNotSupportedException(synonyms.ToString());
        }

        return unit.Value;
    }
}
