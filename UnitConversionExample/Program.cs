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
            double kg = 452d;
            double lbs = converter.LeftToRight(kg);
            Console.WriteLine("Weight in pounds is " + lbs);

            // Converting both ways is easy
            double originalKgs = converter.RightToLeft(lbs);
            Console.WriteLine("Converted back: " + originalKgs);

            // You may also want a simpler level of precision
            lbs = converter.LeftToRight(kg, 2);
            Console.WriteLine("Weight in pounds is " + lbs);


            // You can easily customise converters to support synonyms used in business logic
            string unitFromDatabase = "MTOW (KG)";
            double mtowKG = 3000;
            converter.AddSynonym("kg", "MTOW (KG)");
            converter.UnitLeft = unitFromDatabase;
            double mtowLBs = converter.LeftToRight(mtowKG);
            Console.Write("MTOW (KG) in lbs is " + mtowLBs);

            Console.Read();
        }
    }
}
