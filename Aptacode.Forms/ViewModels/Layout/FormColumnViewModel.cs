using System;
using Aptacode.Forms.Shared.Models.Layout;
using Aptacode.Forms.Shared.Mvvm;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Factories;

namespace Aptacode.Forms.Shared.ViewModels.Layout
{
    public class FormColumnViewModel : BindableBase
    {
        public FormColumnViewModel(int span) : this(new FormColumnModel(span, null)) { }

        public FormColumnViewModel(int span, FormElementViewModel viewModel)
        {
            _model = new FormColumnModel(span, viewModel.ElementModel);
            FormElementViewModel = viewModel ?? throw new ArgumentNullException(nameof(FormElementViewModel));
        }

        public FormColumnViewModel(FormColumnModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(FormColumnModel));
        }

        #region Properties

        private FormColumnModel _model;

        public FormColumnModel Model
        {
            get => _model;
            set
            {
                _model = value;
                FormElementViewModel = Model != null ? FormElementViewModelFactory.Create(_model.Element) : null;
            }
        }

        private FormElementViewModel _formElementViewModel;

        public FormElementViewModel FormElementViewModel
        {
            get => _formElementViewModel;
            set
            {
                SetProperty(ref _formElementViewModel, value);
                if (Model != null)
                {
                    Model.Element = _formElementViewModel?.ElementModel;
                }
            }
        }

        #endregion
    }
}