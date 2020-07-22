namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class ControlElement : FormElement
    {
        public enum VerticalAlignment
        {
            Center, Top, Bottom
        }
        internal ControlElement() { }

        protected ControlElement(string name, ElementLabel label, VerticalAlignment alignment) : base(name)
        {
            Label = label;
            Alignment = alignment;
        }

        #region Properties

        public ElementLabel Label { get; set; }

        public VerticalAlignment Alignment { get; set; }


        #endregion
    }
}