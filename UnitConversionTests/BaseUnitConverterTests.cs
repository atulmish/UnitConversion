using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests;

[TestClass]
public class BaseUnitConverterTests
{
    private TestConverter converter = null!;

    [TestInitialize]
    public void Initialize() => converter = new TestConverter();

    [TestMethod]
    public void LeftToRight()
    {
        Assert.AreEqual(22.5, converter.LeftToRight(15));
    }

    [TestMethod]
    public void LeftToRightRounds()
    {
        Assert.AreEqual(23.5, converter.LeftToRight(15.678, 1)); // 23.517
    }

    [TestMethod]
    public void RightToLeft()
    {
        Assert.AreEqual(10, converter.RightToLeft(15));
    }

    [TestMethod]
    public void RightToLeftRounds()
    {
        Assert.AreEqual(10.5, converter.RightToLeft(15.678, 1)); // 10.452
    }

    [TestMethod]
    public void UnitsMatchIgnoringCase()
    {
        converter.UnitLeft = "L";
        Assert.AreEqual(10.5, converter.RightToLeft(15.678, 1));
    }

    [TestMethod]
    public void AddSynonym()
    {
        Assert.ThrowsExactly<UnitNotSupportedException>(() => converter.UnitRight = "R");
        converter.AddSynonym("right", "R");
        converter.UnitRight = "R";
        converter.AddSynonym("R", "john cena");
        converter.UnitRight = "john cena";
    }

    [TestMethod]
    public void AddSynonymToAnUnknownUnitIsRejected()
    {
        Assert.ThrowsExactly<UnitNotSupportedException>(() => converter.AddSynonym("nope", "other"));
    }

    [TestMethod]
    public void AddUnit()
    {
        Assert.ThrowsExactly<UnitNotSupportedException>(() => converter.UnitRight = "purple");
        converter.AddUnit("purple", 10);
        converter.UnitLeft = "mid";
        converter.UnitRight = "purple";
        Assert.AreEqual(11, converter.LeftToRight(1.1));
    }

    [TestMethod]
    public void AddUnitThatExistsIsRejected()
    {
        converter.AddSynonym("right", "purple");
        Assert.ThrowsExactly<UnitAlreadyExistsException>(() => converter.AddUnit("purple", 10));
    }

    [TestMethod]
    public void AddUnitIgnoresCaseWhenLookingForDuplicates()
    {
        Assert.ThrowsExactly<UnitAlreadyExistsException>(() => converter.AddUnit("MID", 10));
    }

    [TestMethod]
    public void SupportedUnits()
    {
        Assert.IsTrue(converter.SupportedUnits.Any(s => s.Synonyms.Contains("left")));
        Assert.IsFalse(converter.SupportedUnits.Any(s => s.Synonyms.Contains("not_a_unit")));
    }

    [TestMethod]
    public void NullArgumentsAreRejected()
    {
        Assert.ThrowsExactly<System.ArgumentNullException>(() => converter.UnitLeft = null!);
        Assert.ThrowsExactly<System.ArgumentNullException>(() => converter.UnitRight = null!);
        Assert.ThrowsExactly<System.ArgumentNullException>(() => converter.AddUnit((UnitFactorSynonyms)null!, 1));
        Assert.ThrowsExactly<System.ArgumentNullException>(() => new UnitFactors(null!));
        Assert.ThrowsExactly<System.ArgumentNullException>(() => new UnitFactorSynonyms(null!));
    }

    [TestMethod]
    public void AConverterThatWasNeverInstantiatedExplainsWhy()
    {
        var empty = new NeverInstantiatedConverter();

        Assert.ThrowsExactly<System.InvalidOperationException>(() => empty.UnitLeft.ToString());
        Assert.ThrowsExactly<System.InvalidOperationException>(() => empty.UnitRight.ToString());
        Assert.ThrowsExactly<System.InvalidOperationException>(() => empty.SupportedUnits.ToList());
    }

    [TestMethod]
    public void SynonymsPrintAsAList()
    {
        Assert.AreEqual("left, l", new UnitFactorSynonyms("left", "l").ToString());
    }

    [TestMethod]
    public void MatchingIsNotAffectedByTheCurrentCulture()
    {
        var previous = System.Globalization.CultureInfo.CurrentCulture;
        try
        {
            // In Turkish, "I".ToLower() is a dotless i, which breaks culture-sensitive comparisons.
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            var distance = new DistanceConverter("IN", "MM");

            Assert.AreEqual(25.4, distance.LeftToRight(1), 1e-12);
        }
        finally
        {
            System.Globalization.CultureInfo.CurrentCulture = previous;
        }
    }
}

internal class TestConverter : BaseUnitConverter
{
    public TestConverter()
    {
        var units = new UnitFactors("mid")
        {
            { "mid", 1 },
            { new UnitFactorSynonyms("left", "l"), 2 },
            { "right", 3 },
        };
        Instantiate(units, "left", "right");
    }
}

internal class NeverInstantiatedConverter : BaseUnitConverter
{
}
