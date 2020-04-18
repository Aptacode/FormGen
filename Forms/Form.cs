using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.Results;

namespace Aptacode.Forms
{
    public class Form
    {
        public Form()
        {
        }

        public Form(string name, string title, IEnumerable<FormGroup> groups)
        {
            Name = name;
            Title = title;
            Groups = groups;
        }

        public string Name { get; set; }
        public string Title { get; set; }

        public IEnumerable<FormGroup> Groups { get; set; }

        public bool IsValid => Fields().All(field => field.IsValid());

        private IEnumerable<FormField> Fields()
        {
            return Groups
                .Select(group => group.Rows).Aggregate((a, b) => a.Concat(b))
                .Select(row => row.Columns).Aggregate((a, b) => a.Concat(b))
                .Select(column => column.Element as FormField)
                .Where(field => field != null);
        }

        public IEnumerable<FieldResult> GetResults()
        {
            return Fields().Select(field => field.GetResult());
        }

        public FormResult GetResult()
        {
            return new FormResult(this, GetResults());
        }
    }
}