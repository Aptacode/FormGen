using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Mvvm;
using Aptacode.Forms.Shared.ViewModels.Events;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    public class ButtonElementViewModel : FormElementViewModel
    {
        private string _content;

        private ButtonElementModel _model;

        public ButtonElementViewModel(string name, string content, LabelPosition labelPosition, string label) : this(
            new ButtonElementModel(name, content, labelPosition, label)) { }

        public ButtonElementViewModel(ButtonElementModel model) : base(model)
        {
            Model = _model;
        }

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

        #region Commands

        private DelegateCommand _buttonClickedCommand;

        public DelegateCommand ButtonClickedCommand => _buttonClickedCommand ??=
            new DelegateCommand(() => TriggerEvent(new ButtonClickedEventArgs(Model)));

        #endregion
    }
}