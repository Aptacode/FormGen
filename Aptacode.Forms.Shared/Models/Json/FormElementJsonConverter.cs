using System;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Shared.Models.Json
{
    public class FormElementJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => typeof(FormElement).IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["ElementType"]?.Value<string>();

            FormElement item;

            switch (type)
            {
                case nameof(ColumnElement):
                    item = new ColumnElement();
                    break;
                case nameof(RowElement):
                    item = new RowElement();
                    break;
                case nameof(GroupElement):
                    item = new GroupElement();
                    break;
                case nameof(ButtonElement):
                    item = new ButtonElement();
                    break;
                case nameof(HtmlElement):
                    item = new HtmlElement();
                    break;
                case nameof(TextElement):
                    item = new TextElement();
                    break;
                case nameof(SelectElement):
                    item = new SelectElement();
                    break;
                case nameof(CheckElement):
                    item = new CheckElement();
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