using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;

namespace Aptacode.Forms.Shared.Interfaces.Controls
{
    public interface ITextElementViewModel : IFieldViewModel
    {
        string Content { get; set; }
        string DefaultContent { get; set; }

        new TextElement Model { get; }
    }
}