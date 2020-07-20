namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public sealed class RowElement : CompositeElement
    {
        public RowElement(string name, int span, params FormElement[] children) : base(name,
            children)
        {
            Span = span;
        }

        #region Properties

        public int Span { get; set; }

        #endregion
    }
}