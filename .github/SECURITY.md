# Security policy

## Supported versions

| Version | Supported |
| ------- | --------- |
| 2.x     | Yes       |
| 1.x     | No        |

Version 1.x depends on packages with known vulnerabilities (through its .NET Standard 1.3 target). Please upgrade to 2.x.

## Reporting a vulnerability

Please report vulnerabilities privately through [GitHub private security advisories](https://github.com/atulmish/UnitConversion/security/advisories/new). Do not open a public issue.

We aim to acknowledge reports within five business days and will keep you informed of the progress of a fix. Please do not publish details until a fix is released.

## Scope

UnitConversion is a pure computation library with no dependencies, no network or file access and no native code. Reports about the behaviour of the library itself (for example input that causes a crash or an unbounded loop) are in scope. Vulnerabilities in the .NET runtime or in your build tools should be reported to their maintainers.
