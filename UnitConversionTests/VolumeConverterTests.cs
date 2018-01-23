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
        public void l_l()
        {
            converter = new VolumeConverter("l", "l");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_m3()
        {
            converter = new VolumeConverter("l", "m3");
            double valL = 1;
            double valR = 0.001;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_cm3()
        {
            converter = new VolumeConverter("l", "cm3");
            double valL = 1;
            double valR = 1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_mm3()
        {
            converter = new VolumeConverter("l", "mm3");
            double valL = 1;
            double valR = 1000*1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_ft3()
        {
            converter = new VolumeConverter("l", "ft3");
            double valL = 1;
            double valR = 0.0353147;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_in3()
        {
            converter = new VolumeConverter("l", "in3");
            double valL = 1;
            double valR = 61.0237;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_imperialpint()
        {
            converter = new VolumeConverter("l", "imperial pint");
            double valL = 1;
            double valR = 1.75975;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_imperialgallon()
        {
            converter = new VolumeConverter("l", "imperial gallon");
            double valL = 1;
            double valR = 0.219969;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_imperialquart()
        {
            converter = new VolumeConverter("l", "imperial quart");
            double valL = 1;
            double valR = 0.879877;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_uspint()
        {
            converter = new VolumeConverter("l", "US pint");
            double valL = 1;
            double valR = 2.11337643513819;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_usgallon()
        {
            converter = new VolumeConverter("l", "US gallon");
            double valL = 1;
            double valR = 0.264172;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void l_usquart()
        {
            converter = new VolumeConverter("l", "US quart");
            double valL = 1;
            double valR = 2.11338;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }
    }
}
