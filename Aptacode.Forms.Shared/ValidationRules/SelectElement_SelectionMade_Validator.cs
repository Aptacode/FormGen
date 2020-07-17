using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using FluentValidation;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class SelectElement_SelectionMade_Validator : FluentValidator<ISelectElementViewModel>
    {
        public SelectElement_SelectionMade_Validator() : base(nameof(SelectElement_SelectionMade_Validator))
        {
            validator.RuleFor(viewModel => viewModel.SelectedItem).NotEmpty().NotNull()
                .WithMessage("You must make a selection");
        }
    }
}