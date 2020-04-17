namespace Aptacode.Forms.Forms.Fields
{
    public abstract class FormRow
    {
        protected FormRow()
        {
            
        }
        protected FormRow(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }

    }
}