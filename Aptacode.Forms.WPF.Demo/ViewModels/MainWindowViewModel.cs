using System.IO;
using System.Windows;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.Conditions;
using Aptacode.Forms.Shared.EventListeners.Specifications.Event;
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
            FormViewModel = FormIO.CreateForm();

            FormViewModel.EventListeners.Add(new EventListener("CorrectSelection", 
                new EventElementNameSpecification("submit")
                    .And(
                        new EventTypeSpecification(nameof(ButtonElementClickedEvent))),
                new SelectElementSelectionCondition("experienceSelection", "0-1")));


            FormViewModel.OnTriggered += FormViewModelOnOnTriggered;
        }

        private void FormViewModelOnOnTriggered(object sender, (EventListener, FormElementEvent) e)
        {



        }

        private void Submit()
        {
            if (_formViewModel.IsValid)
            {
                var formResults = _formViewModel.GetResult();
                File.WriteAllText("./results.json", JsonConvert.SerializeObject(formResults, Formatting.Indented));
            }
            else
            {
                MessageBox.Show(_formViewModel.GetValidationMessage());
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
            }
        }

        public FormDesignerViewModel FormDesignerViewModel { get; set; }

        #endregion

        #region Commands

        private DelegateCommand _newCommand;
        public DelegateCommand NewCommand =>
            _newCommand = new DelegateCommand((_) =>
            {
                FormViewModel = FormIO.CreateForm();
            });

        private DelegateCommand _loadCommand;
        public DelegateCommand LoadCommand =>
            _loadCommand = new DelegateCommand((_) =>
            {
                var openFileDialog = new OpenFileDialog { Filter = "Json files (*.json)|*.json|All files (*.*)|*.*" };

                if (openFileDialog.ShowDialog() == true)
                {
                    var jsonString = File.ReadAllText(openFileDialog.FileName);
                    FormViewModel = new FormViewModel(JsonConvert.DeserializeObject<Form>(jsonString));
                }
                else
                {
                    FormViewModel = null;
                }
            });

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand = new DelegateCommand((_) =>
            {
                var json = JsonConvert.SerializeObject(FormViewModel.Model);
                File.WriteAllText($"{FormViewModel.Model.Name}.json", json);
            });



        #endregion
    }
}