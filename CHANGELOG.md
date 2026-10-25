# Changelog

All notable changes to this project are documented here. The format follows
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project adheres to
[Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Property-based tests (FsCheck) that check, for every converter and hundreds of random units and values, that conversions round-trip, are monotonic, scale linearly, compose through any third unit and accept unit names in any case
- Each package is attested with signed build provenance and signed with Sigstore at release time, and the signature bundle is attached to the GitHub release. See "Verifying a release" in the security policy
- An OpenSSF Scorecard workflow
- The release workflow can be started by hand on a branch as a dry run that builds, attests and signs but publishes nothing

### Changed

- Workflows use read-only tokens at the top level and grant write permissions only to the job that needs them
- Every GitHub Action is pinned to a commit SHA (Dependabot keeps them current), and the tools installed in workflows have pinned versions

## [2.0.0] - 2026-10-25

Version 2.0 keeps the public API and every unit name of 1.x. It is a major release because it drops two target
frameworks and corrects conversion factors, so some results change in the last digits (and the US quart changes
by a factor of two, see Fixed).

### Added

- Six new converters: `SpeedConverter`, `PressureConverter`, `EnergyConverter`, `PowerConverter`, `AngleConverter` and `DigitalStorageConverter`
- New units in the existing converters: micrometre, nanometre, nautical mile and light year (distance); milligram, microgram, tonne, carat and grain (mass); acre (area); millilitre, centilitre, decilitre, US teaspoon, tablespoon, fluid ounce and cup, and imperial fluid ounce (volume); week (time)
- More names for existing units: plurals, American spellings, `square kilometre`-style names for areas, `mi` for miles, `hr` for hours, and the single letters `C`, `F` and `K` for temperature scales
- `docs/units.md`, a generated list of every unit and name. A test fails when it is stale
- A test suite of 270 tests that checks every conversion against the published definition of each unit, every pair of units in every converter, and that every 1.x unit name is still accepted
- GitHub Actions for build, test and coverage (95% of lines is enforced), CodeQL, dependency review, and tag-triggered releases published with NuGet trusted publishing, with a software bill of materials on each release
- Embedded package icon and README, SourceLink and symbol packages, and a license expression in the package

### Changed

- **Breaking:** the package now targets `netstandard2.0`, `net8.0` and `net10.0`. .NET Framework 4.0 and .NET Standard 1.3 are no longer supported. Applications on .NET Framework 4.6.1 or later and .NET Core 2.0 or later are unaffected
- Conversion factors use the exact published definitions. Results change by a relative amount between 1e-8 and 1.4e-5 for the short ton, long ton, astronomical unit, cubic foot, cubic inch, imperial pint, quart and gallon, US pint and US gallon (for example one astronomical unit is now 149 597 870 700 m, it was 149 600 000 000 m)
- Converting a unit to itself returns the value exactly
- `CheckCloseEnoughValue` removes only floating-point noise (a result within 1e-12, relative, of a whole number). It previously rounded any value whose fractional part was between 0.99999 and 0.999999999 up to the next whole number, which changed genuine results such as 0.999995 to 1. `lowerBoundEpsilon` and `upperBoundEpsilon` are obsolete and unused
- Unit names are matched ignoring case using ordinal comparison. Matching used the current culture, which broke names such as `IN` under the Turkish culture
- Nullable reference types are annotated, and the public API is documented with XML comments
- The temperature conversion is now a virtual `Convert` method of `BaseUnitConverter` instead of a special case on the base unit's name
- Tests moved to MSTest 4 on net8.0 and net10.0. The solution file is now `UnitConversion.slnx`
- The README, contributing guide, code of conduct and issue and pull request templates were rewritten, and links that pointed at the previous repository owner were updated

### Fixed

- **The US quart used the factor of the US pint**, so a US quart converted to half its true volume. It now uses 0.946352946 L. A test in 1.x asserted the wrong value
- Temperature scale names that differ only in case (`CELSIUS`, `Fahrenheit`) were accepted by validation but then converted nothing and returned the input unchanged
- `AddSynonym` with a first argument that is not a unit threw `NullReferenceException`. It now throws `UnitNotSupportedException`
- Passing `null` as a unit or a table now throws `ArgumentNullException`
- The package no longer brings in `System.Net.Http` 4.3.0 and `System.Text.RegularExpressions` 4.3.0, which are flagged as high severity vulnerabilities (GHSA-7jgj-8wvc-jh57 and GHSA-cmhx-cq75-c4mj). They came from the `netstandard1.3` target and produced audit warnings in consuming projects
- The example in the README and the example project printed the wrong variable

### Removed

- AppVeyor configuration, StyleCop settings, the Visual Studio solution file and the assembly information files

[Unreleased]: https://github.com/atulmish/UnitConversion/compare/v2.0.0...HEAD
[2.0.0]: https://github.com/atulmish/UnitConversion/releases/tag/v2.0.0
