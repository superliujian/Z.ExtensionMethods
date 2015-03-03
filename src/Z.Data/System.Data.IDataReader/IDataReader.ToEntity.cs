using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>
    ///     An IDataReader extension method that converts the @this to an entity.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>@this as a T.</returns>
    public static T ToEntity<T>(this IDataReader @this) where T : new()
    {
        Type type = typeof (T);
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        var entity = new T();

        var hash = new HashSet<string>(Enumerable.Range(0, @this.FieldCount)
            .Select(@this.GetName));

        foreach (PropertyInfo property in properties)
        {
            if (hash.Contains(property.Name))
            {
                Type valueType = property.PropertyType;
                property.SetValue(entity, @this[property.Name].To(valueType), null);
            }
        }

        foreach (FieldInfo field in fields)
        {
            if (hash.Contains(field.Name))
            {
                Type valueType = field.FieldType;
                field.SetValue(entity, @this[field.Name].To(valueType));
            }
        }

        return entity;
    }
}