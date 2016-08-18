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
        public void RightToLeftTest() {
            double input;
            double expected;

            input = 15;
            expected = 10;
            Assert.AreEqual(expected, converter.RightToLeft(input));
        }
    }

    class TestConverter : BaseUnitConverter {
        public TestConverter() {
            var units = new UnitDictionary("mid") {
                { "mid", 1 },
                { "left", 2 },
                { "right", 3 },
            };
            Instantiate(units, "left", "right");
        }
    }
}
