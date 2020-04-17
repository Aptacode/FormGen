using System.Collections.Generic;
using Aptacode.Forms.Forms.Fields;

namespace Aptacode.Forms.Forms
{
    public class Form
    {
        public Form()
        {
                
        }

        public Form(string name, string title, IEnumerable<FormRow> rows)
        {
            Name = name;
            Title = title;
            Rows = rows;
        }

        public string Name { get; set; }
        public string Title { get; set; }

        public IEnumerable<FormRow> Rows { get; set; }
    }
}
