using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactorKeys {
        List<string> _keys = new List<string>();

        public UnitFactorKeys() { }
        public UnitFactorKeys(params string[] items) {
            _keys.AddRange(items);
        }

        // Allow strings to be interpreted as a UnitDictionaryKey
        public static implicit operator UnitFactorKeys(string str) {
            return new UnitFactorKeys(str);
        }

        public override string ToString() {
            return String.Join(", ", _keys);
        }

        public void AddSynonym(string synonym) {
            if (Contains(synonym)) {
                throw new UnitAlreadyExistsException(synonym);
            }
            _keys.Add(synonym);
        }


        /// <summary>
        /// Find if some synonym of a given UnitFactor is included in this UnitFactor
        /// </summary>
        /// <param name="synonym">Name of a unit</param>
        public bool Contains(UnitFactorKeys keys) {
            return _keys.Any(synonym => keys.Contains(synonym));
        }

        /// <summary>
        /// Find if some synonym is included in this UnitFactor
        /// </summary>
        /// <param name="synonym">Name of a unit</param>
        public bool Contains(string synonym) {
            return _keys.Contains(synonym, StringComparer.CurrentCultureIgnoreCase);
        }
        
        public override int GetHashCode() {
            return _keys.GetHashCode();
        }
    }
}
