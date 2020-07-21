using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using System;
using System.Linq.Expressions;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MinimunLength_Validator : Specification<ITextElementViewModel>
    {
        public int MinimunLength { get; set; }
        public TextElement_MinimunLength_Validator(int minimunLength)
        {
            MinimunLength = minimunLength;
        }
        public override Expression<Func<ITextElementViewModel, bool>> ToExpression() => textElement => textElement.Content.Length >= MinimunLength;
    }
}