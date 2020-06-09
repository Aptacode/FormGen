using System;
using Aptacode.Forms.Shared.Elements.Fields.ValidationRules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Shared.Json
{
    public class ValidationRuleJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(ValidationRule).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            ValidationRule item;

            switch (type)
            {
                case nameof(CheckBoxCheckedValidationRule):
                    item = new CheckBoxCheckedValidationRule();
                    break;
                case nameof(ComboBoxSelectionRequiredValidationRule):
                    item = new ComboBoxSelectionRequiredValidationRule();
                    break;
                case nameof(TextFieldLengthValidationRule):
                    item = new TextFieldLengthValidationRule();
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