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

        public override string ToString() {
            return String.Join(", ", this);
        }


        /// <summary>
        /// Find if some synonym of a given UnitFactor is included in this UnitFactor
        /// </summary>
        /// <param name="synonym">Name of a unit</param>
        public bool Contains(UnitFactorKeys keys) {
            return keys.Any(synonym => this.Contains(synonym));
        }

        /// <summary>
        /// Find if some synonym is included in this UnitFactor
        /// </summary>
        /// <param name="synonym">Name of a unit</param>
        public new bool Contains(string synonym) {
            return this.Contains(synonym, StringComparer.CurrentCultureIgnoreCase);
        }
        
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}
