using Aptacode.Forms.Fields.Inputs;

namespace Aptacode.Forms.Fields
{
    public class FormField : FormElement
    {
        public FormField()
        {
            
        }
        public FormField(string name, string label, FieldLabelPosition labelPosition, BaseFieldInput input) : base(nameof(FormField), name)
        {
            Label = label;
            Input = input;
            LabelPosition = labelPosition;
        }
        public string Label { get; set; }
        public FieldLabelPosition LabelPosition { get; set; }
        public BaseFieldInput Input { get; set; }
    }
}