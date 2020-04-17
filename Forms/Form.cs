using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Fields;
using Aptacode.Forms.Results;

namespace Aptacode.Forms
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

        public bool IsValid => Fields().All(field => field.IsValid());

        private IEnumerable<FormField> Fields()
        {
            return Rows.Select(row => row.Element as FormField).Where(field => field != null);
        }

        public IEnumerable<FieldResult> GetResults() => Fields().Select(field => field.GetResult());

        public FormResult GetResult() => new FormResult(this, GetResults());

    }
}