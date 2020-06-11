using Aptacode.Forms.Shared.Models.Enums;

namespace Aptacode.Forms.Shared.Models.Elements
{
    public abstract class FormElementModel
    {
        internal FormElementModel() { }

        protected FormElementModel(string type, string name, LabelPosition labelPosition, string label)
        {
            Name = name;
            Type = type;
            LabelPosition = labelPosition;
            Label = label;
        }

        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public string Label { get; internal set; }
        public LabelPosition LabelPosition { get; internal set; }
    }
}