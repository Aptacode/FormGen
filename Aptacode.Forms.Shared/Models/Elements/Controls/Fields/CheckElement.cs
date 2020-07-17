using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class CheckElement : FieldElement
    {
        internal CheckElement() { }

        public CheckElement(string name, ElementLabel label, string content, bool defaultIsChecked,
            IEnumerable<FluentValidator<ICheckElementViewModel>> rules) : base(nameof(CheckElement), name, label)
        {
            Content = content;
            DefaultIsChecked = defaultIsChecked;
            Rules = rules ?? Rules;
        }

        public CheckElement(string name, ElementLabel label, string content, bool defaultIsChecked,
            params FluentValidator<ICheckElementViewModel>[] rules) : this(name, label, content, defaultIsChecked,
            rules?.ToList()) { }

        #region Properties

        public bool DefaultIsChecked { get; set; }
        public string Content { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<FluentValidator<ICheckElementViewModel>>))]
        public IEnumerable<FluentValidator<ICheckElementViewModel>> Rules { get; set; } =
            new List<FluentValidator<ICheckElementViewModel>>();

        #endregion
    }
}