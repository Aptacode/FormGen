using System;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Shared.Models.Json
{
    public class FormElementJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => typeof(FormElementModel).IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            FormElementModel item;

            switch (type)
            {
                case nameof(ButtonElementModel):
                    item = new ButtonElementModel();
                    break;
                case nameof(HtmlElementModel):
                    item = new HtmlElementModel();
                    break;
                case nameof(TextFieldModel):
                    item = new TextFieldModel();
                    break;
                case nameof(ComboBoxFieldModel):
                    item = new ComboBoxFieldModel();
                    break;
                case nameof(CheckBoxFieldModel):
                    item = new CheckBoxFieldModel();
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