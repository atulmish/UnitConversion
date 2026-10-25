using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConversion.Base;

/// <summary>
/// Base functionality shared by all converters. A converter holds a table of unit factors and converts
/// between the <see cref="UnitLeft"/> and <see cref="UnitRight"/> units.
/// </summary>
public abstract class BaseUnitConverter : IUnitConverter
{
    private UnitFactors? units;
    private string? unitLeft;
    private string? unitRight;

    /// <summary>
    /// The unit to convert on the left.
    /// </summary>
    /// <exception cref="UnitNotSupportedException">The unit is not supported by this converter.</exception>
    public string UnitLeft
    {
        get => unitLeft ?? throw new InvalidOperationException("UnitLeft has not been set");
        set
        {
            ValidateSynonymExists(value);
            unitLeft = value;
        }
    }

    /// <summary>
    /// The unit to convert on the right.
    /// </summary>
    /// <exception cref="UnitNotSupportedException">The unit is not supported by this converter.</exception>
    public string UnitRight
    {
        get => unitRight ?? throw new InvalidOperationException("UnitRight has not been set");
        set
        {
            ValidateSynonymExists(value);
            unitRight = value;
        }
    }

    /// <summary>
    /// All the units this converter supports. Each entry holds the synonyms (names) of one unit.
    /// </summary>
    public IEnumerable<UnitFactorSynonyms> SupportedUnits => Units.Keys.AsEnumerable();

    /// <summary>
    /// The table of unit factors.
    /// </summary>
    protected UnitFactors Units
    {
        get => units ?? throw new InvalidOperationException("The unit factors have not been created");
        private set => units = value;
    }

    /// <summary>
    /// Convert the unit on the left to the unit on the right.
    /// </summary>
    /// <param name="value">The value in <see cref="UnitLeft"/>.</param>
    /// <returns>The converted value.</returns>
    public double LeftToRight(double value) => Convert(value, UnitLeft, UnitRight).CheckCloseEnoughValue();

    /// <summary>
    /// Convert the unit on the left to the unit on the right and round the result.
    /// </summary>
    /// <param name="value">The value in <see cref="UnitLeft"/>.</param>
    /// <param name="decimals">How many decimal places to round to.</param>
    /// <returns>The converted value.</returns>
    public double LeftToRight(double value, int decimals) => Math.Round(LeftToRight(value), decimals);

    /// <summary>
    /// Convert the unit on the right to the unit on the left.
    /// </summary>
    /// <param name="value">The value in <see cref="UnitRight"/>.</param>
    /// <returns>The converted value.</returns>
    public double RightToLeft(double value) => Convert(value, UnitRight, UnitLeft).CheckCloseEnoughValue();

    /// <summary>
    /// Convert the unit on the right to the unit on the left and round the result.
    /// </summary>
    /// <param name="value">The value in <see cref="UnitRight"/>.</param>
    /// <param name="decimals">How many decimal places to round to.</param>
    /// <returns>The converted value.</returns>
    public double RightToLeft(double value, int decimals) => Math.Round(RightToLeft(value), decimals);

    /// <summary>
    /// Add a new synonym to an existing unit's list of names.
    /// </summary>
    /// <param name="existingSynonym">Some synonym of an existing unit.</param>
    /// <param name="newSynonym">The new synonym to add to that unit.</param>
    /// <exception cref="UnitAlreadyExistsException">The new synonym is already used by a unit.</exception>
    /// <exception cref="UnitNotSupportedException">The existing synonym is not a unit of this converter.</exception>
    public void AddSynonym(string existingSynonym, string newSynonym)
    {
        ValidateNewSynonym(newSynonym);
        var factor = Units.FindUnit(existingSynonym) ?? throw new UnitNotSupportedException(existingSynonym);
        factor.AddSynonym(newSynonym);
    }

    /// <summary>
    /// Add a new unit with a set of synonyms.
    /// </summary>
    /// <param name="synonyms">The names of the new unit.</param>
    /// <param name="factor">How many of the new unit make up one base unit.</param>
    /// <exception cref="UnitAlreadyExistsException">One of the names is already used by a unit.</exception>
    public void AddUnit(UnitFactorSynonyms synonyms, double factor)
    {
        ValidateNewSynonym(synonyms);
        Units.Add(synonyms, factor);
    }

    /// <summary>
    /// Add a new unit.
    /// </summary>
    /// <param name="name">The name of the new unit.</param>
    /// <param name="factor">How many of the new unit make up one base unit.</param>
    /// <exception cref="UnitAlreadyExistsException">The name is already used by a unit.</exception>
    public void AddUnit(string name, double factor) => AddUnit((UnitFactorSynonyms)name, factor);

    /// <summary>
    /// Set the unit conversions. The left and right units default to <see cref="UnitFactors.BaseUnit"/>.
    /// </summary>
    /// <param name="conversionFactors">The table of unit factors.</param>
    protected void Instantiate(UnitFactors conversionFactors)
    {
        Units = conversionFactors ?? throw new ArgumentNullException(nameof(conversionFactors));
        UnitLeft = Units.BaseUnit;
        UnitRight = Units.BaseUnit;
    }

    /// <summary>
    /// Set the unit conversions and the initial left and right units.
    /// </summary>
    /// <param name="conversionFactors">The table of unit factors.</param>
    /// <param name="leftUnit">The unit on the left.</param>
    /// <param name="rightUnit">The unit on the right.</param>
    protected void Instantiate(UnitFactors conversionFactors, string leftUnit, string rightUnit)
    {
        Units = conversionFactors ?? throw new ArgumentNullException(nameof(conversionFactors));
        UnitLeft = leftUnit;
        UnitRight = rightUnit;
    }

    /// <summary>
    /// Convert a value between two units of this converter. Converters whose units are not related by a
    /// single factor (temperature scales) override this.
    /// </summary>
    /// <param name="value">The value in <paramref name="startUnit"/>.</param>
    /// <param name="startUnit">The unit of the value.</param>
    /// <param name="endUnit">The unit to convert to.</param>
    /// <returns>The value in <paramref name="endUnit"/>.</returns>
    protected virtual double Convert(double value, string startUnit, string endUnit)
    {
        var start = Units.FindUnit(startUnit) ?? throw new UnitNotSupportedException(startUnit);
        var end = Units.FindUnit(endUnit) ?? throw new UnitNotSupportedException(endUnit);
        if (ReferenceEquals(start, end))
        {
            // The same unit on both sides: return the value exactly instead of dividing and multiplying by a factor.
            return value;
        }

        return (value / Units[start]) * Units[end];
    }

    // Throw if a given unit does not exist.
    private void ValidateSynonymExists(string synonym)
    {
        if (synonym == null)
        {
            throw new ArgumentNullException(nameof(synonym));
        }

        if (Units.FindUnit(synonym) == null)
        {
            throw new UnitNotSupportedException(synonym);
        }
    }

    // Throw if a given unit does exist.
    private void ValidateNewSynonym(UnitFactorSynonyms synonyms)
    {
        if (synonyms == null)
        {
            throw new ArgumentNullException(nameof(synonyms));
        }

        var preExistingUnit = Units.FindUnit(synonyms);
        if (preExistingUnit != null)
        {
            throw new UnitAlreadyExistsException(preExistingUnit.ToString());
        }
    }
}
