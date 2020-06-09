using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Layout
{
    public class FormGroup : IEquatable<FormGroup>
    {
        public static readonly string DefaultName = "Default";

        internal FormGroup()
        {
        }

        public FormGroup(string label, IEnumerable<FormRow> rows)
        {
            Label = label;
            Rows = rows.ToList();
        }

        public string Label { get; set; }
        public List<FormRow> Rows { get; set; }
        public static FormGroup EmptyGroup => new FormGroup(DefaultName, new FormRow[0]);

        #region Equality

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FormGroup other && Equals(other);
        }

        public bool Equals(FormGroup other)
        {
            return other != null && Label.Equals(other.Label);
        }

        #endregion Equality
    }
}