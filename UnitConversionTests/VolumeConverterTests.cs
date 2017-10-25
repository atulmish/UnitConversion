using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitConversion;

namespace UnitConversionTests
{
    [TestClass()]
    public class VolumeConverterTests
    {
        VolumeConverter converter = null;

        [TestCleanup()]
        public void Cleanup()
        {
            converter = null;
        }

        [TestMethod()]
        public void m2_m2()
        {
            converter = new AreaConverter("m2", "m2");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m2_km2()
        {
            converter = new AreaConverter("m²", "km2");
            double valL = 1000000;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m2_cm2()
        {
            converter = new AreaConverter("m2", "cm2");
            double valL = 1;
            double valR = 10000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m2_mm2()
        {
            converter = new AreaConverter("m²", "mm2");
            double valL = 1;
            double valR = 1000000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m2_squareft()
        {
            converter = new AreaConverter("m2", "ft²");
            double valL = 1;
            double valR = 10.76391;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }

        [TestMethod()]
        public void m2_squareyd()
        {
            converter = new AreaConverter("m2", "square yard");
            double valL = 1;
            double valR = 1.195990;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }

        [TestMethod()]
        public void m2_squarein()
        {
            converter = new AreaConverter("m2", "square inch");
            double valL = 1;
            double valR = 1550.0031;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 4));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 4));
        }

        [TestMethod()]
        public void m2_ares()
        {
            converter = new AreaConverter("m2", "are");
            double valL = 1;
            double valR = 0.01;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m2_hectares()
        {
            converter = new AreaConverter("m2", "hectare");
            double valL = 1;
            double valR = 0.0001;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m2_sqmiles()
        {
            converter = new AreaConverter("m²", "sq mi");
            double valL = 1000000 * 2.589988110336;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL), 8);
            Assert.AreEqual(valL, converter.RightToLeft(valR), 8);
        }
    }
}
