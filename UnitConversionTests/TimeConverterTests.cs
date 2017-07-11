using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitConversion;

namespace UnitConversionTests
{
    [TestClass()]
    public class TimeConverterTests
    {
        TimeConverter converter = null;

        [TestCleanup()]
        public void Cleanup()
        {
            converter = null;
        }

        [TestMethod()]
        public void s_s()
        {
            converter = new TimeConverter("s", "s");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }
        
        [TestMethod()]
        public void s_min()
        {
            converter = new TimeConverter("s", "minute");
            double valL = 60;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }
        
        [TestMethod()]
        public void s_hour()
        {
            converter = new TimeConverter("sec", "hour");
            double valL = 1800;
            double valR = 0.5;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_day()
        {
            converter = new TimeConverter("second", "day");
            double valL = 3600;
            double valR = 1d/24;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_year()
        {
            converter = new TimeConverter("second", "y");
            double valL = 3600*24;
            double valR = 1d/365;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }
    }
}
