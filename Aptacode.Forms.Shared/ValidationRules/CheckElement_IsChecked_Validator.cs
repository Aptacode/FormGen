using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class CheckElement_IsChecked_Validator : FluentValidator<ICheckElementViewModel>
    {
        public CheckElement_IsChecked_Validator(string message = "") : base(message)
        {
            validator.RuleFor(viewModel => viewModel.IsChecked).Equal(true).WithMessage(Message);
        }
    }
}