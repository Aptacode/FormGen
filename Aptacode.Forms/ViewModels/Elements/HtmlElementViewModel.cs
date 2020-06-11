using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Enums;

namespace Aptacode.Forms.Shared.ViewModels.Elements
{
    public class HtmlElementViewModel : FormElementViewModel
    {
        public HtmlElementViewModel(string name, string content, LabelPosition labelPosition, string label) : this(
            new HtmlElementModel(name, content, labelPosition, label)) { }

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
                Model.Content = _content;
            }
        }

        #endregion
    }
}