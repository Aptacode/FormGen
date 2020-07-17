namespace Aptacode.Forms.Shared.Results
{
    public abstract class FieldElementResult
    {
        internal FieldElementResult() { }

        protected FieldElementResult(string elementName)
        {
            ElementName = elementName;
        }

        public string ElementName { get; set; }
    }
}