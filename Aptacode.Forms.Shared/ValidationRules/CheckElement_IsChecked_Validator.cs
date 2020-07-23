using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class CheckElement_IsChecked_Validator : Specification<ICheckElementViewModel>
    {
        public override Expression<Func<ICheckElementViewModel, bool>> ToExpression() => element => element.IsChecked;
    }
}