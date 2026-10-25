using System;

namespace UnitConversion.Base;

/// <summary>
/// Thrown when a unit name is not supported by a converter.
/// </summary>
public class UnitNotSupportedException : NotSupportedException
{
    internal UnitNotSupportedException()
    {
    }

    internal UnitNotSupportedException(string? unit)
        : base($"The Unit '{unit}' is not supported by this converter")
    {
    }
}
