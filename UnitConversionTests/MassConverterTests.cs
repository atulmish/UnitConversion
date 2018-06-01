using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests {
    [TestClass()]
    public class MassConverterTests {
        MassConverter converter = null;
        
        [TestCleanup()]
        public void Cleanup() {
            converter = null;
        }

        [TestMethod()]
        public void kg_kg() {
            converter = new MassConverter("kg", "kg");
            double valL = 1;
            double valR = 1;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void kg_g() {
            converter = new MassConverter("kg", "gram");
            double valL = 1;
            double valR = 1000;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void kg_lb() {
            converter = new MassConverter("kg", "lbs");
            double valL = 1;
            double valR = 2.20462;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 5));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 5));
        }

        [TestMethod()]
        public void kg_st() {
            converter = new MassConverter("kg", "stone");
            double valL = 1;
            double valR = 0.157473;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 6));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 6));
        }

        [TestMethod()]
        public void kg_oz() {
            converter = new MassConverter("kg", "ounce");
            double valL = 1;
            double valR = 35.274;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 3));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 3));
        }

        [TestMethod()]
        public void kg_quintal()
        {
            converter = new MassConverter("quintal", "kg");
            double valL = 1;
            double valR = 100;

            Assert.AreEqual(valR, converter.LeftToRight(valL));
            Assert.AreEqual(valL, converter.RightToLeft(valR));
        }

        [TestMethod()]
        public void kg_uston()
        {
            converter = new MassConverter("us ton", "kg");
            double valL = 1;
            double valR = 907.18582;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 5));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 5));
        }

        [TestMethod()]
        public void kg_imperialton()
        {
            converter = new MassConverter("imperial ton", "kg");
            double valL = 1;
            double valR = 1016.04642;

            Assert.AreEqual(valR, converter.LeftToRight(valL, 5));
            Assert.AreEqual(valL, converter.RightToLeft(valR, 5));
        }
    }
}
