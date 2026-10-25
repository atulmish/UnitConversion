using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnitConversion;
using UnitConversion.Base;

namespace UnitConversionTests;

/// <summary>Creates converters by name and enumerates every converter shipped in the library.</summary>
internal static class ConverterFactory
{
    public static BaseUnitConverter Create(string converter, string left, string right) =>
        (BaseUnitConverter)Activator.CreateInstance(TypeOf(converter), left, right)!;

    public static IEnumerable<Type> AllConverterTypes() =>
        typeof(BaseUnitConverter).Assembly.GetExportedTypes()
            .Where(t => !t.IsAbstract && typeof(BaseUnitConverter).IsAssignableFrom(t))
            .OrderBy(t => t.Name, StringComparer.Ordinal);

    public static BaseUnitConverter CreateDefault(Type type) => (BaseUnitConverter)Activator.CreateInstance(type)!;

    public static IEnumerable<object[]> AllConverters() =>
        AllConverterTypes().Select(t => new object[] { t });

    private static Type TypeOf(string converter) =>
        typeof(BaseUnitConverter).Assembly.GetType($"UnitConversion.{converter}Converter", throwOnError: true)!;
}
