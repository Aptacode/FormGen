using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Models.Layout
{
    public class FormRowModel : IEquatable<FormRowModel>
    {
        internal FormRowModel() { }

        public FormRowModel(string name, int span, IEnumerable<FormColumnModel> columns)
        {
            Span = span;
            Name = name;
            Columns = columns.ToList();
        }

        #region Properties

        public string Name { get; internal set; }
        public int Span { get; internal set; }
        public IEnumerable<FormColumnModel> Columns { get; internal set; }

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

        public override bool Equals(object obj) => obj is FormRowModel other && Equals(other);

        public bool Equals(FormRowModel other) =>
            other != null && Name == other.Name && Columns.SequenceEqual(other.Columns);

        #endregion Equality
    }
}