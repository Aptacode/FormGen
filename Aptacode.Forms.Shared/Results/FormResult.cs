using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Results
{
    public class FormResult
    {
        public FormResult(IEnumerable<FieldElementResult> fieldResults)
        {
            FieldResults = fieldResults;
        }

        public IEnumerable<FieldElementResult> FieldResults { get; set; }

        public FieldElementResult this[string elementName] =>
            FieldResults.FirstOrDefault(r => r.ElementName == elementName);

        public TFieldResult Get<TFieldResult>(string elementName) where TFieldResult : FieldElementResult
        {
            return this[elementName] as TFieldResult;
        }

        public IEnumerable<TFieldResult> GetAll<TFieldResult>() where TFieldResult : FieldElementResult
        {
            return FieldResults.Select(r => r as TFieldResult).Where(r => r != null);
        }
    }
}