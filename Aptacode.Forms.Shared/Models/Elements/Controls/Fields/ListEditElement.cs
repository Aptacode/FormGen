using System;
using System.Collections.Generic;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.ValidationRules;

namespace Aptacode.Forms.Shared.Models.Elements.Controls.Fields
{
    public class ListEditElement : FieldElement
    {
        #region Properties

        public IEnumerable<FormElement> Values { get; set; } = new List<FormElement>();

        public Func<FormElement> CreateItem { get; set; }

        public IEnumerable<ValidationRule<IListEditElementViewModel>> Rules { get; set; } =
            new List<ValidationRule<IListEditElementViewModel>>();

        #endregion
    }
}