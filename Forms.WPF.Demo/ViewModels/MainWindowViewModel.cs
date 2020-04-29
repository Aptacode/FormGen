using System.IO;
using System.Windows;
using Aptacode.Forms.Events;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels;
using Aptacode.Forms.Wpf.ViewModels.Designer;
using Microsoft.Win32;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            FormDesignerViewModel = new FormDesignerViewModel();
            FormDesignerViewModel.OnFormSelected += OnFormSelected;
            FormDesignerViewModel.OnNewForm += OnNewForm;
            FormDesignerViewModel.OnSaveForm += OnSaveForm;
            FormDesignerViewModel.OnOpenForm += OnOpenForm;

        }

        #region Event Handlers
        private void OnFormSelected(object sender, FormViewModel e)
        {
            FormViewModel = e;

            _form = e.Form;
            _form.OnFormEvent += NameForm_OnFormEvent;
        }
        private void OnNewForm(object sender, FormViewModel e)
        {
            FormDesignerViewModel.Load(new Form("New Form", "Form Title", new FormGroup[0]));
        }

        private void OnOpenForm(object sender, FormViewModel e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var jsonString = File.ReadAllText(openFileDialog.FileName);
                FormDesignerViewModel.Load(Form.FromJson(jsonString));
            }
            else
            {
                FormDesignerViewModel.Clear();
            }
        }

        private void OnSaveForm(object sender, FormViewModel e)
        {
            File.WriteAllText($"{FormViewModel.Form.Name}.json", FormViewModel.Form.ToJson());
        }

        #endregion

        #region Properties
        private Form _form;

        private FormViewModel _formViewModel;
        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        public FormDesignerViewModel FormDesignerViewModel { get; set; }

        #endregion


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