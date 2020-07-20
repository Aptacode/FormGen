namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Form Group Model
    ///     Contains a collection of form rows
    /// </summary>
    public class GroupElement : CompositeElement
    {
        public GroupElement(string name, string title, params FormElement[] children) : base(name, children)
        {
            Title = title;
        }

        #region Properties

        public string Title { get; set; }

        #endregion
    }
}