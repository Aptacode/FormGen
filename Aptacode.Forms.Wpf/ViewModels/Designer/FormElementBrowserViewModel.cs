using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementBrowserViewModel : BindableBase
    {
        #region Events

        public EventHandler<IFormElementViewModel> OnElementSelected { get; set; }

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

        private DelegateCommand<IFormElementViewModel> _elementClickedCommand;

        public DelegateCommand<IFormElementViewModel> ElementClickedCommand =>
            _elementClickedCommand ??= new DelegateCommand<IFormElementViewModel>(selectedElement =>
            {
                OnElementSelected?.Invoke(this, selectedElement);
            });

        #endregion
    }
}