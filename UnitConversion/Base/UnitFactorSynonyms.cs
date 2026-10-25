using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConversion.Base;

/// <summary>
/// The set of names (symbol, singular, plural, spelling variants) that identify one unit.
/// Name matching ignores case and culture.
/// </summary>
public class UnitFactorSynonyms
{
    private readonly List<string> synonyms = new List<string>();

    /// <summary>
    /// Creates an empty set of synonyms.
    /// </summary>
    public UnitFactorSynonyms()
    {
    }

    /// <summary>
    /// Creates a set of synonyms.
    /// </summary>
    /// <param name="items">The names of the unit.</param>
    public UnitFactorSynonyms(params string[] items)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        synonyms.AddRange(items);
    }

    /// <summary>
    /// The list of synonyms this object holds.
    /// </summary>
    public IEnumerable<string> Synonyms => synonyms.AsEnumerable();

    /// <summary>
    /// Allows a string to be used where a set of synonyms is expected.
    /// </summary>
    /// <param name="synonym">The single name of the unit.</param>
    public static implicit operator UnitFactorSynonyms(string synonym) => new UnitFactorSynonyms(synonym);

    /// <inheritdoc />
    public override string ToString() => string.Join(", ", synonyms);

    // Append a new synonym to the list.
    internal void AddSynonym(string synonym)
    {
        if (Contains(synonym))
        {
            throw new UnitAlreadyExistsException(synonym);
        }

        synonyms.Add(synonym);
    }

    // Find whether some synonym of the given set is included in this one.
    internal bool Contains(UnitFactorSynonyms other)
    {
        foreach (var synonym in other.Synonyms)
        {
            if (Contains(synonym))
            {
                return true;
            }
        }

        return false;
    }

    // Find whether a synonym is included in this set, ignoring case and culture.
    internal bool Contains(string? synonym) =>
        synonym != null && synonyms.Contains(synonym, StringComparer.OrdinalIgnoreCase);
}
