using System;
using System.IO;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormDesignerViewModel : BindableBase
    {
        public FormDesignerViewModel()
        {
            FormGroupSelectorViewModel = new FormGroupSelectorViewModel();
            FormRowSelectorViewModel = new FormRowSelectorViewModel();
            FormElementSelectorViewModel = new FormElementSelectorViewModel();
            FormElementEditorViewModel = new FormElementEditorViewModel();

            FormGroupSelectorViewModel.OnGroupSelected += OnGroupSelected;
            FormRowSelectorViewModel.OnRowSelected += OnRowSelected;
            FormElementSelectorViewModel.OnElementSelected += OnElementSelected;
        }

        #region Events

        public EventHandler<FormViewModel> OnFormSelected { get; set; }

        #endregion

        #region Methods

        public void Load(Form form)
        {
            FormViewModel = new FormViewModel(form);
            FormGroupSelectorViewModel.FormViewModel = FormViewModel;
        }

        public void Clear()
        {
            FormViewModel = null;
            FormGroupSelectorViewModel.FormViewModel = FormViewModel;
        }

        #endregion

        #region Event Handlers

        private void OnGroupSelected(object sender, FormGroupViewModel e)
        {
            FormRowSelectorViewModel.FormGroup = e;
        }

        private void OnRowSelected(object sender, FormRowViewModel e)
        {
            FormElementSelectorViewModel.FormRow = e;
        }

        private void OnElementSelected(object sender, FormElementViewModel e)
        {
            FormElementEditorViewModel.FormElement = e;
        }

        #endregion


        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set
            {
                SetProperty(ref _formViewModel, value);
                OnFormSelected?.Invoke(this, FormViewModel);
            }
        }

        private FormGroupSelectorViewModel _formGroupSelectorViewModel;

        public FormGroupSelectorViewModel FormGroupSelectorViewModel
        {
            get => _formGroupSelectorViewModel;
            set => SetProperty(ref _formGroupSelectorViewModel, value);
        }

        private FormRowSelectorViewModel _formRowSelectorViewModel;

        public FormRowSelectorViewModel FormRowSelectorViewModel
        {
            get => _formRowSelectorViewModel;
            set => SetProperty(ref _formRowSelectorViewModel, value);
        }

        private FormElementSelectorViewModel _formElementSelectorViewModel;

        public FormElementSelectorViewModel FormElementSelectorViewModel
        {
            get => _formElementSelectorViewModel;
            set => SetProperty(ref _formElementSelectorViewModel, value);
        }

        private FormElementEditorViewModel _formElementEditorViewModel;

        public FormElementEditorViewModel FormElementEditorViewModel
        {
            get => _formElementEditorViewModel;
            set => SetProperty(ref _formElementEditorViewModel, value);
        }

        #endregion

        #region Commands

        private DelegateCommand _newFormCommand;

        public DelegateCommand NewFormCommand =>
            _newFormCommand ?? (_newFormCommand = new DelegateCommand(() =>
            {
                Load(new Form("New Form", "Form Title", new FormGroup[0]));
            }));

        private DelegateCommand _openFormCommand;

        public DelegateCommand OpenFormCommand =>
            _openFormCommand ?? (_openFormCommand = new DelegateCommand(() =>
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    var jsonString = File.ReadAllText(openFileDialog.FileName);
                    Load(Form.FromJson(jsonString));
                }
                else
                {
                    Clear();
                }
            }));

        private DelegateCommand _saveFormCommand;

        public DelegateCommand SaveFormCommand =>
            _saveFormCommand ?? (_saveFormCommand = new DelegateCommand(() =>
            {
                File.WriteAllText($"{FormViewModel.Form.Name}.json", FormViewModel.Form.ToJson());
            }));

        #endregion
    }
}