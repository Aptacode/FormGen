using System.IO;
using System.Windows;
using Aptacode.Forms.Events;
using Aptacode.Forms.Wpf.ViewModels;
using Aptacode.Forms.Wpf.ViewModels.Designer;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private Form _form;
        private FormViewModel _formViewModel;

        public MainWindowViewModel()
        {
            FormDesignerViewModel = new FormDesignerViewModel();
            FormDesignerViewModel.OnFormSelected += OnFormSelected;
        }

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        public FormDesignerViewModel FormDesignerViewModel { get; set; }

        private void OnFormSelected(object sender, FormViewModel e)
        {
            FormViewModel = e;

            _form = e.Form;
            _form.OnFormEvent += NameForm_OnFormEvent;
        }

        private void NameForm_OnFormEvent(object sender, FormEventArgs e)
        {
            if (!(e is ButtonClickedEventArgs buttonClickedEvent) || buttonClickedEvent.Button.Name != "SubmitButton")
            {
                return;
            }

            Submit();
        }

        private void Submit()
        {
            if (_form.IsValid)
            {
                var formResults = _form.GetResult();
                File.WriteAllText("./results.json", JsonConvert.SerializeObject(formResults, Formatting.Indented));

                MessageBox.Show("Submitted");
            }
            else
            {
                MessageBox.Show(_form.GetValidationMessage());
            }
        }
    }
}