using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion.Base;

namespace UnitConversion {
    public class DistanceConverter : BaseUnitConverter {
        public DistanceConverter(string leftUnit, string rightUnit) {
            var units = new UnitFactors("m") {
                { new UnitFactorSynonyms("m", "metre"), 1 },
                { new UnitFactorSynonyms("km", "kilometre"), 0.001 },
                { new UnitFactorSynonyms("cm", "centimetre"), 100 },
                { new UnitFactorSynonyms("mm", "millimetre"), 1000 },
                { new UnitFactorSynonyms("ft", "foot", "feet"), 1250 / 381 },
                { new UnitFactorSynonyms("yd", "yard"), 1250 / 1143 },
                { new UnitFactorSynonyms("mile"), 125 / 201168 },
                { new UnitFactorSynonyms("in", "inch"), 5000 / 127 },
            };
            Instantiate(units, leftUnit, rightUnit);
        }
    }
}
