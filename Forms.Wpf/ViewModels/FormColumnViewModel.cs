using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Factories;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormColumnViewModel : BindableBase
    {
        private FormElementViewModel _formElementViewModel;

        public FormColumnViewModel(FormColumn column)
        {
            Column = column;
            FormElementViewModel = FormElementViewModelFactory.Create(column.Element);
        }

        public FormColumn Column { get; }

        public FormElementViewModel FormElementViewModel
        {
            get => _formElementViewModel;
            set => SetProperty(ref _formElementViewModel, value);
        }
    }
}