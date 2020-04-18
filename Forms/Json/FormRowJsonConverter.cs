using System;
using Aptacode.Forms.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Json
{
    public class FormRowJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(FormRow).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            FormRow item = null;

            //switch (type)
            //{
            //    case nameof(FormField):
            //        item = new FormField();
            //        break;
            //    case nameof(HtmlElement):
            //        item = new HtmlElement();
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
