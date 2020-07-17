using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class TextElement : FieldElement
    {
        internal TextElement() { }

        public TextElement(string name, ElementLabel label, string defaultContent,
            params FluentValidator<ITextElementViewModel>[] rules) :
            this(name, label, defaultContent, rules?.ToList()) { }

        public TextElement(string name, ElementLabel label, string defaultContent,
            IEnumerable<FluentValidator<ITextElementViewModel>> rules) : base(
            nameof(TextElement), name, label)
        {
            DefaultContent = defaultContent;

            Rules = rules ?? Rules;
        }

        #region Properties

        public string DefaultContent { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<FluentValidator<ITextElementViewModel>>))]
        public IEnumerable<FluentValidator<ITextElementViewModel>> Rules { get; set; } =
            new List<FluentValidator<ITextElementViewModel>>();

        #endregion
    }
}