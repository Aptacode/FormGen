using System.Collections.ObjectModel;
using Aptacode.Forms.Elements.Fields.Results;
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

            Title = form.Title;
        }

        public Form Form { get; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public ObservableCollection<FormRowViewModel> Rows { get; set; }

        public bool IsValid => Form.IsValid;

        public FormResult GetResult() => Form.GetResult();
    }
}