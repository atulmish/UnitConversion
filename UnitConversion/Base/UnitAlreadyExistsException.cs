using System;

namespace UnitConversion.Base;

/// <summary>
/// Thrown when a unit or synonym that is being added already exists in a converter.
/// </summary>
public class UnitAlreadyExistsException : Exception
{
    internal UnitAlreadyExistsException()
    {
    }

    internal UnitAlreadyExistsException(string unit)
        : base($"The given unit synonym '{unit}' is already used in this converter")
    {
    }
}
