using System.Collections.Generic;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.ValidationRules;

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