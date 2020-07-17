using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class HtmlElementViewModel : ControlElementViewModel
    {
        public HtmlElementViewModel(string name, ElementLabel label, string content) : this(
            new HtmlElement(name, label, content)) { }

        public HtmlElementViewModel(HtmlElement model) : base(model)
        {
            Model = model;
        }

        #region Properties

        private HtmlElement _model;

        public HtmlElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                if (Model == null)
                {
                    return;
                }

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
    }
}