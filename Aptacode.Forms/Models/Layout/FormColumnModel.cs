using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Json;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Layout
{
    public class FormColumnModel
    {
        internal FormColumnModel() { }

        public FormColumnModel(int span, FormElementModel element)
        {
            Element = element;
            Span = span;
        }

        [JsonConverter(typeof(FormElementJsonConverter))]
        public FormElementModel Element { get; internal set; }

        public int Span { get; }
    }
}