using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    /// <summary>
    ///     Button Element View Model
    /// </summary>
    public class ButtonElementViewModel : ControlElementViewModel<ButtonElement>, IButtonElementViewModel
    {
        public ButtonElementViewModel(ButtonElement model) : base(model)
        {
            Content = Model.Content;
        }

        #region Properties

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                Model.Content = _content;
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _buttonClickedCommand;

        public DelegateCommand ButtonClickedCommand => _buttonClickedCommand ??=
            new DelegateCommand(_ => TriggerEvent(new ButtonElementClickedEvent(DateTime.Now, Name)));

        #endregion
    }
}