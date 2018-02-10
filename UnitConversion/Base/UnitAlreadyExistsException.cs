// <copyright file="UnitAlreadyExistsException.cs" company="George Kampolis">
//     Copyright (c) George Kampolis. All rights reserved.
//     Licensed under the MIT License, Version 2.0. See LICENSE.md in the project root for license information.
// </copyright>
//-----------------------------------------------------------------------
namespace UnitConversion.Base
{
    using System;

    /// <summary>
    /// Checks if the unit supplied is already covered.
    /// </summary>
    public class UnitAlreadyExistsException : Exception
    {
        internal UnitAlreadyExistsException() { }
        internal UnitAlreadyExistsException(string unit) : base(String.Format("The given unit synonym '{0}' is already used in this converter", unit)) { }
    }
}
