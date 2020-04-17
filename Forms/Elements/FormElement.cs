namespace Aptacode.Forms.Elements
{
    public abstract class FormElement
    {
        protected FormElement()
        {
        }

        protected FormElement(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}