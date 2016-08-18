using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion.Base;

namespace UnitConversion {
    public class MassConverter : BaseUnitConverter {
        public MassConverter(string leftUnit, string rightUnit) {
            var units = new UnitFactors("kg") {
                { new UnitFactorKeys("kg", "kilogram"), 1 },
                { new UnitFactorKeys("gram", "g"), 1000 },
                { new UnitFactorKeys("lbs", "pounds"), 2.2046226218 },
                { new UnitFactorKeys("stn", "stone"), 0.157473 },
                { new UnitFactorKeys("ounce"), 0.157473 },
            };
            Instantiate(units, leftUnit, rightUnit);
        }
    }
}
