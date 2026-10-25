<p align="center">
  <img src="https://raw.githubusercontent.com/atulmish/UnitConversion/master/Logo/UnitConversion.svg" alt="UnitConversion" width="120">
</p>

<h1 align="center">UnitConversion</h1>

<p align="center">
  An expansible unit conversion library for .NET: exact definitions, synonym-based unit names and no dependencies.
</p>

<p align="center">
  <a href="https://github.com/atulmish/UnitConversion/actions/workflows/ci.yml"><img src="https://github.com/atulmish/UnitConversion/actions/workflows/ci.yml/badge.svg" alt="CI"></a>
  <a href="https://www.nuget.org/packages/UnitConversion"><img src="https://img.shields.io/nuget/v/UnitConversion.svg?logo=nuget" alt="NuGet version"></a>
  <a href="https://www.nuget.org/packages/UnitConversion"><img src="https://img.shields.io/nuget/dt/UnitConversion.svg?color=blue" alt="NuGet downloads"></a>
  <a href="https://github.com/atulmish/UnitConversion/blob/master/LICENSE.md"><img src="https://img.shields.io/badge/license-MIT-green.svg" alt="License: MIT"></a>
  <a href="https://dotnet.microsoft.com/download"><img src="https://img.shields.io/badge/.NET-Standard%202.0%20%7C%208%20%7C%2010-512BD4?logo=dotnet" alt=".NET Standard 2.0, .NET 8 and .NET 10"></a>
</p>

## Install

```bash
dotnet add package UnitConversion
```

The package targets .NET Standard 2.0, .NET 8 and .NET 10. That covers .NET Framework 4.6.1 and later, .NET Core 2.0 and later, and every current .NET release. It has no dependencies.

## Quick start

```csharp
using UnitConversion;

var kgToLbs = new MassConverter("kg", "lbs");

double pounds = kgToLbs.LeftToRight(452);        // 996.4894...
double kilograms = kgToLbs.RightToLeft(pounds);  // 452
double rounded = kgToLbs.LeftToRight(452, 2);    // 996.49
```

Unit names ignore case, and each unit answers to several names (`kg`, `kilogram`, `lb`, `lbs`, `pound`, `pounds`). The converter converts between its left and right unit in both directions, and you can change either unit at any time:

```csharp
kgToLbs.UnitLeft = "stone";
kgToLbs.UnitRight = "kg";
double kg = kgToLbs.LeftToRight(12);             // 76.2035...
```

## What it converts

| Converter | Quantity | Some of its units |
|---|---|---|
| `DistanceConverter` | length | m, km, cm, mm, in, ft, yd, mile, nautical mile, au, light year |
| `MassConverter` | mass | kg, g, mg, tonne, lb, oz, stone, short ton, long ton, carat |
| `AreaConverter` | area | m², km², ha, acre, ft², yd², mi² |
| `VolumeConverter` | volume | l, ml, m³, ft³, US and imperial pint, quart and gallon, US cup |
| `TimeConverter` | time | ns, µs, ms, s, min, h, d, week, year |
| `TemperatureConverter` | temperature | celsius, fahrenheit, kelvin |
| `SpeedConverter` | speed | m/s, km/h, mph, knot, ft/s |
| `PressureConverter` | pressure | Pa, kPa, bar, atm, psi, torr, mmHg, inHg |
| `EnergyConverter` | energy | J, kJ, cal, kcal, Wh, kWh, BTU, eV, ft-lbf |
| `PowerConverter` | power | W, kW, MW, hp, PS, BTU/h |
| `AngleConverter` | angle | degree, radian, gradian, turn, arcminute, arcsecond |
| `DigitalStorageConverter` | digital storage | bit, B, kB, MB, GB, KiB, MiB, GiB |

The full list of units and every name they answer to is in [docs/units.md](docs/units.md). Conversions use the exact published definitions, for example 1 lb = 0.45359237 kg, 1 in = 0.0254 m and 1 US gallon = 3.785411784 L.

## Customising

Add a synonym for a name that your own data uses, or add a whole unit:

```csharp
var converter = new MassConverter("kg", "lbs");

converter.AddSynonym("kg", "MTOW (KG)");           // another name for an existing unit
converter.AddUnit("pallet of 250 kg", 1d / 250);   // factor: how many of the new unit make up one kilogram

converter.UnitLeft = "MTOW (KG)";
converter.UnitRight = "pallet of 250 kg";
double pallets = converter.LeftToRight(3000);      // 12
```

A converter is a table of factors, so defining your own is short. Each factor is how many of the unit make up one base unit:

```csharp
public class MyLengthConverter : BaseUnitConverter
{
    public MyLengthConverter(string leftUnit, string rightUnit)
    {
        var units = new UnitFactors("m")           // the base unit
        {
            { new UnitFactorSynonyms("m", "metre"), 1 },
            { new UnitFactorSynonyms("furlong", "furlongs"), 1d / 201.168 },
            { "rod", 1d / 5.0292 },                // strings convert to a single-name unit
        };

        Instantiate(units, leftUnit, rightUnit);
    }
}
```

An unknown unit throws `UnitNotSupportedException`, and adding a name that already exists throws `UnitAlreadyExistsException`.

## Notes on precision

- Values are `double`. Conversions divide by the source factor and multiply by the target factor, so results can differ from the exact value in the last digits.
- A result that differs from a whole number only by floating-point rounding error (such as `2.9999999999999996`) is returned as that whole number. Other values are never altered.
- Temperature scales are converted with formulas, because they do not differ by a single factor.
- A year is 365 days and a leap year 366 days.

## Upgrading from 1.x

Version 2.0 keeps the public API and every unit name from 1.x. It drops .NET Framework 4.0 and .NET Standard 1.3 and makes a few corrections, including the US quart, which was converted with the factor of the US pint. See the [changelog](CHANGELOG.md) for the full list.

## Contributing

Contributions are welcome, from a missing unit to a new converter. Please read the [contributing guidelines](.github/CONTRIBUTING.md) and the [code of conduct](.github/CODE_OF_CONDUCT.md). To report a vulnerability, follow the [security policy](.github/SECURITY.md).

## Maintainers

Maintained by [@atulmish](https://github.com/atulmish). Many thanks to the original authors, [@Nick-Lucas](https://github.com/Nick-Lucas) and [@gkampolis](https://github.com/gkampolis), for creating the library.

## License

[MIT](LICENSE.md)
