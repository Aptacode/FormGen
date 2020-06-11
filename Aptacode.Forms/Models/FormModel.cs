using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Layout;

namespace Aptacode.Forms.Shared.Models
{
    /// <summary>
    ///     Models a Form
    ///     Contains a collection of Form Groups
    /// </summary>
    public class FormModel
    {
        internal FormModel() { }

        public FormModel(string name, string title, IEnumerable<FormGroupModel> groups)
        {
            Name = name;
            Title = title;
            Groups = groups?.ToList() ?? new List<FormGroupModel>();
        }

        #region Properties

        /// <summary>
        ///     The Forms name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///     The Forms Title
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        ///     The collection of groups that make up the form
        /// </summary>
        public IEnumerable<FormGroupModel> Groups { get; internal set; }

        #endregion
    }
}