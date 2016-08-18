using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitDictionaryKey : List<string> {
        public UnitDictionaryKey() { }
        public UnitDictionaryKey(params string[] items) {
            AddRange(items);
        }

        // Allow strings to be interpreted as a UnitDictionaryKey
        public static implicit operator UnitDictionaryKey(string str) {
            return new UnitDictionaryKey(str);
        }

        // Allow comparison of UnitDictionaryKey objects
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            UnitDictionaryKey keys;
            if (obj.GetType() == typeof(string)) {
                keys = (string)obj;
            } else if (obj.GetType() == typeof(UnitDictionaryKey)) {
                keys = (UnitDictionaryKey)obj;
            } else {
                return false;
            }
             
            return keys.Any(s => this.Contains(s, StringComparer.CurrentCultureIgnoreCase));
        }
        
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
