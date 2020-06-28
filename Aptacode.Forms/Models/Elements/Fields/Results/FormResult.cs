using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.Results
{
    public class FormResult
    {
        internal FormResult() { }

        public FormResult(FormModel form, IEnumerable<FieldResult> fieldResults)
        {
            Form = form;
            FieldResults = fieldResults;
        }

        public FormModel Form { get; internal set; }

        public IEnumerable<FieldResult> FieldResults { get; internal set; }
        
        public FieldResult this[string elementName] => FieldResults.FirstOrDefault(r => r.Model.Name.Equals(elementName));

        public TFieldResult Get<TFieldResult>(string elementName) where TFieldResult : FieldResult
        {
            return this[elementName] as TFieldResult;
        }

        public IEnumerable<TFieldResult> GetAll<TFieldResult>() where TFieldResult : FieldResult
        {
            return FieldResults.Select(r => r as TFieldResult).Where(r => r != null);
        }
    }
}