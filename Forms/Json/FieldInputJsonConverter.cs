using System;
using Aptacode.Forms.Elements.Fields;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Json
{
    public class FieldInputJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(FormField).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            FormField item = null;

            //switch (type)
            //{
            //    case nameof(TextFieldInput):
            //        item = new TextFieldInput();
            //        break;
            //    case nameof(ComboBoxFieldInput):
            //        item = new ComboBoxFieldInput();
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
