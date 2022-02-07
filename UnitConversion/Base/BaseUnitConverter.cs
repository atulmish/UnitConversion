﻿//-----------------------------------------------------------------------
// <copyright file="BaseUnitConverter.cs" company="George Kampolis">
//     Copyright (c) George Kampolis. All rights reserved.
//     Licensed under the MIT License, Version 2.0. See LICENSE.md in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitConversion.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Base functionality for the rest of the project.
    /// </summary>
    public abstract class BaseUnitConverter : IUnitConverter
    {
        /// <summary>
        /// Set Unit conversions. Left/Right conversion will default to UnitFactors.BaseUnit
        /// </summary>
        protected void Instantiate(UnitFactors conversionFactors)
        {
            Units = conversionFactors;
            
            Instantiate(conversionFactors, Units.BaseUnit, Units.BaseUnit);
        }

        /// <summary>
        /// Set Unit conversions and initial Left/Right conversion
        /// </summary>
        protected void Instantiate(UnitFactors conversionFactors, string leftUnit, string rightUnit)
        {
            Units = conversionFactors;
            
            UnitLeft = leftUnit;
            UnitRight = rightUnit;
            
            UpdateConversionFactors();
        }

        private void UpdateConversionFactors()
        {
            leftToRight = Units.FindFactor(unitRight) / Units.FindFactor(unitLeft);
            rightToLeft = Units.FindFactor(unitLeft) / Units.FindFactor(unitRight);
        }


        // ** CONFIGURATION **

        /// <summary>
        /// Internal Dictionary of Unit Factors
        /// </summary>
        protected UnitFactors Units
        {
            get
            {
                if (units == null)
                {
                    throw new NullReferenceException("UnitDictionary is not created");
                }
                return units;
            }
            private set
            {
                units = value;
            }
        }
        private UnitFactors units;
        
        /// <summary>
        /// The Unit to convert on the left
        /// </summary>
        public string UnitLeft {
            get {
                if (unitLeft == string.Empty)
                {
                    throw new InvalidOperationException("UnitLeft has not been set");
                }
                return unitLeft;
            }
            set
            {
                ValidateSynonymExists(value);
                unitLeft = value;
                
                if(unitRight != null)
                    UpdateConversionFactors();
            }
        }
        private string unitLeft;

        /// <summary>
        /// The Unit to convert on the right
        /// </summary>
        public string UnitRight
        {
            get
            {
                if (unitRight == string.Empty)
                {
                    throw new InvalidOperationException("UnitRight has not been set");
                }
                return unitRight;
            }
            set
            {
                ValidateSynonymExists(value);
                unitRight = value;
                
                if(unitLeft != null)
                    UpdateConversionFactors();
            }
        }
        private string unitRight;

        private double leftToRight;
        private double rightToLeft;

        // ** CONVERSION **

        /// <summary>
        /// Convert the Unit on the Left to the Unit on the Right
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <returns>The converted value</returns>
        public double LeftToRight(double value)
        {
            if (units.BaseUnit == "celsius")
                return TemperatureHelper.AToB(value, UnitLeft, UnitRight);

            var result = value * leftToRight;
            return result.CheckCloseEnoughValue();
        }

        /// <summary>
        /// Convert the Unit on the Left to the Unit on the Right
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <param name="decimals">how many decimal places to round to</param>
        /// <returns>The converted value</returns>
        public double LeftToRight(double value, int decimals)
        {
            return Math.Round(LeftToRight(value), decimals);
        }

        /// <summary>
        /// Convert the Unit on the Right to the Unit on the Left
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <returns>The converted value</returns>
        public double RightToLeft(double value)
        {
            if (units.BaseUnit == "celsius")
                return TemperatureHelper.AToB(value, UnitRight, UnitLeft);

            var result = value * rightToLeft;
            return result.CheckCloseEnoughValue();
        }

        /// <summary>
        /// Convert the Unit on the Right to the Unit on the Left
        /// </summary>
        /// <param name="value">the Unit's value</param>
        /// <param name="decimals">how many decimal places to round to</param>
        /// <returns>The converted value</returns>
        public double RightToLeft(double value, int decimals)
        {
            return Math.Round(RightToLeft(value), decimals);
        }
        
        // ** UNITS **

        /// <summary>
        /// Get an enumerable of all the UnitFactorKeys, which contain synonyms for each unit
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UnitFactorSynonyms> SupportedUnits
        {
            get
            {
                return Units.Keys.AsEnumerable();
            }
        }

        /// <summary>
        /// Add a new synonym to an existing unit's list of names
        /// </summary>
        /// <param name="existingSynonym">Some synonym from an existing unit</param>
        /// <param name="newSynonym">New synonym to append to the unit</param>
        public void AddSynonym(string existingSynonym, string newSynonym)
        {
            ValidateNewSynonym(newSynonym);
            var factor = Units.FindUnit(existingSynonym);
            factor.AddSynonym(newSynonym);
        }

        /// <summary>
        /// Add a new unit with a new set of synonyms
        /// </summary>
        /// <param name="synonyms">Object of synonyms</param>
        /// <param name="factor"></param>
        public void AddUnit(UnitFactorSynonyms synonyms, double factor)
        {
            ValidateNewSynonym(synonyms);
            Units.Add(synonyms, factor);
        }

        /// <summary>
        /// Add a new unit
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factor"></param>
        public void AddUnit(string name, double factor)
        {
            AddUnit((UnitFactorSynonyms)name, factor);
        }


        // ** VALIDATION **

        // Throw if a given unit does not exist
        private void ValidateSynonymExists(string synonym)
        {
            if (null == Units.FindUnit(synonym))
            {
                throw new UnitNotSupportedException(synonym);
            }
        }

        // Throw if a given unit does exist
        private void ValidateNewSynonym(UnitFactorSynonyms synonyms)
        {
            var preExistingUnit = Units.FindUnit(synonyms);
            if (preExistingUnit != null)
            {
                throw new UnitAlreadyExistsException(preExistingUnit.ToString());
            }
        }
    }
}
