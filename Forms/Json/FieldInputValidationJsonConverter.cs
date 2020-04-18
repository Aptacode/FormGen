using System;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Json
{
    public class FieldInputValidationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ValidationRule).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            ValidationRule item = null;

            //switch (type)
            //{
            //    case nameof(TextInputIsRequiredValidationRule):
            //        item = new TextInputIsRequiredValidationRule();
            //        break;
            //    case nameof(TextInputLengthValidationRule):
            //        item = new TextInputLengthValidationRule();
            //        break;
            //    default:
            //        return null;
            //}

            serializer.Populate(jo.CreateReader(), item);

            return item;
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
