using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    public abstract class FormElementViewModel : BindableBase
    {
        protected FormElementViewModel(FormElement elementModel)
        {
            ElementModel = elementModel;
        }

        #region Properties

        private FormElement _elementModel;

        public FormElement ElementModel
        {
            get => _elementModel;
            set
            {
                SetProperty(ref _elementModel, value);

                Name = _elementModel.Name;
                HorizontalAlignment = _elementModel.HorizontalAlignment;
                VerticalAlignment = _elementModel.VerticalAlignment;
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                if (ElementModel != null)
                {
                    ElementModel.Name = _name;
                }
            }
        }

        private VerticalAlignment _verticalAlignment;

        public VerticalAlignment VerticalAlignment
        {
            get => _verticalAlignment;
            set
            {
                SetProperty(ref _verticalAlignment, value);
                if (ElementModel != null)
                {
                    ElementModel.VerticalAlignment = _verticalAlignment;
                }
            }
        }

        private HorizontalAlignment _horizontalAlignment;

        public HorizontalAlignment HorizontalAlignment
        {
            get => _horizontalAlignment;
            set
            {
                SetProperty(ref _horizontalAlignment, value);
                if (ElementModel != null)
                {
                    ElementModel.HorizontalAlignment = _horizontalAlignment;
                }
            }
        }

        #endregion

        #region Events

        public event EventHandler<FormElementEvent> OnFormEvent;
        protected void TriggerEvent(FormElementEvent @event) => OnFormEvent?.Invoke(this, @event);

        #endregion
    }
}