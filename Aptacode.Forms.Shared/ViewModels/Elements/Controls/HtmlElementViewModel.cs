using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class HtmlElementViewModel : ControlElementViewModel<HtmlElement>, IHtmlElementViewModel
    {
        public HtmlElementViewModel(HtmlElement model) : base(model)
        {
            Content = model.Content;
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
    }
}