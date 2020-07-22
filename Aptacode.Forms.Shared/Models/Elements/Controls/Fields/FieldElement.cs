namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public abstract class FieldElement : ControlElement
    {
        internal FieldElement() { }

        protected FieldElement(string name, ElementLabel label, VerticalAlignment alignment) : base(name, label, alignment) { }
    }
}