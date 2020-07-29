using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MinimunLength_Validator : Specification<ITextElementViewModel>
    {
        public TextElement_MinimunLength_Validator(int minimunLength)
        {
            MinimunLength = minimunLength;
        }

        public int MinimunLength { get; set; }

        public override Expression<Func<ITextElementViewModel, bool>> ToExpression() =>
            textElement => textElement.Content.Length >= MinimunLength;
    }
}