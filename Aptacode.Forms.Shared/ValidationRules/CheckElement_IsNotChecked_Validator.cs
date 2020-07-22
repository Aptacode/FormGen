using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using System;
using System.Linq.Expressions;

namespace Aptacode.Forms.Shared.ValidationRules
{
   
    public class CheckElement_IsNotChecked_Validator : Specification<ICheckElementViewModel>
    {
        public override Expression<Func<ICheckElementViewModel, bool>> ToExpression() => element => !element.IsChecked;
    }
}