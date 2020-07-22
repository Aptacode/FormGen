using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class CheckElement : FieldElement
    {
        internal CheckElement() { }

        public CheckElement(string name, ElementLabel label, VerticalAlignment alignment, string content, bool defaultIsChecked,
            IEnumerable<ValidationRule<ICheckElementViewModel>> rules) : base(name, label, alignment)
        {
            Content = content;
            DefaultIsChecked = defaultIsChecked;
            Rules = rules ?? Rules;
        }

        public CheckElement(string name, ElementLabel label, VerticalAlignment alignment, string content, bool defaultIsChecked,
            params ValidationRule<ICheckElementViewModel>[] rules) : this(name, label, alignment, content, defaultIsChecked,
            rules?.ToList()) { }

        #region Properties

        public bool DefaultIsChecked { get; set; }
        public string Content { get; set; }

        public IEnumerable<ValidationRule<ICheckElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ICheckElementViewModel>>();

        #endregion
    }
}