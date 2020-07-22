namespace Aptacode.Forms.Shared.Models.Elements
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class FormElement
    {
        internal FormElement() { }

        protected FormElement(string name)
        {
            Name = name;
        }

        #region Properties

        public string Name { get; set; }

        #endregion
    }
}