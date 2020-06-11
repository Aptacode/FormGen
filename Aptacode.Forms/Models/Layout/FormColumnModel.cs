using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Json;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Layout
{
    /// <summary>
    ///     Form Column Model
    ///     Each Column contains one form element
    /// </summary>
    public class FormColumnModel
    {
        internal FormColumnModel() { }

        public FormColumnModel(string name, int span, FormElementModel element)
        {
            Name = name;
            Element = element;
            Span = span;
        }

        #region Properties

        public string Name { get; }
        public int Span { get; }

        [JsonConverter(typeof(FormElementJsonConverter))]
        public FormElementModel Element { get; internal set; }

        #endregion
    }
}