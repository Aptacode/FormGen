using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    public abstract class FormElementViewModel<TElement> : BindableBase, IFormElementViewModel
        where TElement : FormElement, new()
    {
        protected FormElementViewModel(TElement model)
        {
            Model = model;
            Name = Model.Name;
            HorizontalAlignment = Model.HorizontalAlignment;
            VerticalAlignment = Model.VerticalAlignment;
        }

        #region Properties

        FormElement IFormElementViewModel.Model => Model;
        public TElement Model { get; }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                Model.Name = _name;
            }
        }

        private VerticalAlignment _verticalAlignment;

        public VerticalAlignment VerticalAlignment
        {
            get => _verticalAlignment;
            set
            {
                SetProperty(ref _verticalAlignment, value);
                Model.VerticalAlignment = _verticalAlignment;
            }
        }

        private HorizontalAlignment _horizontalAlignment;

        public HorizontalAlignment HorizontalAlignment
        {
            get => _horizontalAlignment;
            set
            {
                SetProperty(ref _horizontalAlignment, value);
                Model.HorizontalAlignment = _horizontalAlignment;
            }
        }

        #endregion

        #region Events

        public event EventHandler<FormElementEvent> OnFormEvent;
        public void TriggerEvent(FormElementEvent @event) => OnFormEvent?.Invoke(this, @event);

        #endregion
    }
}