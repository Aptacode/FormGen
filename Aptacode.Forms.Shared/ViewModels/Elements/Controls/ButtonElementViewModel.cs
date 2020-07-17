using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    /// <summary>
    ///     Button Element View Model
    /// </summary>
    public class ButtonElementViewModel : ControlElementViewModel
    {
        public ButtonElementViewModel(string name, ElementLabel label, string content) : this(
            new ButtonElement(name, label, content)) { }

        public ButtonElementViewModel(ButtonElement model) : base(model)
        {
            Model = model;
        }

        #region Properties

        private ButtonElement _model;

        public ButtonElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                Content = _model?.Content;
                ElementModel = _model;
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                if (Model != null)
                {
                    Model.Content = _content;
                }
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