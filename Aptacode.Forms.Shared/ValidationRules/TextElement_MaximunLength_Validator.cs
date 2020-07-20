using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MaximunLength_Validator : FluentValidator<ITextElementViewModel>
    {
        public TextElement_MaximunLength_Validator(int maxLength = int.MaxValue) : this(maxLength,
            $"Must be less then {maxLength} characters long") { }

        public TextElement_MaximunLength_Validator(int maxLength, string message) : base(message)
        {
            MaxLength = maxLength;
            validator
                .RuleFor(viewModel => viewModel.Content)
                .Must(content => content.Length <= MaxLength)
                .WithMessage(_ => Message);
        }

        public int MaxLength { get; set; }
    }
}