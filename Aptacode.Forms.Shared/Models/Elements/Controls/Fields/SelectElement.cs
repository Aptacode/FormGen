using System.Collections.Generic;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.ValidationRules;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class SelectElement : FieldElement
    {
        #region Properties

        public string DefaultValue { get; set; }
        public IEnumerable<string> Values { get; set; } = new List<string>();

        public IEnumerable<ValidationRule<ISelectElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<ISelectElementViewModel>>();

        #endregion
    }
}