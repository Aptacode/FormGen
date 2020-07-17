using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
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

                Name = _elementModel?.Name;
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

        #endregion

        #region Events

        public event EventHandler<FormElementEvent> OnFormEvent;
        protected void TriggerEvent(FormElementEvent @event) => OnFormEvent?.Invoke(this, @event);

        #endregion
    }
}