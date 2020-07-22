using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;
using System;
using System.Linq.Expressions;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MaximumLength_Validator : Specification<ITextElementViewModel>
    {
        public int MaxLength { get; set; }
        public TextElement_MaximumLength_Validator(int maxLength)
        {
            MaxLength = maxLength;
        }
        public override Expression<Func<ITextElementViewModel, bool>> ToExpression() => textElement => textElement.Content.Length <= MaxLength;
    }
}