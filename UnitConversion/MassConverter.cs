using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion.Base;

namespace UnitConversion {
    public class MassConverter : BaseUnitConverter {
        public MassConverter(string leftUnit, string rightUnit) {
            var units = new UnitFactors("kg") {
                { new UnitFactorSynonyms("kg", "kilogram"), 1 },
                { new UnitFactorSynonyms("gram", "g"), 1000 },
                { new UnitFactorSynonyms("lb", "lbs", "pound", "pounds"), 100000000 / 45359237 },
                { new UnitFactorSynonyms("st", "stone"), 50000000 / 317514659 },
                { new UnitFactorSynonyms("oz", "ounce"), 1600000000 / 45359237 },
            };
            Instantiate(units, leftUnit, rightUnit);
        }
    }
}
