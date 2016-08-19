using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion.Base;

namespace UnitConversion {
    public class MassConverter : BaseUnitConverter {
        UnitFactors units = new UnitFactors("kg") {
            { new UnitFactorSynonyms("kg", "kilogram"), 1 },
            { new UnitFactorSynonyms("gram", "g"), 1000 },
            { new UnitFactorSynonyms("lb", "lbs", "pound", "pounds"), 100000000d / 45359237 },
            { new UnitFactorSynonyms("st", "stone"), 50000000d / 317514659 },
            { new UnitFactorSynonyms("oz", "ounce"), 1600000000d / 45359237 },
        };

        public MassConverter(string leftUnit, string rightUnit) {
            Instantiate(units, leftUnit, rightUnit);
        }
        public MassConverter() : base() {
            Instantiate(units);
        }
    }
}
