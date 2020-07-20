using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.Conditions {
    public class SelectElementSelectionCondition : Specification<FormViewModel>
    {
        public SelectElementSelectionCondition(string elementName, string selectedValue)
        {
            ElementName = elementName;
            SelectedValue = selectedValue;
        }

        public string ElementName { get; set; }
        public string SelectedValue { get; set; }

        public override Expression<Func<FormViewModel, bool>> ToExpression() => vm =>
            vm.GetElement<SelectElementViewModel>(ElementName).SelectedItem == SelectedValue;
    }
}