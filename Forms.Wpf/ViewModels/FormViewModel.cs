using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormViewModel : BindableBase
    {
        public FormViewModel(Form form)
        {
            Form = form;
            Rows = new ObservableCollection<FormRowViewModel>();

            foreach (var formRow in form.Rows)
            {
                Rows.Add(new FormRowViewModel(formRow));
            }
        }

        public Form Form { get; }

        public ObservableCollection<FormRowViewModel> Rows { get; set; }
    }
}