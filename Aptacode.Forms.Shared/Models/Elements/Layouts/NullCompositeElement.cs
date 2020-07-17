namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Form Column Model
    ///     Each Column contains one form element
    /// </summary>
    public sealed class NullCompositeElement : CompositeElement
    {
        public NullCompositeElement() : base(nameof(NullCompositeElement), string.Empty, new FormElement[] { }) { }
    }
}