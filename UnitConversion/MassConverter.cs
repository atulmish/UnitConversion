//-----------------------------------------------------------------------
// <copyright file="MassConverter.cs" company="George Kampolis">
//     Copyright (c) George Kampolis. All rights reserved.
//     Licensed under the MIT License, Version 2.0. See LICENSE.md in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitConversion
{
    using System;
    using UnitConversion.Base;

    /// <summary>
    /// Converts between mass units.
    /// </summary>
    public class MassConverter : BaseUnitConverter
    {
        UnitFactors units = new UnitFactors("kg")
        {
            { new UnitFactorSynonyms("kg", "kilogram"), 1 },
            { new UnitFactorSynonyms("gram", "g"), 1000 },
            { new UnitFactorSynonyms("lb", "lbs", "pound", "pounds"), 100000000d / 45359237 },
            { new UnitFactorSynonyms("st", "stone"), 50000000d / 317514659 },
            { new UnitFactorSynonyms("oz", "ounce"), 1600000000d / 45359237 },
            { new UnitFactorSynonyms("quintal"), 0.01 },
            { new UnitFactorSynonyms("short ton", "net ton", "us ton"), 0.00110231 },
            { new UnitFactorSynonyms("long ton", "weight ton", "gross ton", "imperial ton"), 0.000984207 },
        };

        public MassConverter(string leftUnit, string rightUnit)
        {
            Instantiate(units, leftUnit, rightUnit);
        }
        public MassConverter() : base()
        {
            Instantiate(units);
        }
    }
}
