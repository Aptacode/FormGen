using System.Collections.Generic;
using Aptacode.Forms.Shared.Elements.Fields.Results;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Shared.Elements.Fields
{
    public abstract class FormField : FormElement
    {
        protected FormField()
        {
        }

        protected FormField(string type, string name, LabelPosition labelPosition, string label) : base(
            type, name, labelPosition, label)
        {
        }

        public abstract bool IsValid();

        public abstract IEnumerable<string> GetValidationMessages();

        public string GetValidationMessage()
        {
            return string.Join("\n", GetValidationMessages());
        }

        public abstract FieldResult GetResult();
    }
}