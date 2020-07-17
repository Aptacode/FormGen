using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormDesignerViewModel : BindableBase
    {
        public FormDesignerViewModel()
        {
            ElementBrowserViewModel = new ElementBrowserViewModel();
            FormElementEditorViewModel = new FormElementEditorViewModel();
            ElementBrowserViewModel.OnEditElement += OnEditElement;
        }

        private void OnEditElement(object sender, FormElementViewModel e)
        {
            FormElementEditorViewModel.FormElement = e as ControlElementViewModel;
        }

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set
            {
                SetProperty(ref _formViewModel, value);

                ElementBrowserViewModel.FormViewModel = FormViewModel;
                FormElementEditorViewModel.FormViewModel = FormViewModel;
            }
        }

        private ElementBrowserViewModel _elementBrowserViewModel;

        public ElementBrowserViewModel ElementBrowserViewModel
        {
            get => _elementBrowserViewModel;
            set => SetProperty(ref _elementBrowserViewModel, value);
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