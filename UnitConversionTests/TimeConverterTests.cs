using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitConversion;

namespace UnitConversionTests {
    [TestClass()]
    public class TimeConverterTests {
        TimeConverter converter = null;

        [TestCleanup()]
        public void Cleanup() {
            converter = null;
        }

        [TestMethod()]
        public void s_s() {
            converter = new TimeConverter("s", "s");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_ds() {
            converter = new TimeConverter("s", "ds");
            double valL = 1;
            double valR = 10;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_cs() {
            converter = new TimeConverter("s", "cs");
            double valL = 1;
            double valR = 100;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_ms() {
            converter = new TimeConverter("s", "ms");
            double valL = 1;
            double valR = 1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_us() {
            converter = new TimeConverter("s", "us");
            double valL = 1;
            double valR = 1_000_000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_ns() {
            converter = new TimeConverter("s", "ns");
            double valL = 1;
            double valR = 1_000_000_000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_min() {
            converter = new TimeConverter("s", "minute");
            double valL = 60;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_hour() {
            converter = new TimeConverter("sec", "hour");
            double valL = 1800;
            double valR = 0.5;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_day() {
            converter = new TimeConverter("second", "day");
            double valL = 3600;
            double valR = 1d / 24;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_year() {
            converter = new TimeConverter("second", "y");
            double valL = 3600 * 24 * 365;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void s_leap_year() {
            converter = new TimeConverter("second", "leap year");
            double valL = 3600 * 24 * 366;
            double valR = 1;
            
            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }
    }
}
