using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion.Base;

namespace UnitConversion {
    public class MassConverter : BaseUnitConverter {
        public MassConverter(string leftUnit, string rightUnit) {
            var units = new UnitDictionary("kg") {
                { new UnitDictionaryKey("kg", "kilogram"), 1 },
                { new UnitDictionaryKey("lbs", "pounds"), 2.2046226218 },
                { new UnitDictionaryKey("stn", "stone"), 0.157473 },
            };
            Instantiate(units, leftUnit, rightUnit);
        }
    }
}
