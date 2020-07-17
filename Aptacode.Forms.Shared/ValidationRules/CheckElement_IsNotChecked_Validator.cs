using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class CheckElement_IsNotChecked_Validator : FluentValidator<ICheckElementViewModel>
    {
        public CheckElement_IsNotChecked_Validator() : base(nameof(CheckElement_IsNotChecked_Validator))
        {
            validator.RuleFor(viewModel => viewModel.IsChecked).Equals(false);
        }
    }
}