namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public sealed class RowElement : CompositeElement
    {
        #region Properties

        public int Span { get; set; }

        #endregion
    }
}