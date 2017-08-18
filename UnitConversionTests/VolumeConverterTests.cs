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
        public void m3_m3()
        {
            converter = new VolumeConverter("m3", "m3");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m3_km3()
        {
            converter = new VolumeConverter("m³", "km3");
            double valL = 1000*1000*1000;
            double valR = 1;

            // we have a small rounding error here not related to volume units

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }

        [TestMethod()]
        public void m3_cm3()
        {
            converter = new VolumeConverter("m3", "cm3");
            double valL = 1;
            double valR = 1000000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m3_mm3()
        {
            converter = new VolumeConverter("m³", "mm3");
            double valL = 1;
            double valR = 1000 * 1000 * 1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m3_cubicft()
        {
            converter = new VolumeConverter("m3", "ft³");
            double valL = 1;
            double valR = 35.3147;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 4));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 4));
        }

        [TestMethod()]
        public void m3_cubicyd()
        {
            converter = new VolumeConverter("m3", "cubic yard");
            double valL = 1;
            double valR = 1.307951;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }

        [TestMethod()]
        public void m3_cubicin()
        {
            converter = new VolumeConverter("m3", "cubic inch");
            double valL = 1;
            double valR = 61023.744095;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }


        [TestMethod()]
        public void m3_litres()
        {
            converter = new VolumeConverter("m3", "litre");
            double valL = 1;
            double valR = 1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }



        [TestMethod()]
        public void m3_cubicmiles()
        {
            converter = new VolumeConverter("m³", "mi3");
            double valL = 4168181825.44058;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }
    }
}
