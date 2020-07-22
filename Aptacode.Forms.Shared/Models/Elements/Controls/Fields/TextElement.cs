using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class TextElement : FieldElement
    {
        internal TextElement() { }

        public TextElement(string name, ElementLabel label, VerticalAlignment verticalAlignment, string defaultContent,
            params ValidationRule<ITextElementViewModel>[] rules) :
            this(name, label, verticalAlignment, defaultContent, rules?.ToList()) { }

        public TextElement(string name, ElementLabel label, VerticalAlignment alignment, string defaultContent,
            IEnumerable<ValidationRule<ITextElementViewModel>> rules) : base(name, label, alignment)
        {
            DefaultContent = defaultContent;

            Rules = rules ?? Rules;
        }

        #region Properties

        public string DefaultContent { get; set; }

        public IEnumerable<ValidationRule<ITextElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ITextElementViewModel>>();

        #endregion
    }
}