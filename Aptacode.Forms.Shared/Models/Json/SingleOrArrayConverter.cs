using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Shared.Models.Json
{
    public class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType) => objectType == typeof(List<T>);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            serializer.Converters.Add(new ValidationRuleJsonConverter());
            serializer.Converters.Add(new FormElementJsonConverter());

            var token = JToken.Load(reader);
            return token.Type == JTokenType.Array
                ? token.ToObject<List<T>>(serializer)
                : new List<T> {token.ToObject<T>(serializer)};
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}