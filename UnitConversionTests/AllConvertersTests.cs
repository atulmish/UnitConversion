using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests;

/// <summary>Properties that must hold for every converter in the library.</summary>
[TestClass]
public class AllConvertersTests
{
    public static IEnumerable<object[]> Converters => ConverterFactory.AllConverters();

    [TestMethod]
    public void TheLibraryShipsTheExpectedConverters()
    {
        var names = ConverterFactory.AllConverterTypes().Select(t => t.Name).ToArray();

        CollectionAssert.AreEqual(
            new[]
            {
                "AngleConverter", "AreaConverter", "DigitalStorageConverter", "DistanceConverter", "EnergyConverter",
                "MassConverter", "PowerConverter", "PressureConverter", "SpeedConverter", "TemperatureConverter",
                "TimeConverter", "VolumeConverter",
            },
            names);
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void EveryUnitConvertsToEveryOtherUnitAndBack(Type type)
    {
        var converter = ConverterFactory.CreateDefault(type);
        var units = converter.SupportedUnits.Select(u => u.Synonyms.First()).ToList();

        foreach (var from in units)
        {
            foreach (var to in units)
            {
                converter.UnitLeft = from;
                converter.UnitRight = to;
                const double value = 123.456;
                var there = converter.LeftToRight(value);
                var back = converter.RightToLeft(there);

                Assert.IsTrue(
                    double.IsFinite(there),
                    $"{type.Name}: {from} to {to} is not finite");
                Assert.IsTrue(
                    System.Math.Abs(back - value) <= System.Math.Abs(value) * 1e-9,
                    $"{type.Name}: {value} {from} -> {to} -> {from} gave {back:R}");
            }
        }
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void ConvertingAUnitToItselfChangesNothing(Type type)
    {
        var converter = ConverterFactory.CreateDefault(type);

        foreach (var unit in converter.SupportedUnits.Select(u => u.Synonyms.First()))
        {
            converter.UnitLeft = unit;
            converter.UnitRight = unit;
            Assert.AreEqual(42.5, converter.LeftToRight(42.5), $"{type.Name}: {unit}");
        }
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void EverySynonymIsAcceptedInAnyCase(Type type)
    {
        var converter = ConverterFactory.CreateDefault(type);

        foreach (var synonym in converter.SupportedUnits.SelectMany(u => u.Synonyms))
        {
            converter.UnitLeft = synonym;
            converter.UnitLeft = synonym.ToUpperInvariant();
            converter.UnitLeft = synonym.ToLowerInvariant();
        }
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void NoSynonymBelongsToTwoUnits(Type type)
    {
        var converter = ConverterFactory.CreateDefault(type);
        var owners = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var unit in converter.SupportedUnits)
        {
            foreach (var synonym in unit.Synonyms)
            {
                if (owners.TryGetValue(synonym, out var owner) && owner != unit.ToString())
                {
                    Assert.Fail($"{type.Name}: '{synonym}' names both [{owner}] and [{unit}]");
                }

                owners[synonym] = unit.ToString();
            }
        }
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void ConvertersStartAtTheBaseUnit(Type type)
    {
        var converter = ConverterFactory.CreateDefault(type);

        Assert.AreEqual(converter.UnitLeft, converter.UnitRight);
        Assert.AreEqual(1d, converter.LeftToRight(1d));
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void CustomUnitsDoNotLeakBetweenInstances(Type type)
    {
        var first = ConverterFactory.CreateDefault(type);
        first.AddUnit("zzz-custom-unit", 2);
        var second = ConverterFactory.CreateDefault(type);

        Assert.IsTrue(first.SupportedUnits.Any(u => u.HasName("zzz-custom-unit")));
        Assert.IsFalse(second.SupportedUnits.Any(u => u.HasName("zzz-custom-unit")));
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void AnUnknownUnitIsRejectedByEveryEntryPoint(Type type)
    {
        var converter = ConverterFactory.CreateDefault(type);
        Assert.ThrowsExactly<UnitNotSupportedException>(() => converter.UnitLeft = "not-a-unit");
        Assert.ThrowsExactly<UnitNotSupportedException>(() => converter.UnitRight = "not-a-unit");
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void AnUnknownUnitInTheConstructorSurfacesTheUnitNotSupportedException(Type type)
    {
        try
        {
            Activator.CreateInstance(type, "not-a-unit", "not-a-unit");
            Assert.Fail("expected an exception");
        }
        catch (System.Reflection.TargetInvocationException ex)
        {
            Assert.IsInstanceOfType<UnitNotSupportedException>(ex.InnerException);
        }
    }
}

internal static class UnitFactorSynonymsExtensions
{
    public static bool HasName(this UnitFactorSynonyms unit, string name) =>
        unit.Synonyms.Contains(name, StringComparer.OrdinalIgnoreCase);
}
