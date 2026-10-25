using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion.Base;

namespace UnitConversionTests;

[TestClass]
public class ExtensionMethodsTests
{
    [TestMethod]
    [DataRow(2.9999999999999996, 3.0)]
    [DataRow(3.0000000000000004, 3.0)]
    [DataRow(-2.9999999999999996, -3.0)]
    [DataRow(100.00000000000001, 100.0)]
    [DataRow(1234567.0000000002, 1234567.0)]
    public void FloatingPointNoiseIsSnappedToTheWholeNumber(double value, double expected)
    {
        Assert.AreEqual(expected, value.CheckCloseEnoughValue());
    }

    [TestMethod]
    [DataRow(0.999995)]
    [DataRow(12.999995)]
    [DataRow(0.99999)]
    [DataRow(2.5)]
    [DataRow(1e-13)]
    [DataRow(-1e-13)]
    [DataRow(1e-300)]
    [DataRow(123456.789)]
    public void GenuineValuesAreNeverChanged(double value)
    {
        // The previous implementation rounded 0.999995 up to 1 and 12.999995 up to 13.
        Assert.AreEqual(value, value.CheckCloseEnoughValue());
    }

    [TestMethod]
    public void ZeroNaNAndInfinityPassThrough()
    {
        Assert.AreEqual(0d, 0d.CheckCloseEnoughValue());
        Assert.IsTrue(double.IsNaN(double.NaN.CheckCloseEnoughValue()));
        Assert.AreEqual(double.PositiveInfinity, double.PositiveInfinity.CheckCloseEnoughValue());
        Assert.AreEqual(double.NegativeInfinity, double.NegativeInfinity.CheckCloseEnoughValue());
    }
}
