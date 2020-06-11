using System.Collections.Generic;
using Aptacode.Forms.Shared.Models.Layout;

namespace Aptacode.Forms.Shared.Models
{
    public class FormModel
    {
        internal FormModel() { }

        public FormModel(string name, string title, IEnumerable<FormGroupModel> groups)
        {
            Name = name;
            Title = title;
            Groups = new List<FormGroupModel>(groups);
        }

        #region Properties

        public string Name { get; internal set; }
        public string Title { get; internal set; }
        public IEnumerable<FormGroupModel> Groups { get; internal set; }

        #endregion
    }
}