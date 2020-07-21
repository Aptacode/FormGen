namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Form Column Model
    ///     Each Column contains one form element
    /// </summary>
    public sealed class ColumnElement : CompositeElement
    {
        public ColumnElement(string name, int span, params FormElement[] children) : base(name,
            children)
        {
            Span = span;
        }

        #region Properties

        public int Span { get; set; }

        #endregion
    }
}