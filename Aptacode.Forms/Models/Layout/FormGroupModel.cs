using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Models.Layout
{
    /// <summary>
    ///     Form Group Model
    ///     Contains a collection of form rows
    /// </summary>
    public class FormGroupModel
    {
        internal FormGroupModel() { }

        public FormGroupModel(string name, string title, IEnumerable<FormRowModel> rows)
        {
            Name = name;
            Title = title;
            Rows = rows?.ToList() ?? new List<FormRowModel>();
        }

        #region Properties

        public string Name { get; internal set; }
        public string Title { get; internal set; }
        public IEnumerable<FormRowModel> Rows { get; internal set; }

        #endregion
    }
}