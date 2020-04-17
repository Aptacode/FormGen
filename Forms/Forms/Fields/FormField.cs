using Aptacode.Forms.Forms.Fields.Inputs;

namespace Aptacode.Forms.Forms.Fields
{
    public class FormField : FormRow
    {
        public FormField()
        {
            
        }
        public FormField(string name, string label, FieldLabelPosition labelPosition, FieldInput input) : base(nameof(FormField), name)
        {
            Label = label;
            Input = input;
            LabelPosition = labelPosition;
        }
        public string Label { get; set; }
        public FieldLabelPosition LabelPosition { get; set; }
        public FieldInput Input { get; set; }
    }
}