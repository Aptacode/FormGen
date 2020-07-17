using System;
using Aptacode.Forms.Shared.ValidationRules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Aptacode.Forms.Shared.Models.Json
{
    public class ValidationRuleJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => typeof(IValidationRule).IsAssignableFrom(objectType);

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var type = jo["Type"]?.Value<string>();

            IValidationRule item;

            switch (type)
            {
                case nameof(CheckElement_IsChecked_Validator):
                    item = new CheckElement_IsChecked_Validator();
                    break;
                case nameof(CheckElement_IsNotChecked_Validator):
                    item = new CheckElement_IsNotChecked_Validator();
                    break;
                case nameof(TextElement_MaximunLength_Validator):
                    item = new TextElement_MaximunLength_Validator();
                    break;
                case nameof(TextElement_MinimunLength_Validator):
                    item = new TextElement_MinimunLength_Validator();
                    break;
                case nameof(SelectElement_SelectionMade_Validator):
                    item = new SelectElement_SelectionMade_Validator();
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