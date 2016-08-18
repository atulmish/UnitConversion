using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MSTest;
using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests {
    [TestClass()]
    public class BaseUnitConverterTests {
        TestConverter converter = null;

        [TestInitialize()]
        public void Initialize() {
            converter = new TestConverter();
        }
        [TestCleanup()]
        public void Cleanup() {
            converter = null;
        }

        [TestMethod()]
        public void LeftToRightTest() {
            double input;
            double expected;

            input = 15;
            expected = 22.5;
            Assert.AreEqual(expected, converter.LeftToRight(input));
        }

        [TestMethod()]
        public void LeftToRightRoundingTest() {
            double input;
            double expected;

            input = 15.678;
            expected = 23.5; //23.517
            Assert.AreEqual(expected, converter.LeftToRight(input, 1));
        }

        [TestMethod()]
        public void RightToLeftTest() {
            double input;
            double expected;

            input = 15;
            expected = 10;
            Assert.AreEqual(expected, converter.RightToLeft(input));
        }

        [TestMethod()]
        public void RightToLeftRoundingTest() {
            double input;
            double expected;

            input = 15.678;
            expected = 10.5; //10.452
            Assert.AreEqual(expected, converter.RightToLeft(input, 1));
        }
    }

    class TestConverter : BaseUnitConverter {
        public TestConverter() {
            var units = new UnitFactors("mid") {
                { "mid", 1 },
                { "left", 2 },
                { "right", 3 },
            };
            Instantiate(units, "left", "right");
        }
    }
}
