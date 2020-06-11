using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.Models.Elements.Fields.Results
{
    public class ComboBoxFieldResult : FieldResult
    {
        internal ComboBoxFieldResult() { }

        public ComboBoxFieldResult(IComboBoxFieldViewModel viewModel, ComboBoxFieldModel model) : base(model)
        {
            SelectedItem = viewModel.SelectedItem;
        }

        public new ComboBoxFieldModel Model { get; internal set; }
        public string SelectedItem { get; internal set; }
    }
}