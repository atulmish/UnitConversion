using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnitConversion;

namespace UnitConversionExample {
    public class Program {
        public static void Main(string[] args) {
            // Simple programmatic approach to conversion between units
            var converter = new MassConverter("kg", "lbs");
            double kg = 452;
            double lbs = converter.LeftToRight(kg);
            Console.WriteLine("452kg in pounds is " + lbs);

            // Converting both ways is easy
            double originalKgs = converter.RightToLeft(lbs);
            Console.WriteLine("Converted back: " + originalKgs);

            // You may also want a simpler level of precision
            lbs = converter.LeftToRight(kg, 2);
            Console.WriteLine("452kg in pounds (to 2 decimal places) is " + lbs);

            // You can easily customise converters to support synonyms used in business logic, such as those stored on a database
            string myUnitName = "MTOW (KG)";
            kg = 3000;
            converter.AddSynonym("kg", myUnitName);
            converter.UnitLeft = myUnitName;
            lbs = converter.LeftToRight(kg);
            Console.WriteLine("3000 MTOW (KG) in lbs is " + lbs);

            // Add a new unit with a custom conversion factor
            converter.AddUnit("Chuck Norris", 9001);
            converter.UnitRight = "Chuck Norris";
            kg = 7;
            var chucks = converter.LeftToRight(kg);
            Console.WriteLine("7kg is equal to " + lbs + " chucks");

            Console.Read();
        }
    }
}
