namespace Aptacode.Forms.Shared.Models.Elements
{

    /// <summary>
    /// Abstract Form Element Model
    /// </summary>
    public abstract class FormElementModel
    {
        internal FormElementModel() { }

        protected FormElementModel(string elementType, string name, ElementLabel label)
        {
            Name = name;
            ElementType = elementType;
            Label = label;
        }

        #region Properties

        public string Name { get; internal set; }
        public string ElementType { get; internal set; }
        public ElementLabel Label { get; internal set; }

        #endregion
    }
}