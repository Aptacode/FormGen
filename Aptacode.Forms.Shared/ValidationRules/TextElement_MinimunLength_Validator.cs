using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MinimunLength_Validator : FluentValidator<ITextElementViewModel>
    {
        public TextElement_MinimunLength_Validator(int minLength = 0) : this(minLength,
            $"Must be greater then {minLength} characters long") { }

        public TextElement_MinimunLength_Validator(int minLength, string message) : base(message)
        {
            MinLength = minLength;
            validator
                .RuleFor(viewModel => viewModel.Content)
                .Must(content => content.Length >= MinLength)
                .WithMessage(_ => Message);
        }

        public int MinLength { get; set; }
    }
}