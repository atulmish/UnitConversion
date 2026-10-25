## Description

<!-- What does this pull request change and why? Link the issue it fixes. -->

## Checklist

- [ ] Tests added or updated for behaviour changes
- [ ] New or changed units use the exact published definition, and the reference test uses a value from that definition
- [ ] `docs/units.md` regenerated if units changed (`UPDATE_UNITS_DOC=1 dotnet test UnitConversion.slnx`)
- [ ] `dotnet format UnitConversion.slnx --verify-no-changes` passes
- [ ] The public API is documented with XML comments and stays compatible
- [ ] The `Unreleased` section of `CHANGELOG.md` is updated
