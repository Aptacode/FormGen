using System;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Json
{
    public class FormElementJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(FormElement).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            FormElement item = null;

            switch (type)
            {
                case nameof(ButtonElement):
                    item = new ButtonElement();
                    break;
                case nameof(HtmlElement):
                    item = new HtmlElement();
                    break;
                case nameof(TextField):
                    item = new TextField();
                    break;
                case nameof(ComboBoxField):
                    item = new ComboBoxField();
                    break;
                case nameof(CheckBoxField):
                    item = new CheckBoxField();
                    break;
                default:
                    return null;
            }

            serializer.Populate(jo.CreateReader(), item);

            return item;
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}