using System.Collections.ObjectModel;
using Aptacode.Forms.Elements.Fields.Results;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormViewModel : BindableBase
    {
        private string _title;

        public FormViewModel(Form form)
        {
            Form = form;
            Groups = new ObservableCollection<FormGroupViewModel>();

            foreach (var formRow in form.Groups)
            {
                Groups.Add(new FormGroupViewModel(formRow));
            }

            Title = form.Title;
        }

        public Form Form { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ObservableCollection<FormGroupViewModel> Groups { get; set; }

        public bool IsValid => Form.IsValid;

        public FormResult GetResult()
        {
            return Form.GetResult();
        }
    }
}