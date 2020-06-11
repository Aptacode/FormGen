using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    public class HtmlElementViewModel : FormElementViewModel
    {
        public HtmlElementViewModel(string name, ElementLabel label, string content) : this(
            new HtmlElementModel(name, label, content)) { }

        public HtmlElementViewModel(HtmlElementModel model) : base(model)
        {
            Model = model;
        }

        #region Properties

        private HtmlElementModel _model;

        public HtmlElementModel Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                if(Model != null)
                {
                    Content = _model?.Content;
                    ElementModel = _model;
                }
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                if(Model != null)
                {
                    Model.Content = _content;
                }
            }
        }

        #endregion
    }
}