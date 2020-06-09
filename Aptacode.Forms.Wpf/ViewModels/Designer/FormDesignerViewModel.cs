using System;
using Aptacode.Forms.Shared;
using Aptacode.Forms.Wpf.ViewModels.Layout;
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
            FormElementSelectorViewModel.OnColumnSelected += OnColumnSelected;
        }

        #region Events

        public EventHandler<FormViewModel> OnFormSelected { get; set; }
        public EventHandler<FormViewModel> OnNewForm { get; set; }
        public EventHandler<FormViewModel> OnOpenForm { get; set; }
        public EventHandler<FormViewModel> OnSaveForm { get; set; }

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

        private void OnColumnSelected(object sender, FormColumnViewModel e)
        {
            FormElementEditorViewModel.FormColumn = e;
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
            _newFormCommand ??
            (_newFormCommand = new DelegateCommand(() => { OnNewForm?.Invoke(this, FormViewModel); }));

        private DelegateCommand _openFormCommand;

        public DelegateCommand OpenFormCommand =>
            _openFormCommand ?? (_openFormCommand = new DelegateCommand(() =>
            {
                OnOpenForm?.Invoke(this, FormViewModel);
            }));

        private DelegateCommand _saveFormCommand;

        public DelegateCommand SaveFormCommand =>
            _saveFormCommand ?? (_saveFormCommand = new DelegateCommand(() =>
            {
                OnSaveForm?.Invoke(this, FormViewModel);
            }));

        #endregion
    }
}