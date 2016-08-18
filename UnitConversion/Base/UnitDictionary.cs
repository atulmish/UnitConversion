using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitDictionary : Dictionary<UnitDictionaryKey, double> {
        public UnitDictionary(string baseUnit) {
            BaseUnit = baseUnit;
        }
        public string BaseUnit;

        public new bool ContainsKey(UnitDictionaryKey key) {
            return this.Any(factor => factor.Key.Equals(key));
        }
    }
}
