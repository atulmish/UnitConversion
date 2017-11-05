using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitConversion.Base {
    public abstract class BaseUnitConverter : IUnitConverter {
        /// <summary>
        /// Set Unit conversions. Left/Right conversion will default to UnitFactors.BaseUnit
        /// </summary>
        protected void Instantiate(UnitFactors conversionFactors) {
            Units = conversionFactors;

            UnitLeft = Units.BaseUnit;
            unitRight = units.BaseUnit;
        }

        /// <summary>
        /// Set Unit conversions and initial Left/Right conversion
        /// </summary>
        protected void Instantiate(UnitFactors conversionFactors, string leftUnit, string rightUnit) {
            Units = conversionFactors;

            UnitLeft = leftUnit;
            UnitRight = rightUnit;
        }


        // ** CONFIGURATION **

        /// <summary>
        /// Internal Dictionary of Unit Factors
        /// </summary>
        protected UnitFactors Units {
            get {
                if (units == null) {
                    throw new NullReferenceException("UnitDictionary is not created");
                }
                return units;
            }
            private set => units = value;
        }
        private UnitFactors units;
        
        /// <summary>
        /// The Unit to convert on the left
        /// </summary>
        public string UnitLeft {
            get {
                if (string.IsNullOrWhiteSpace(unitLeft)) {
                    throw new InvalidOperationException("UnitLeft has not been set");
                }
                return unitLeft;
            }
            set {
                ValidateSynonymExists(value);
                unitLeft = value;
            }
        }
        private string unitLeft;

        /// <summary>
        /// The Unit to convert on the right
        /// </summary>
        public string UnitRight {
            get {
                if (string.IsNullOrWhiteSpace(unitRight)) {
                    throw new InvalidOperationException("UnitRight has not been set");
                }
                return unitRight;
            }
            set {
                ValidateSynonymExists(value);
                unitRight = value;
            }
        }
        private string unitRight;


        // ** CONVERSION **

        /// <summary>
        /// Convert the Unit on the Left to the Unit on the Right
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <returns>The converted value</returns>
        public double LeftToRight(double value) {
            return AToB(value, UnitLeft, UnitRight);
        }

        /// <summary>
        /// Convert the Unit on the Left to the Unit on the Right
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <param name="decimals">how many decimal places to round to</param>
        /// <returns>The converted value</returns>
        public double LeftToRight(double value, int decimals) {
            return Math.Round(LeftToRight(value), decimals);
        }

        /// <summary>
        /// Convert the Unit on the Right to the Unit on the Left
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <returns>The converted value</returns>
        public double RightToLeft(double value) {
            return AToB(value, UnitRight, UnitLeft);
        }

        /// <summary>
        /// Convert the Unit on the Right to the Unit on the Left
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <param name="decimals">how many decimal places to round to</param>
        /// <returns>The converted value</returns>
        public double RightToLeft(double value, int decimals) {
            return Math.Round(RightToLeft(value), decimals);
        }

        private double AToB(double value, string startUnit, string endUnit) {
            var startFactor = Units.FindFactor(startUnit);
            var endFactor = Units.FindFactor(endUnit);
            return (value / startFactor) * endFactor;
        }


        // ** UNITS **

        /// <summary>
        /// Get an enumerable of all the UnitFactorKeys, which contain synonyms for each unit
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnitFactorSynonyms> SupportedUnits {
            get => Units.Keys.AsEnumerable();
        }

        /// <summary>
        /// Add a new synonym to an existing unit's list of names
        /// </summary>
        /// <param name="existingSynonym">Some synonym from an existing unit</param>
        /// <param name="newSynonym">New synonym to append to the unit</param>
        public void AddSynonym(string existingSynonym, string newSynonym) {
            ValidateNewSynonym(newSynonym);
            var factor = Units.FindUnit(existingSynonym);
            factor.AddSynonym(newSynonym);
        }

        /// <summary>
        /// Add a new unit with a new set of synonyms
        /// </summary>
        /// <param name="synonyms">Object of synonyms</param>
        /// <param name="factor"></param>
        public void AddUnit(UnitFactorSynonyms synonyms, double factor) {
            ValidateNewSynonym(synonyms);
            Units.Add(synonyms, factor);
        }

        /// <summary>
        /// Add a new unit
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factor"></param>
        public void AddUnit(string name, double factor) {
            AddUnit((UnitFactorSynonyms)name, factor);
        }


        // ** VALIDATION **

        // Throw if a given unit does not exist
        private void ValidateSynonymExists(string synonym) {
            if (Units.FindUnit(synonym) == null) {
                throw new UnitNotSupportedException(synonym);
            }
        }

        // Throw if a given unit does exist
        private void ValidateNewSynonym(UnitFactorSynonyms synonyms) {
            var preExistingUnit = Units.FindUnit(synonyms);
            if (preExistingUnit != null) {
                throw new UnitAlreadyExistsException(preExistingUnit.ToString());
            }
        }
    }
}
