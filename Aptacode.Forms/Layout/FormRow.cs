using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Layout
{
    public class FormRow : IEquatable<FormRow>
    {
        internal FormRow()
        {
            Span = 0;
            Name = string.Empty;
            Columns = new List<FormColumn>();
        }

        public FormRow(int span, string name, IEnumerable<FormColumn> columns) : this()
        {
            Span = span;
            Name = name;
            Columns = columns.ToList();
        }

        #region Properties

        public string Name { get; set; }
        public List<FormColumn> Columns { get; set; }
        public int Span { get; set; }
        public static readonly string DefaultName = "Default";
        public static FormRow EmptyRow => new FormRow(1, DefaultName, new FormColumn[0]);

        #endregion

        #region Equality

        public override int GetHashCode()
        {
            var hc = 0;
            if (Columns != null)
            {
                hc = Columns.Aggregate(hc, (current, column) => current ^ column.GetHashCode());
            }

            return hc ^ Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FormRow other && Equals(other);
        }

        public bool Equals(FormRow other)
        {
            return other != null && Name == other.Name && Columns.SequenceEqual(other.Columns);
        }

        #endregion Equality
    }
}