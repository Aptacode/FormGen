using System;
using Aptacode.Forms.Elements;

namespace Aptacode.Forms.Layout
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