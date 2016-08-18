using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactors : Dictionary<UnitFactorKeys, double> {
        public UnitFactors(string baseUnit) {
            BaseUnit = baseUnit;
        }
        protected string BaseUnit;

        public new bool ContainsKey(UnitFactorKeys key) {
            return this.Any(factor => factor.Key.Equals(key));
        }

        public void AddSynonym(UnitFactorKeys key, string synonym) {
            var factor = this.FirstOrDefault(f => f.Key.Equals(key)).Key;
            if (factor == null) {
                throw new UnitNotSupportedException("The Unit you are trying to add a synonym to does not exist");
            }
            factor.Add(synonym);
        }
    }
}
