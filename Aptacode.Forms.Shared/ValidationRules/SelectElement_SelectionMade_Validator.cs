using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class SelectElement_SelectionMade_Validator : Specification<ISelectElementViewModel>
    {
        public SelectElement_SelectionMade_Validator(string selectedItem)
        {
            SelectedItem = selectedItem;
        }

        public string SelectedItem { get; set; }

        public override Expression<Func<ISelectElementViewModel, bool>> ToExpression() =>
            element => element.SelectedItem == SelectedItem;
    }
}