using UnitConversion.Base;

namespace UnitConversion {
    public class TimeConverter : BaseUnitConverter {

        UnitFactors units = new UnitFactors("s") {
            { new UnitFactorSynonyms("s", "sec", "second"), 1 },

            { new UnitFactorSynonyms("ds", "decisecond", "deci-second"), 10 },
            { new UnitFactorSynonyms("cs", "centisecond", "centi-second"), 100 },
            { new UnitFactorSynonyms("ms", "millisecond", "milli-second"), 1_000 },
            { new UnitFactorSynonyms("us", "μs",  "microsecond", "micro-second"), 1_000_000 },
            { new UnitFactorSynonyms("ns", "nanosecond", "nano-second"), 1_000_000_000 },

            { new UnitFactorSynonyms("min", "minute"), 1d / 60 },
            { new UnitFactorSynonyms("h", "hour"), 1d / 3600 },
            { new UnitFactorSynonyms("d", "day"), 1d / 86400 },
            { new UnitFactorSynonyms("y", "year"), 1d / 31536000 },
            { new UnitFactorSynonyms("leap year", "leap-year"), 1d / 31622400 },
        };

        public TimeConverter(string leftUnit, string rightUnit) {
            Instantiate(units, leftUnit, rightUnit);
        }
        public TimeConverter() {
            Instantiate(units);
        }
    }
}
