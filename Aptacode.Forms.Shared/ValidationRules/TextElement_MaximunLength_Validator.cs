using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MaximunLength_Validator : FluentValidator<ITextElementViewModel>
    {
        public TextElement_MaximunLength_Validator(int maxLength = int.MaxValue) : base(
            nameof(TextElement_MaximunLength_Validator))
        {
            MaxLength = maxLength;
            validator.RuleFor(viewModel => viewModel.Content).Must(content => content.Length > MaxLength)
                .WithMessage(_ => $"Must be less then {MaxLength} characters long");
        }

        public int MaxLength { get; set; }
    }
}