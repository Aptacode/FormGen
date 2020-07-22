using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class SelectElement : FieldElement
    {
        internal SelectElement() { }

        public SelectElement(string name, ElementLabel label, VerticalAlignment alignment, IEnumerable<string> items,
            string defaultSelectedItem, IEnumerable<ValidationRule<ISelectElementViewModel>> rules) : base(name, label, alignment)
        {
            DefaultSelectedItem = defaultSelectedItem;
            Items = items ?? Items;
            Rules = rules ?? Rules;
        }

        public SelectElement(string name, ElementLabel label, VerticalAlignment alignment, IEnumerable<string> items,
            string defaultSelectedItem, params ValidationRule<ISelectElementViewModel>[] rules) : this(name, label,alignment,
            items, defaultSelectedItem, rules?.ToList()) { }

        #region Properties

        public string DefaultSelectedItem { get; set; }
        public IEnumerable<string> Items { get; set; } = new List<string>();

        public IEnumerable<ValidationRule<ISelectElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ISelectElementViewModel>>();

        #endregion
    }
}