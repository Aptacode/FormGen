using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements
{
    public abstract class FormElement
    {
        protected FormElement()
        {
        }

        protected FormElement(string type, string name, LabelPosition labelPosition, string label)
        {
            Name = name;
            Type = type;
            LabelPosition = labelPosition;
            Label = label;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public LabelPosition LabelPosition { get; set; }
    }
}