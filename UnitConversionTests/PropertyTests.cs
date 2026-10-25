using System;
using System.Linq;
using FsCheck;
using FsCheck.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests;

/// <summary>
/// Property-based tests: instead of fixed examples, FsCheck generates hundreds of random units and values for
/// every converter and checks laws that must hold for any input. A failure prints the seed that reproduces it.
/// </summary>
[TestClass]
public class PropertyTests
{
    private const int Tests = 300;

    // Values from 1e-6 to 1e15 in both signs, so both tiny and huge magnitudes are exercised.
    private static readonly Gen<double> Values =
        from mantissa in Gen.Choose(1, 999_999)
        from exponent in Gen.Choose(-6, 9)
        from negative in Gen.Elements(true, false)
        select (negative ? -1d : 1d) * mantissa * Math.Pow(10, exponent);

    public static System.Collections.Generic.IEnumerable<object[]> Converters => ConverterFactory.AllConverters();

    private static string[] UnitNames(Type type) =>
        ConverterFactory.CreateDefault(type).SupportedUnits.SelectMany(u => u.Synonyms).ToArray();

    private static BaseUnitConverter Make(Type type, string from, string to) =>
        (BaseUnitConverter)Activator.CreateInstance(type, from, to)!;

    private static void RunProperty(Property property) =>
        Check.One(Config.QuickThrowOnFailure.WithMaxTest(Tests), property);

    private static bool Close(double expected, double actual, double scale) =>
        Math.Abs(expected - actual) <= scale * 1e-9;

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void ConvertingThereAndBackReturnsTheStartingValue(Type type)
    {
        var names = Gen.Elements(UnitNames(type));
        var inputs = from left in names from right in names from value in Values select (left, right, value);

        RunProperty(Prop.ForAll(inputs.ToArbitrary(), input =>
        {
            var converter = Make(type, input.left, input.right);
            var there = converter.LeftToRight(input.value);
            var back = converter.RightToLeft(there);

            return double.IsFinite(there) && Close(input.value, back, Math.Max(Math.Abs(input.value), Math.Abs(there)));
        }));
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void ABiggerValueNeverConvertsToASmallerOne(Type type)
    {
        var names = Gen.Elements(UnitNames(type));
        var inputs = from left in names from right in names from a in Values from b in Values select (left, right, a, b);

        RunProperty(Prop.ForAll(inputs.ToArbitrary(), input =>
        {
            var converter = Make(type, input.left, input.right);
            var (small, large) = input.a <= input.b ? (input.a, input.b) : (input.b, input.a);

            return converter.LeftToRight(small) <= converter.LeftToRight(large);
        }));
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void ConvertingAUnitToItselfChangesNothing(Type type)
    {
        var inputs = from name in Gen.Elements(UnitNames(type)) from value in Values select (name, value);

        RunProperty(Prop.ForAll(inputs.ToArbitrary(), input =>
            Make(type, input.name, input.name).LeftToRight(input.value) == input.value));
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void ConversionsScaleLinearlyAndComposeThroughAnyUnit(Type type)
    {
        if (type == typeof(TemperatureConverter))
        {
            return; // temperature scales are offset, not proportional
        }

        var names = Gen.Elements(UnitNames(type));
        var inputs =
            from a in names
            from b in names
            from c in names
            from value in Values
            from factor in Gen.Elements(2d, 3d, 0.5, 10d, 1000d)
            select (a, b, c, value, factor);

        RunProperty(Prop.ForAll(inputs.ToArbitrary(), input =>
        {
            var ab = Make(type, input.a, input.b);
            var bc = Make(type, input.b, input.c);
            var ac = Make(type, input.a, input.c);

            var scaled = ab.LeftToRight(input.value * input.factor);
            var scaledAfter = ab.LeftToRight(input.value) * input.factor;
            var composed = bc.LeftToRight(ab.LeftToRight(input.value));
            var direct = ac.LeftToRight(input.value);

            return Close(scaledAfter, scaled, Math.Abs(scaledAfter)) && Close(direct, composed, Math.Abs(direct));
        }));
    }

    [TestMethod]
    [DynamicData(nameof(Converters))]
    public void UnitNamesAreAcceptedWhateverTheirCase(Type type)
    {
        var inputs =
            from name in Gen.Elements(UnitNames(type))
            from flips in Gen.ListOf(Gen.Elements(true, false), name.Length)
            select (name, flips: flips.ToArray());

        RunProperty(Prop.ForAll(inputs.ToArbitrary(), input =>
        {
            var cased = new string(input.name.Select((c, i) => input.flips[i] ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c)).ToArray());
            var converter = ConverterFactory.CreateDefault(type);
            converter.UnitLeft = cased;

            return true; // UnitLeft throws UnitNotSupportedException when the name is not accepted
        }));
    }

    [TestMethod]
    public void ArbitraryTextIsRejectedAsAUnitNameWithoutAnyOtherFailure()
    {
        RunProperty(Prop.ForAll(ArbMap.Default.ArbFor<string>(), text =>
        {
            var converter = new MassConverter();
            try
            {
                converter.UnitLeft = text ?? string.Empty;
                return true; // the text happened to be a unit name
            }
            catch (UnitNotSupportedException)
            {
                return true;
            }
        }));
    }

    [TestMethod]
    public void SnappingNeverMovesAGenuineValueAndFixesNoise()
    {
        RunProperty(Prop.ForAll(Values.ToArbitrary(), value =>
        {
            var snapped = value.CheckCloseEnoughValue();

            // A value is either unchanged or a whole number within 1e-12 (relative) of it.
            return snapped == value || (snapped == Math.Round(value) && Math.Abs(snapped - value) <= Math.Abs(snapped) * 1e-12);
        }));
    }
}
