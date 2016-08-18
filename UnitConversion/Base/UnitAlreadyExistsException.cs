using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    public class UnitAlreadyExistsException : Exception {
        internal UnitAlreadyExistsException() { }
        internal UnitAlreadyExistsException(string unit) : base(String.Format("The given unit synonym '{0}' is already used in this converter", unit)) { }
    }
}
