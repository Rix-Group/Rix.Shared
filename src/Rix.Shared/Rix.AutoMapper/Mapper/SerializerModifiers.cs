using System.Reflection;
using System.Text.Json.Serialization.Metadata;

namespace Rix.AutoMapper.Mapper;

internal static class SerializerModifiers
{
    /// <summary>
    /// Includes internal properties when serializing.
    /// </summary>
    internal static void IncludeInternalProperties(JsonTypeInfo jsonTypeInfo)
    {
        // Only modify contracts for object types (classes/structs)
        if (jsonTypeInfo.Kind is not JsonTypeInfoKind.Object)
            return;

        // Get the actual PropertyInfo objects for internal properties
        var internalProperties = jsonTypeInfo.Type.GetProperties(
            BindingFlags.Instance | BindingFlags.NonPublic) // Look for non-public instance properties
            .Where(p => p.GetGetMethod(true)?.IsAssembly is true || p.GetSetMethod(true)?.IsAssembly is true); // Filter for 'internal' accessors

        foreach (var prop in internalProperties)
        {
            // 1. Check if the property is already in the contract (e.g., if it was public/internal,
            // the default resolver might have added it, but this check is safer).
            if (jsonTypeInfo.Properties.Any(p => p.Name == prop.Name))
                continue;

            // 2. Create a new JsonPropertyInfo for the internal property
            JsonPropertyInfo jsonPropInfo = jsonTypeInfo.CreateJsonPropertyInfo(prop.PropertyType, prop.Name);

            // 3. Configure the Get and Set delegates using Reflection
            if (prop.CanRead)
                jsonPropInfo.Get = prop.GetValue;
            if (prop.CanWrite)
                jsonPropInfo.Set = prop.SetValue;

            // 4. Add the new property to the contract
            jsonTypeInfo.Properties.Add(jsonPropInfo);
        }
    }
}