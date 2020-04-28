using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormDesignerViewModel : BindableBase
    {
        public void Load(FormViewModel formViewModel)
        {
            FormGroupSelectorViewModel = new FormGroupSelectorViewModel(formViewModel);
            FormRowSelectorViewModel = new FormRowSelectorViewModel();
            FormElementSelectorViewModel = new FormElementSelectorViewModel();
            FormElementEditorViewModel = new FormElementEditorViewModel();

            FormGroupSelectorViewModel.Load();
            FormGroupSelectorViewModel.OnGroupSelected += OnGroupSelected;
            FormRowSelectorViewModel.OnRowSelected += OnRowSelected;
            FormElementSelectorViewModel.OnElementSelected += OnElementSelected;
        }

        #region Event Handlers

        private void OnGroupSelected(object sender, FormGroupViewModel e)
        {
            FormRowSelectorViewModel.Load(e);
        }

        private void OnRowSelected(object sender, FormRowViewModel e)
        {
            FormElementSelectorViewModel.Load(e);
        }

        private void OnElementSelected(object sender, FormElementViewModel e)
        {
            FormElementEditorViewModel.Load(e);
        }

        #endregion


        #region Properties

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
    }
}