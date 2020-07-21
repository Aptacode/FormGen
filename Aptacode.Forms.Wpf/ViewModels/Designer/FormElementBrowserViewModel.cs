using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementBrowserViewModel : BindableBase
    {
        #region Events

        public EventHandler<FormElementViewModel> OnElementSelected { get; set; }

        #endregion

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        #endregion

        #region Commands

        private DelegateCommand<FormElementViewModel> _elementClickedCommand;

        public DelegateCommand<FormElementViewModel> ElementClickedCommand =>
            _elementClickedCommand ??= new DelegateCommand<FormElementViewModel>(selectedElement =>
            {
                OnElementSelected?.Invoke(this, selectedElement);
            });

        #endregion
    }
}