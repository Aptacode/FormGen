using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface IControlElementViewModel : IFormElementViewModel
    {
        ElementLabelViewModel Label { get; set; }

        new ControlElement Model { get; }
    }
}