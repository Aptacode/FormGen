using System;
using System.Collections.Generic;

namespace Aptacode.Forms.Shared.Models.Layout
{
    public class FormGroupModel : IEquatable<FormGroupModel>
    {
        internal FormGroupModel() { }

        public FormGroupModel(string label, IEnumerable<FormRowModel> rows)
        {
            Label = label;
            Rows = new List<FormRowModel>(rows);
        }

        public string Label { get; internal set; }
        public IEnumerable<FormRowModel> Rows { get; internal set; }

        #region Equality

        public override int GetHashCode() => Label.GetHashCode();
        public override bool Equals(object obj) => obj is FormGroupModel other && Equals(other);
        public bool Equals(FormGroupModel other) => other != null && Label.Equals(other.Label);

        #endregion Equality
    }
}