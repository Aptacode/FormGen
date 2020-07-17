namespace Aptacode.Forms.Shared.Models.Elements
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class FormElement
    {
        internal FormElement() { }

        protected FormElement(string elementType, string name)
        {
            Name = name;
            ElementType = elementType;
        }

        #region Properties

        public string Name { get; set; }
        public string ElementType { get; set; }

        #endregion
    }
}