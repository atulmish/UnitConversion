# How to contribute

Contributions are welcome, from a missing unit to a new converter. For anything larger than a small fix, please open an issue first so that the approach can be agreed before you invest time. Please read the [code of conduct](CODE_OF_CONDUCT.md) and follow it in all your interactions with the project.

## Development setup

1. Install the .NET SDK version pinned in `global.json`, and the .NET 8 runtime as well. The library targets `netstandard2.0`, `net8.0` and `net10.0`, and the tests run on `net8.0` and `net10.0`.
2. Clone the repository and run:

   ```bash
   dotnet build UnitConversion.slnx
   dotnet test UnitConversion.slnx
   ```

3. Before you open a pull request, check formatting: `dotnet format UnitConversion.slnx --verify-no-changes`.

## Adding a unit

Each converter lives in its own file (for example `UnitConversion/MassConverter.cs`) as a table of factors. A factor is **how many of the unit make up one base unit**, so a unit that is larger than the base unit has a factor below 1.

1. Add a row with all the names the unit answers to (symbol, singular, plural, spelling variants). Names ignore case, so a name must not differ from another unit's name only by case, and no name may belong to two units. A test checks both.
2. Use the exact published definition, written as an expression (`1d / 0.3048`), not a rounded decimal. Mention the source of the definition in the converter's remarks if it is not obvious.
3. Add a row to `UnitConversionTests/ReferenceConversionTests.cs` with an expected value **taken from the published definition, not computed with the library's own factor**.
4. Regenerate the unit list and commit it:

   ```bash
   UPDATE_UNITS_DOC=1 dotnet test UnitConversion.slnx
   ```

   The test `UnitsDocumentIsUpToDate` fails when `docs/units.md` is stale.
5. Add a line to the `Unreleased` section of the [changelog](../CHANGELOG.md).

## Adding a converter

Derive from `BaseUnitConverter`, build a `UnitFactors` table with the base unit, and call `Instantiate` from two constructors (parameterless and `(leftUnit, rightUnit)`), as the existing converters do. Add the converter to the expected list in `AllConvertersTests.TheLibraryShipsTheExpectedConverters`. The tests in `AllConvertersTests` then cover round trips, name uniqueness and name matching for it automatically.

## Coding conventions

- Use an `.editorconfig`-aware editor.
- Every public type and member needs an XML documentation comment: the build treats a missing one as an error, and warnings are errors.
- Keep the public API compatible within a major version. Do not rename or remove public members, units or unit names.
- Add or update tests for every behaviour change. `UnitConversionTests/PropertyTests.cs` uses FsCheck to check laws (round trips, monotonicity, linearity) for every converter over random units and values, so a new unit or converter is covered by it automatically. A failing property prints a seed that reproduces it. CI enforces at least 95% line coverage.

## Pull requests

- Describe what changed and why, and link the issue it fixes.
- Make sure the build, the tests and the format check pass. CI runs them on Linux and Windows.
- Keep a pull request focused on one change.

## Releases (maintainers)

1. Update `Version` in `Directory.Build.props` and move the `Unreleased` changelog entries under the new version.
2. Merge to `master`, then push a tag `vX.Y.Z` that matches the version.
3. The release workflow tests, packs and publishes to NuGet with trusted publishing, and creates the GitHub release.

## Reporting bugs

Please use the [issue tracker](https://github.com/atulmish/UnitConversion/issues/new/choose). Include the package version, the converter and the units involved, the input, the result you expected and the result you got.

## Security issues

Do not open a public issue for a vulnerability. See the [security policy](SECURITY.md).
