using Aptacode.Forms.Fields;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Factories;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormRowViewModel : BindableBase
    {
        private FormElementViewModel _formElementViewModel;

        public FormRowViewModel(FormRow row)
        {
            Row = row;
            FormElementViewModel = FormElementViewModelFactory.Create(row.Element);
        }

        public FormRow Row { get; }

        public FormElementViewModel FormElementViewModel
        {
            get => _formElementViewModel;
            set => SetProperty(ref _formElementViewModel, value);
        }
    }
}