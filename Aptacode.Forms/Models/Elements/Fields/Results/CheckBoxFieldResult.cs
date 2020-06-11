using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.Results
{
    public class CheckBoxFieldResult : FieldResult
    {
        internal CheckBoxFieldResult() { }

        public CheckBoxFieldResult(ICheckBoxFieldViewModel viewModel, CheckBoxFieldModel model) : base(model)
        {
            IsChecked = viewModel.IsChecked;
            Model = model;
        }

        public new CheckBoxFieldModel Model { get; internal set; }
        public bool IsChecked { get; internal set; }
    }
}