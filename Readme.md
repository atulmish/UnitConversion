# Unit Conversion

[![Build status](https://ci.appveyor.com/api/projects/status/wpwan2vbma0i6ohr?svg=true)](https://ci.appveyor.com/project/gkampolis/unitconversion)
[![NuGet](https://img.shields.io/nuget/v/UnitConversion.svg)](https://www.nuget.org/packages/UnitConversion)
[![MIT License](https://img.shields.io/github/license/gkampolis/UnitConversion.svg)](https://raw.githubusercontent.com/gkampolis/UnitConversion/master/LICENSE.md)
[![Gitter chat](https://img.shields.io/badge/gitter-join%20chat%20%E2%86%92-brightgreen.svg)](https://gitter.im/UnitConversionCSharp)

## What is it?
An expansible .Net class library with support for all modern platforms

* .Net Framework 4.0+
* .Net Standard 1.3+ (.Net 4.5.1+ and .Net Core)

UnitConversion is designed to be expansible through factories or through concrete converter implementations.

Implementations are currently limited, but include:

* [MassConverter](https://github.com/gkampolis/UnitConversion/blob/master/UnitConversion/MassConverter.cs)
* [DistanceConverter](https://github.com/gkampolis/UnitConversion/blob/master/UnitConversion/DistanceConverter.cs)
* [TimeConverter](https://github.com/gkampolis/UnitConversion/blob/master/UnitConversion/TimeConverter.cs)
* [AreaConverter](https://github.com/gkampolis/UnitConversion/blob/master/UnitConversion/AreaConverter.cs)
* [VolumeConverter](https://github.com/gkampolis/UnitConversion/blob/master/UnitConversion/VolumeConverter.cs)

Pull requests with custom implementations are welcome! Please have a look through the [contributing guidelines](https://github.com/gkampolis/UnitConversion/blob/master/.github/CONTRIBUTING.md) and our [code of conduct](https://github.com/gkampolis/UnitConversion/blob/master/.github/CODE_OF_CONDUCT.md).

## Example

```C#
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
```

## Converters are easy to define and contribute to:

```C#
public class DistanceConverter : BaseUnitConverter 
{
    UnitFactors units = new UnitFactors("m") 
    {
        { new UnitFactorSynonyms("m", "metre"), 1 },
        { new UnitFactorSynonyms("km", "kilometre"), 0.001 },
        { new UnitFactorSynonyms("cm", "centimetre"), 100 },
        { new UnitFactorSynonyms("mm", "millimetre"), 1000 },
        { new UnitFactorSynonyms("ft", "foot", "feet"), 1250d / 381 },
        { new UnitFactorSynonyms("yd", "yard"), 1250d / 1143 },
        { "mile", 125d / 201168 }, // strings automatically cast to UnitFactorSynonyms
        { new UnitFactorSynonyms("in", "inch"), 5000d / 127 },
    };

    public DistanceConverter(string leftUnit, string rightUnit) 
    {
        Instantiate(units, leftUnit, rightUnit);
    }
    public DistanceConverter() 
    {
        Instantiate(units);
    }
}
```
## Current Maintainer

* [@atulmish](https://github.com/atulmish)

### Previous maintainers

Many thanks to the original maintainers [@Nick-Lucas](https://github.com/Nick-Lucas) and [@gkampolis](https://github.com/gkampolis) for all their hard work.
