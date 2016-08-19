using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitFactorSynonyms {
        public UnitFactorSynonyms() { }
        public UnitFactorSynonyms(params string[] items) {
            _synonyms.AddRange(items);
        }

        List<string> _synonyms = new List<string>();

        /// <summary>
        /// The list of synonyms this object holds
        /// </summary>
        IEnumerable<string> Synonyms {
            get {
                return _synonyms.AsEnumerable();
            }
        }


        // ** INTERNAL HELPERS **

        // Append new syonym to the list
        internal void AddSynonym(string synonym) {
            if (Contains(synonym)) {
                throw new UnitAlreadyExistsException(synonym);
            }
            _synonyms.Add(synonym);
        }

        // Find if some synonym of a given UnitFactor is included in this UnitFactor
        internal bool Contains(UnitFactorSynonyms keys) {
            return _synonyms.Any(synonym => keys.Contains(synonym));
        }

        // Find if some synonym is included in this UnitFactor
        internal bool Contains(string synonym) {
            return _synonyms.Contains(synonym, StringComparer.CurrentCultureIgnoreCase);
        }


        // ** OVERRIDES **
        
        public override int GetHashCode() {
            return _synonyms.GetHashCode();
        }

        public override string ToString() {
            return String.Join(", ", _synonyms);
        }

        // Allow strings to be interpreted as a UnitDictionaryKey
        public static implicit operator UnitFactorSynonyms(string str) {
            return new UnitFactorSynonyms(str);
        }
    }
}
