using System;

using UnitConversion;

namespace UnitConversionExample
{
    public class Program {
        public static void Main(string[] args) {
            double kg;
            double lb;

            // Simple programmatic approach to conversion, using string `Synonyms`
            var converter = new MassConverter("kg", "lbs");
            kg = 452;
            lb = converter.LeftToRight(kg);
            Console.WriteLine("452kg in pounds is " + lb);

            // Converting both ways is easy
            kg = converter.RightToLeft(lb);
            Console.WriteLine("Converted back: " + kg);

            // Rounding is part of conversion
            lb = converter.LeftToRight(kg, 2);
            Console.WriteLine("452kg in pounds (to 2 decimal places) is " + lb);

            // You can easily customise converters to support Synonyms used in 
            // business logic, such as those stored on a database
            string mtowUnit = "MTOW (KG)";
            kg = 3000;
            converter.AddSynonym("kg", mtowUnit);
            converter.UnitLeft = mtowUnit;
            lb = converter.LeftToRight(kg);
            Console.WriteLine("3000 MTOW (KG) in lbs is " + lb);

            // Add a new unit with a custom conversion factor
            converter.AddUnit("Chuck Norris", 9001);
            converter.UnitRight = "Chuck Norris";
            kg = 7;
            var chucks = converter.LeftToRight(kg);
            Console.WriteLine("7kg is equal to " + lb + " chucks");

            Console.Read();
        }
    }
}
