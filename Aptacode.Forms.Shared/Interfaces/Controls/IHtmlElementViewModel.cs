using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.Interfaces.Controls
{
    public interface IHtmlElementViewModel : IFormElementViewModel
    {
        string Content { get; set; }
        new HtmlElement Model { get; }
    }
}