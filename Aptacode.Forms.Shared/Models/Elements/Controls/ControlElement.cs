namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class ControlElement : FormElement
    {
        public enum VerticalAlignment
        {
            Center,
            Top,
            Bottom
        }

        #region Properties

        public ElementLabel Label { get; set; }

        public VerticalAlignment Alignment { get; set; }

        #endregion
    }
}