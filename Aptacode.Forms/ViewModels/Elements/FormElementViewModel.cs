using System;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Mvvm;
using Aptacode.Forms.Shared.ViewModels.Events;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    public abstract class FormElementViewModel : BindableBase
    {
        private LabelPosition _labelPosition;

        protected FormElementViewModel(FormElementModel elementModel)
        {
            ElementModel = elementModel;
        }

        #region Properties

        private FormElementModel _elementModel;

        public FormElementModel ElementModel
        {
            get => _elementModel;
            set
            {
                SetProperty(ref _elementModel, value);

                Name = _elementModel?.Name;
                Label = _elementModel?.Label;
                LabelPosition = _elementModel?.LabelPosition ?? LabelPosition.AboveElement;
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

        private string _label;

        public string Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);
                if (ElementModel != null)
                {
                    ElementModel.Label = _label;
                }
            }
        }

        public LabelPosition LabelPosition
        {
            get => _labelPosition;
            set
            {
                SetProperty(ref _labelPosition, value);
                if (ElementModel != null)
                {
                    ElementModel.LabelPosition = _labelPosition;
                }
            }
        }

        #endregion

        #region Events

        public event EventHandler<FormElementEvent> OnFormEvent;

        protected void TriggerEvent(FormElementEvent eventArgs) => OnFormEvent?.Invoke(this, eventArgs);

        #endregion
    }
}