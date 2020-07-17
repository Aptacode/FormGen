using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class SelectElement : FieldElement
    {
        internal SelectElement() { }

        public SelectElement(string name, ElementLabel label, IEnumerable<string> items,
            string defaultSelectedItem, IEnumerable<FluentValidator<ISelectElementViewModel>> rules) : base(
            nameof(SelectElement), name, label)
        {
            DefaultSelectedItem = defaultSelectedItem;
            Items = items ?? Items;
            Rules = rules ?? Rules;
        }

        public SelectElement(string name, ElementLabel label, IEnumerable<string> items,
            string defaultSelectedItem, params FluentValidator<ISelectElementViewModel>[] rules) : this(name, label,
            items, defaultSelectedItem, rules?.ToList()) { }

        #region Properties

        public string DefaultSelectedItem { get; set; }
        public IEnumerable<string> Items { get; set; } = new List<string>();

        [JsonConverter(typeof(SingleOrArrayConverter<FluentValidator<ISelectElementViewModel>>))]
        public IEnumerable<FluentValidator<ISelectElementViewModel>> Rules { get; set; } =
            new List<FluentValidator<ISelectElementViewModel>>();

        #endregion
    }
}