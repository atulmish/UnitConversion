//-----------------------------------------------------------------------
// <copyright file="DistanceConverter.cs" company="George Kampolis">
//     Copyright (c) George Kampolis. All rights reserved.
//     Licensed under the MIT License, Version 2.0. See LICENSE.md in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------


namespace UnitConversion
{
    using System;
    using UnitConversion.Base;

    /// <summary>
    /// Converts between distance units.
    /// </summary>
    public class DistanceConverter : BaseUnitConverter
    {
        UnitFactors units = new UnitFactors("m")
        {
            { new UnitFactorSynonyms("m", "metre"), 1 },
            { new UnitFactorSynonyms("km", "kilometre"), 0.001 },
            { new UnitFactorSynonyms("cm", "centimetre"), 100 },
            { new UnitFactorSynonyms("mm", "millimetre"), 1000 },
            { new UnitFactorSynonyms("ft", "foot", "feet"), 1250d / 381 },
            { new UnitFactorSynonyms("yd", "yard"), 1250d / 1143 },
            { "mile", 125d / 201168 },
            { new UnitFactorSynonyms("in", "inch"), 5000d / 127 },
            { "au", 1d / 149600000000},
        };

        public DistanceConverter(string leftUnit, string rightUnit)
        {
            Instantiate(units, leftUnit, rightUnit);
        }
        public DistanceConverter()
        {
            Instantiate(units);
        }
    }
}
