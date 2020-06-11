using System.IO;
using System.Windows;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Events;
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

        private void NameForm_OnFormEvent(object sender, FormEventArgs e)
        {
            if (e is ButtonClickedEventArgs buttonClickedEvent && sender is ButtonElementViewModel button)
            {
                return;
            }

            Submit();
        }

        private void Submit()
        {
            if (_formViewModel.IsValid)
            {
                var formResults = _formViewModel.GetResult();
                File.WriteAllText("./results.json", JsonConvert.SerializeObject(formResults, Formatting.Indented));

                MessageBox.Show("Submitted");
            }
            else
            {
                MessageBox.Show(_formViewModel.GetValidationMessage());
            }
        }

        #region Event Handlers

        private void OnFormSelected(object sender, FormViewModel e)
        {
            FormViewModel = e;
            FormViewModel.OnFormEvent += NameForm_OnFormEvent;
        }

        private void OnNewForm(object sender, FormViewModel e)
        {
            FormDesignerViewModel.Load(FormIO.CreateForm().Model);
        }

        private void OnOpenForm(object sender, FormViewModel e)
        {
            var openFileDialog = new OpenFileDialog {Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"};

            if (openFileDialog.ShowDialog() == true)
            {
                var jsonString = File.ReadAllText(openFileDialog.FileName);
                //    FormDesignerViewModel.Load(FormModel.FromJson(jsonString));
            }
            else
            {
                FormDesignerViewModel.Clear();
            }
        }

        private void OnSaveForm(object sender, FormViewModel e)
        {
            //    File.WriteAllText($"{FormViewModel.Form.Name}.json", FormViewModel.Form.ToJson());
        }

        #endregion

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        public FormDesignerViewModel FormDesignerViewModel { get; set; }

        #endregion
    }
}