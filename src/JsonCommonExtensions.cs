using System;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Provides common JSON serialization and deserialization extensions.
/// </summary>
public static class JsonCommonExtensions
{
    /// <summary>
    /// Common settings to be used during serialization and deserialization.
    /// </summary>
    public static JsonSerializerOptions DefaultSerializerOptions { get; private set; }

    /// <summary>
    /// Static constructor to initialize default serializer options.
    /// </summary>
    static JsonCommonExtensions()
    {
        DefaultSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            ReferenceHandler = ReferenceHandler.Preserve
        };
    }

    /// <summary>
    /// Configures the default serializer options.
    /// </summary>
    /// <param name="options">The custom serializer options.</param>
    /// <remarks>
    /// This method allows for custom configuration of serialization options.
    /// Example:
    /// <code>
    /// var options = new JsonSerializerOptions { WriteIndented = true };
    /// JsonCommonExtensions.Configure(options);
    /// </code>
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the provided options are null.</exception>
    public static void Configure(JsonSerializerOptions options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));

        DefaultSerializerOptions = options;
    }

    /// <summary>
    /// Serializes the specified object to a JSON string.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="DefaultSerializerOptions"/> if no <paramref name="serializerOptions"/> are provided.
    /// </remarks>
    /// <param name="item">The object to serialize.</param>
    /// <param name="serializerOptions">Options to be used during serialization</param>
    /// <returns>A JSON string representation of the object.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided item is null.</exception>
    public static string ToJson(this object item, JsonSerializerOptions serializerOptions = null)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        return JsonSerializer.Serialize(item, serializerOptions ?? DefaultSerializerOptions);
    }

    /// <summary>
    /// Deserializes the specified JSON string to an object of type T.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="DefaultSerializerOptions"/> if no <paramref name="serializerOptions"/> are provided.
    /// </remarks>
    /// <typeparam name="T">The type of object to deserialize to.</typeparam>
    /// <param name="jsonString">The JSON string to deserialize.</param>
    /// <param name="serializerOptions">Options to be used during serialization</param>
    /// <returns>An object of type T deserialized from the JSON string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided JSON string is null.</exception>
    public static T ToObject<T>(this string jsonString, JsonSerializerOptions serializerOptions = null)
    {
        if (jsonString == null) throw new ArgumentNullException(nameof(jsonString));

        return JsonSerializer.Deserialize<T>(jsonString, serializerOptions ?? DefaultSerializerOptions);
    }
}
