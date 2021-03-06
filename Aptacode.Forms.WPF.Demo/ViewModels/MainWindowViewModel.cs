﻿using System.IO;
using System.Windows;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Json;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Wpf.ViewModels.Designer;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            FormDesignerViewModel = new FormDesignerViewModel();
            FormViewModel = DemoForm.CreateForm();
        }

        private void FormViewModelOnOnTriggered(object sender, (EventListener, FormElementEvent) e)
        {
            switch (e.Item1.Name)
            {
                case "submit":
                    Submit();
                    break;
                case "tooLittleExperiance":
                    MessageBox.Show("Sorry you've too little exp!");
                    break;
            }
        }

        private void Submit()
        {
            if (_formViewModel.IsValid)
            {
                File.WriteAllText("./results.json", JsonConvert.SerializeObject(
                    _formViewModel.Results,
                    SerializerSettings));
            }
            else
            {
                MessageBox.Show(_formViewModel.ValidationMessage);
            }
        }

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set
            {
                SetProperty(ref _formViewModel, value);
                FormDesignerViewModel.FormViewModel = FormViewModel;
                if (FormViewModel != null)
                {
                    FormViewModel.OnTriggered += FormViewModelOnOnTriggered;
                }
            }
        }

        public FormDesignerViewModel FormDesignerViewModel { get; set; }

        public JsonSerializerSettings SerializerSettings { get; } =
            new JsonSerializerSettings {Formatting = Formatting.Indented}
                .AddElementConverter()
                .AddEventSpecificationConverter()
                .AddFormSpecificationConverter()
                .AddValidatorConverter()
                .AddEventConverter();

        #endregion

        #region Commands

        private DelegateCommand _newCommand;

        public DelegateCommand NewCommand =>
            _newCommand = new DelegateCommand(_ => FormViewModel = DemoForm.CreateForm());

        private DelegateCommand _loadCommand;

        public DelegateCommand LoadCommand =>
            _loadCommand = new DelegateCommand(_ =>
            {
                var openFileDialog = new OpenFileDialog {Filter = "Json files (*.json)|*.json|All files (*.*)|*.*"};

                if (openFileDialog.ShowDialog() == true)
                {
                    var jsonString = File.ReadAllText(openFileDialog.FileName);
                    FormViewModel =
                        new FormViewModel(JsonConvert.DeserializeObject<Form>(jsonString, SerializerSettings));
                }
                else
                {
                    FormViewModel = null;
                }
            });

        public DelegateCommand SaveCommand =>
            new DelegateCommand(_ =>
            {
                var jsonString = JsonConvert.SerializeObject(FormViewModel.Model, SerializerSettings);
                File.WriteAllText($"{FormViewModel.Model.Name}.json", jsonString);
            });

        #endregion
    }
}