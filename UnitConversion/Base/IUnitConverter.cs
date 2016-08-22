namespace UnitConversion.Base {
    internal interface IUnitConverter {
        double LeftToRight(double value);
        double RightToLeft(double value);
    }
}
