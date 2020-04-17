using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormViewModel : BindableBase
    {
        public Form Form { get; }

        public FormViewModel(Form form)
        {
            Form = form;
        }

        public ObservableCollection<FormRowViewModel> Rows { get; set; }

    }
}
