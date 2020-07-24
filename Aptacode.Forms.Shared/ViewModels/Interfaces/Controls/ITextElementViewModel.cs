using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface ITextElementViewModel : IFieldViewModel
    {
        string Content { get; set; }

        new TextElement Model { get; }
    }
}