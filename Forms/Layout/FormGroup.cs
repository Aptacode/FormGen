using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Layout
{
    public class FormGroup : IEquatable<FormGroup>
    {
        private const string DefaultGroupName = "Default";

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
        public static FormGroup EmptyGroup => new FormGroup(DefaultGroupName, new FormRow[0]);

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