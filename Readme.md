### UnitConversion

An expansible dotnet class library intended to fill the gap of a converter library which supports all modern dotnet platforms
* .Net Framework
* .Net Core

UnitConversion is designed for programmatic use, and to be both expansible and flexible to use with custom business logic

```C#
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
```

Converters are easy to define to contribute to
```C#
public class MassConverter : BaseUnitConverter {
    public MassConverter(string leftUnit, string rightUnit) {
        var units = new UnitFactors("kg") {
            { new UnitFactorSynonyms("kg", "kilogram"), 1 },
            { new UnitFactorSynonyms("gram", "g"), 1000 },
            { new UnitFactorSynonyms("lbs", "pounds"), 2.2046226218 },
            { new UnitFactorSynonyms("stn", "stone"), 0.157473 },
            { "ounce", 0.157473 },
        };
        Instantiate(units, leftUnit, rightUnit);
    }
}
```