using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Layout
{
    public class FormRow : IEquatable<FormRow>
    {
        internal FormRow()
        {
        }

        public FormRow(int span, IEnumerable<FormColumn> columns)
        {
            Span = span;
            Columns = columns.ToList();
        }

        public List<FormColumn> Columns { get; set; }
        public int Span { get; set; }


        #region Equality

        public override int GetHashCode()
        {
            var hc = 0;
            if (Columns != null) hc = Columns.Aggregate(hc, (current, column) => current ^ column.GetHashCode());
            return hc;
        }

        public override bool Equals(object obj)
        {
            return obj is FormRow other && Equals(other);
        }

        public bool Equals(FormRow other)
        {
            return other != null && Columns.SequenceEqual(other.Columns);
        }

        #endregion Equality
    }
}