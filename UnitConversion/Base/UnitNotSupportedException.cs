//-----------------------------------------------------------------------
// <copyright file="UnitNotSupportedException.cs" company="George Kampolis">
//     Copyright (c) George Kampolis. All rights reserved.
//     Licensed under the MIT License, Version 2.0. See LICENSE.md in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------

namespace UnitConversion.Base
{
    using System;

    /// <summary>
    /// Checks if the unit supplied does not exist.
    /// </summary>
    public class UnitNotSupportedException : NotSupportedException
    {
        internal UnitNotSupportedException() { }
        internal UnitNotSupportedException(string unit) : base(String.Format("The Unit '{0}' is not supported by this converter", unit)) { }
    }
}
