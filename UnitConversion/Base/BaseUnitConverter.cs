using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public abstract class BaseUnitConverter : IUnitConverter {
        protected void Instantiate(UnitDictionary conversionFactors, string leftUnit, string rightUnit) {
            Units = conversionFactors;

            UnitLeft = leftUnit;
            UnitRight = rightUnit;
        }

        /// <summary>
        /// Internal Dictionary of units based off ratios from a central unit
        /// </summary>
        public UnitDictionary Units {
            get {
                if (units == null) {
                    throw new NullReferenceException("UnitDictionary is not created");
                }
                return units;
            }
            private set {
                units = value;
            }
        }
        private UnitDictionary units;
        
        /// <summary>
        /// The Unit to convert on the left
        /// </summary>
        public string UnitLeft {
            get {
                if (unitLeft == string.Empty) {
                    throw new InvalidOperationException("UnitLeft has not been set");
                }
                return unitLeft;
            }
            private set {
                ValidateUnit(value);
                unitLeft = value;
            }
        }
        private string unitLeft;

        /// <summary>
        /// The Unit to convert on the right
        /// </summary>
        public string UnitRight {
            get {
                if (unitRight == string.Empty) {
                    throw new InvalidOperationException("UnitRight has not been set");
                }
                return unitRight;
            }
            private set {
                ValidateUnit(value);
                unitRight = value;
            }
        }
        private string unitRight;

        private void ValidateUnit(string unit) {
            if (false == Units.ContainsKey(unit)) {
                throw new UnitNotSupportedException(unit);
            }
        }


        // ** UNIT CONVERSION **

        /// <summary>
        /// Convert the Unit on the Left to the Unit on the Right
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <returns>The converted value</returns>
        public double LeftToRight(double value) {
            return AToB(value, UnitLeft, UnitRight);
        }

        /// <summary>
        /// Convert the Unit on the Right to the Unit on the Left
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <returns>The converted value</returns>
        public double RightToLeft(double value) {
            return AToB(value, UnitRight, UnitLeft);
        }

        private double AToB(double value, string startUnit, string endUnit) {
            var startRatio = Units.First(factor => factor.Key.Equals(startUnit)).Value;
            var endRatio = Units.First(factor => factor.Key.Equals(endUnit)).Value;
            return (value / startRatio) * endRatio;
        }
    }
}
