using System;
using Aptacode.Forms.Shared.Elements;
using Aptacode.Forms.Shared.Json;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Layout
{
    public class FormColumn : IEquatable<FormColumn>
    {
        internal FormColumn()
        {
        }

        public FormColumn(int span, FormElement element)
        {
            Element = element;
            Span = span;
        }

        [JsonConverter(typeof(FormElementJsonConverter))]
        public FormElement Element { get; set; }

        public int Span { get; set; }

        #region Equality

        public override int GetHashCode()
        {
            return Element.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FormColumn other && Equals(other);
        }

        public bool Equals(FormColumn other)
        {
            return other != null && Element.Equals(other.Element);
        }

        #endregion Equality
    }
}