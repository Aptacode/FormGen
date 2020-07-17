namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public abstract class FieldElement : ControlElement
    {
        internal FieldElement() { }

        protected FieldElement(string type, string name, ElementLabel label) : base(
            type, name, label) { }
    }
}