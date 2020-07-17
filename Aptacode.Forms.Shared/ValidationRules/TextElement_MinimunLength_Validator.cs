using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MinimunLength_Validator : FluentValidator<ITextElementViewModel>
    {
        public TextElement_MinimunLength_Validator(int minLength = 0) : base(
            nameof(TextElement_MinimunLength_Validator))
        {
            MinLength = minLength;
            validator.RuleFor(viewModel => viewModel.Content).Must(content => content.Length > MinLength)
                .WithMessage(_ => $"Must be greater then {MinLength} characters long");
        }

        public int MinLength { get; set; }
    }
}