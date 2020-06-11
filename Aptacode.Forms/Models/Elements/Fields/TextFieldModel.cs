using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Json;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    [JsonConverter(typeof(SingleOrArrayConverter<ValidationRule<ITextFieldViewModel>>))]
    public class TextFieldModel : FormFieldModel<ITextFieldViewModel>
    {
        internal TextFieldModel() { }

        public TextFieldModel(string name, ElementLabel label, string defaultContent,
            params ValidationRule<ITextFieldViewModel>[] rules) : this(name, label, defaultContent, rules?.ToList()) { }

        public TextFieldModel(string name, ElementLabel label, string defaultContent,
            IEnumerable<ValidationRule<ITextFieldViewModel>> rules) : base(
            nameof(TextFieldModel), name, label, rules)
        {
            DefaultContent = defaultContent;
        }

        #region Properties

        public string DefaultContent { get; internal set; }

        #endregion
    }
}