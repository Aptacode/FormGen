namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class ControlElement : FormElement
    {
        protected ControlElement(string name, ElementLabel label) : base(name)
        {
            Label = label;
        }

        #region Properties

        public ElementLabel Label { get; set; }

        #endregion
    }
}