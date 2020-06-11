using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.ViewModels.Events;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    /// <summary>
    ///     Button Element View Model
    /// </summary>
    public class ButtonElementViewModel : FormElementViewModel
    {
        public ButtonElementViewModel(string name, ElementLabel label, string content) : this(
            new ButtonElementModel(name, label, content)) { }

        public ButtonElementViewModel(ButtonElementModel model) : base(model)
        {
            Model = model;
        }

        #region Properties

        private ButtonElementModel _model;

        public ButtonElementModel Model
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
            new DelegateCommand(_ => TriggerEvent(new ButtonClickedEventArgs(DateTime.Now)));

        #endregion
    }
}