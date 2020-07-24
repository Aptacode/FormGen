using System.Collections.Generic;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class CheckElement : FieldElement
    {
        #region Properties

        public bool DefaultValue { get; set; }
        public string Content { get; set; }

        public IEnumerable<ValidationRule<ICheckElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ICheckElementViewModel>>();

        #endregion
    }
}