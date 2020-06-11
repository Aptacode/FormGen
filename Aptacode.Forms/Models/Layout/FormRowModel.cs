using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Models.Layout
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public class FormRowModel
    {
        internal FormRowModel() { }

        public FormRowModel(string name, int span, IEnumerable<FormColumnModel> columns)
        {
            Span = span;
            Name = name;
            Columns = columns?.ToList() ?? new List<FormColumnModel>();
        }

        #region Properties

        public string Name { get; internal set; }
        public int Span { get; internal set; }
        public IEnumerable<FormColumnModel> Columns { get; internal set; }

        #endregion
    }
}