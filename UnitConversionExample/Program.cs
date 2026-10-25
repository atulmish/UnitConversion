using System;
using UnitConversion;

// A short tour of the library. Run it with: dotnet run --project UnitConversionExample

// Convert between two units. Unit names are matched ignoring case, and each unit answers to several names.
var kgToLbs = new MassConverter("kg", "lbs");
double kilograms = 452;
double pounds = kgToLbs.LeftToRight(kilograms);
Console.WriteLine($"{kilograms} kg in pounds is {pounds}");

// Convert back.
Console.WriteLine($"Converted back: {kgToLbs.RightToLeft(pounds)} kg");

// Round the result to a number of decimal places.
Console.WriteLine($"{kilograms} kg in pounds, to 2 decimal places: {kgToLbs.LeftToRight(kilograms, 2)}");

// Add a synonym, for example a name that is stored in your own data.
kgToLbs.AddSynonym("kg", "MTOW (KG)");
kgToLbs.UnitLeft = "MTOW (KG)";
Console.WriteLine($"3000 MTOW (KG) in pounds is {kgToLbs.LeftToRight(3000)}");

// Add a unit of your own. The factor is how many of the new unit make up one base unit (one kilogram here).
kgToLbs.AddUnit("pallet of 250 kg", 1d / 250);
kgToLbs.UnitRight = "pallet of 250 kg";
Console.WriteLine($"3000 MTOW (KG) is {kgToLbs.LeftToRight(3000)} pallets of 250 kg");

// Other quantities work the same way.
Console.WriteLine($"100 km/h is {new SpeedConverter("km/h", "mph").LeftToRight(100, 2)} mph");
Console.WriteLine($"1 atm is {new PressureConverter("atm", "psi").LeftToRight(1, 3)} psi");
Console.WriteLine($"1 US gallon is {new VolumeConverter("US gallon", "l").LeftToRight(1, 6)} litres");
Console.WriteLine($"37 °C is {new TemperatureConverter("°C", "°F").LeftToRight(37, 1)} °F");
Console.WriteLine($"1 GiB is {new DigitalStorageConverter("GiB", "MB").LeftToRight(1, 3)} MB");
