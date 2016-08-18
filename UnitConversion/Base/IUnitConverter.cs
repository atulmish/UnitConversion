using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConversion.Base {
    internal interface IUnitConverter {
        double LeftToRight(double value);
        double RightToLeft(double value);
    }
}
