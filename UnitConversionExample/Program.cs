using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion;

namespace UnitConversionExample {
    public class Program {
        public static void Main(string[] args) {
            double kgValue;
            double lbValue;

            // Simple programmatic approach to conversion, using string `Synonyms`
            var kgToLbs = new MassConverter("kg", "lbs");
            kgValue = 452;
            lbValue = kgToLbs.LeftToRight(kgValue);
            Console.WriteLine("452kg in pounds is " + lbValue);

            // Converting both ways is easy
            kgValue = kgToLbs.RightToLeft(lbValue);
            Console.WriteLine("Converted back: " + kgValue);

            // Rounding is part of conversion
            lbValue = kgToLbs.LeftToRight(kgValue, 2);
            Console.WriteLine("452kg in pounds (to 2 decimal places) is " + lbValue);

            // You can easily customise converters to support Synonyms used in 
            // business logic, such as those stored on a database
            kgToLbs.AddSynonym("kg", "MTOW (KG)");

            kgValue = 3000;
            kgToLbs.UnitLeft = "MTOW (KG)";
            lbValue = kgToLbs.LeftToRight(kgValue);
            Console.WriteLine("3000 MTOW (KG) in lbs is " + lbValue);

            // Add a new unit with a custom conversion factor
            kgToLbs.AddUnit("Chuck Norris", 9001);
            kgToLbs.UnitRight = "Chuck Norris";
            kgValue = 7;
            var chucks = kgToLbs.LeftToRight(kgValue);
            Console.WriteLine("7kg is equal to " + lbValue + " chucks");

            Console.Read();
        }
    }
}
