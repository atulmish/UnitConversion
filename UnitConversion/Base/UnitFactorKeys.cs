using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactorKeys : List<string> {
        public UnitFactorKeys() { }
        public UnitFactorKeys(params string[] items) {
            AddRange(items);
        }

        // Allow strings to be interpreted as a UnitDictionaryKey
        public static implicit operator UnitFactorKeys(string str) {
            return new UnitFactorKeys(str);
        }

        /// <summary>
        /// Compare to a UnitDictionaryKey or String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            UnitFactorKeys keys;
            if (obj.GetType() == typeof(string)) {
                keys = (string)obj;
            } else if (obj.GetType() == typeof(UnitFactorKeys)) {
                keys = (UnitFactorKeys)obj;
            } else {
                return false;
            }
             
            return keys.Any(s => this.Contains(s, StringComparer.CurrentCultureIgnoreCase));
        }
        
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return String.Join(", ", this);
        }
    }
}
