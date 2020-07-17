using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models;

namespace Aptacode.Forms.Shared.Results
{
    public class FormResult
    {
        internal FormResult() { }

        public FormResult(Form form, IEnumerable<FieldElementResult> fieldResults)
        {
            Form = form;
            FieldResults = fieldResults;
        }

        public Form Form { get; set; }

        public IEnumerable<FieldElementResult> FieldResults { get; set; }

        public FieldElementResult this[string elementName] =>
            FieldResults.FirstOrDefault(r => r.ElementName == elementName);

        public TFieldResult Get<TFieldResult>(string elementName) where TFieldResult : FieldElementResult =>
            this[elementName] as TFieldResult;

        public IEnumerable<TFieldResult> GetAll<TFieldResult>() where TFieldResult : FieldElementResult
        {
            return FieldResults.Select(r => r as TFieldResult).Where(r => r != null);
        }
    }
}