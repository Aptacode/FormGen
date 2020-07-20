using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class TextElement : FieldElement
    {
        public TextElement(string name, ElementLabel label, string defaultContent,
            params FluentValidator<ITextElementViewModel>[] rules) :
            this(name, label, defaultContent, rules?.ToList()) { }

        public TextElement(string name, ElementLabel label, string defaultContent,
            IEnumerable<FluentValidator<ITextElementViewModel>> rules) : base(name, label)
        {
            DefaultContent = defaultContent;

            Rules = rules ?? Rules;
        }

        #region Properties

        public string DefaultContent { get; set; }

        public IEnumerable<FluentValidator<ITextElementViewModel>> Rules { get; set; } =
            new List<FluentValidator<ITextElementViewModel>>();

        #endregion
    }
}