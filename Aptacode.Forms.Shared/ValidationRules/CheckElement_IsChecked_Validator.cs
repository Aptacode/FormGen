using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class CheckElement_IsChecked_Validator : FluentValidator<ICheckElementViewModel>
    {
        public CheckElement_IsChecked_Validator() : base(nameof(CheckElement_IsChecked_Validator))
        {
            validator.RuleFor(viewModel => viewModel.IsChecked).Equals(true);
        }
    }
}