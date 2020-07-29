using System;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.Interfaces
{
    public interface IFormElementViewModel
    {
        #region Properties

        string Name { get; set; }

        VerticalAlignment VerticalAlignment { get; set; }

        HorizontalAlignment HorizontalAlignment { get; set; }
        FormElement Model { get; }

        #endregion

        #region Events

        event EventHandler<FormElementEvent> OnFormEvent;
        void TriggerEvent(FormElementEvent @event);

        #endregion
    }
}