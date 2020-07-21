using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormDesignerViewModel : BindableBase
    {
        public FormDesignerViewModel()
        {
            ElementBrowserViewModel = new FormElementBrowserViewModel();
            FormElementEditorViewModel = new FormElementEditorViewModel();
            CompositeElementEditorViewModel = new CompositeElementEditorViewModel();

            ElementBrowserViewModel.OnElementSelected += OnEditElement;
        }

        private void OnEditElement(object sender, FormElementViewModel e)
        {

            if(e is ControlElementViewModel controlElementViewModel)
            {
                FormElementEditorViewModel.FormElement = controlElementViewModel;
                ElementEditorViewModel = FormElementEditorViewModel;
            }else if (e is CompositeElementViewModel compositeElementViewModel)
            {
                CompositeElementEditorViewModel.SelectedElement = compositeElementViewModel;
                ElementEditorViewModel = CompositeElementEditorViewModel;
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

                ElementBrowserViewModel.FormViewModel = FormViewModel;
                FormElementEditorViewModel.FormViewModel = FormViewModel;
                CompositeElementEditorViewModel.FormViewModel = FormViewModel;
            }
        }

        private FormElementBrowserViewModel _elementBrowserViewModel;

        public FormElementBrowserViewModel ElementBrowserViewModel
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

        private CompositeElementEditorViewModel _compositeElementEditorViewModel;

        public CompositeElementEditorViewModel CompositeElementEditorViewModel
        {
            get => _compositeElementEditorViewModel;
            set => SetProperty(ref _compositeElementEditorViewModel, value);
        }


        private BindableBase _elementEditorViewModel;

        public BindableBase ElementEditorViewModel
        {
            get => _elementEditorViewModel;
            set => SetProperty(ref _elementEditorViewModel, value);
        }

        

        #endregion
    }
}