using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests {
    [TestClass()]
    public class DistanceConverterTests {
        DistanceConverter converter = null;
        
        [TestCleanup()]
        public void Cleanup() {
            converter = null;
        }

        [TestMethod()]
        public void m_m() {
            converter = new DistanceConverter("m", "m");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m_km() {
            converter = new DistanceConverter("m", "km");
            double valL = 1000;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m_cm() {
            converter = new DistanceConverter("m", "cm");
            double valL = 1;
            double valR = 100;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m_mm() {
            converter = new DistanceConverter("m", "mm");
            double valL = 1;
            double valR = 1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void m_ft() {
            converter = new DistanceConverter("m", "feet");
            double valL = 1;
            double valR = 3.28084;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 5));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 5));
        }

        [TestMethod()]
        public void m_yd() {
            converter = new DistanceConverter("m", "yard");
            double valL = 1;
            double valR = 1.09361;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 5));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 5));
        }

        [TestMethod()]
        public void m_in() {
            converter = new DistanceConverter("m", "inch");
            double valL = 1;
            double valR = 39.3701;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 4));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 4));
        }
    }
}
