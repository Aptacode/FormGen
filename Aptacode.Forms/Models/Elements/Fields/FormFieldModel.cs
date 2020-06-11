using Aptacode.Forms.Shared.Models.Enums;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    public abstract class FormFieldModel : FormElementModel
    {
        internal FormFieldModel() { }

        protected FormFieldModel(string type, string name, LabelPosition labelPosition, string label) : base(
            type, name, labelPosition, label) { }
    }
}