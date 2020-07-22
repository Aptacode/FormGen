using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using System;
using System.Linq.Expressions;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class SelectElement_SelectionMade_Validator : Specification<ISelectElementViewModel>
    {
        public string SelectedItem { get; set; }
        public SelectElement_SelectionMade_Validator(string selectedItem)
        {
            SelectedItem = selectedItem;
        }
        public override Expression<Func<ISelectElementViewModel, bool>> ToExpression() => element => element.SelectedItem == SelectedItem;
    }
}