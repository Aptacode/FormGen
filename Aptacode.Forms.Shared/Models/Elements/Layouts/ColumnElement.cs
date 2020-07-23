namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Form Column Model
    ///     Each Column contains one form element
    /// </summary>
    public sealed class ColumnElement : CompositeElement
    {
        #region Properties

        public int Span { get; set; }

        #endregion
    }
}