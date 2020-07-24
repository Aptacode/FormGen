using System.Collections.Generic;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class TextElement : FieldElement
    {
        #region Properties

        public string DefaultValue { get; set; }

        public IEnumerable<ValidationRule<ITextElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ITextElementViewModel>>();

        #endregion
    }
}