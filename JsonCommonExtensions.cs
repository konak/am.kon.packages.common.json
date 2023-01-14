using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace am.kon.packages.common.json
{
    /// <summary>
    /// Common extesion to be used for Json serialize / deserialize
    /// </summary>
    public static class JsonCommonExtensions
    {
        /// <summary>
        /// Common settings to be used during serialize / deserialize process
        /// </summary>
        public static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.None,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        /// <summary>
        /// Extension method to serialise any type of the object into Json formated string
        /// </summary>
        /// <param name="item">Instance of an object to be serialized</param>
        /// <returns>Json formated string implementation of the provided object</returns>
        public static string ToJson(this object item)
        {
            return JsonConvert.SerializeObject(item, SerializerSettings);
        }

        /// <summary>
        /// Extesion method to deserialize Jsonn formated string into an instance of an object
        /// </summary>
        /// <typeparam name="T">Type of an object to be deserialized</typeparam>
        /// <param name="jsonString">Json formated string to be used for deserialization</param>
        /// <returns>Returns an instance of an object of provided type</returns>
        public static T ToObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, SerializerSettings);
        }
    }
}

