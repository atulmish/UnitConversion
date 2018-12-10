using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitConversion;

namespace UnitConversionTests
{
    [TestClass()]
    public class TemperatureConverterTests
    {
        TemperatureConverter converter = null;

        [TestCleanup()]
        public void Cleanup()
        {
            converter = null;
        }
        [TestMethod()]
        public void Celsius_Fahrenheit()
        {
            converter = new TemperatureConverter("celsius", "fahrenheit");
            double valL = 1;
            double valR = 33.800;

            Assert.AreEqual(valR, converter.LeftToRight(valL,3));
            Assert.AreEqual(valL, converter.RightToLeft(valR,3));
        }
        [TestMethod()]
        public void Kelvin_Fahrenheit()
        {
            converter = new TemperatureConverter("kelvin", "fahrenheit");
            double valL = 1;
            double valR = -457.87;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 3));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 3));
        }
        [TestMethod()]
        public void Fahrenheit_Celsius()
        {
            converter = new TemperatureConverter("fahrenheit", "celsius");
            double valL = 1;
            double valR = -17.222;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 3));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 3));
        }
        [TestMethod()]
        public void Celsius_Kelvin()
        {
            converter = new TemperatureConverter("celsius", "kelvin");
            double valL = 1;
            double valR = 274.150;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 3));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 3));
        }
        [TestMethod()]
        public void Kelvin_Celsius()
        {
            converter = new TemperatureConverter("kelvin", "celsius");
            double valL = 1;
            double valR = -272.150;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 3));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 3));
        }
        [TestMethod()]
        public void Fahrenheit_Kelvin()
        {
            converter = new TemperatureConverter("fahrenheit", "kelvin");
            double valL = 1;
            double valR = 255.928;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 3));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 3));
        }
    }
}
