using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface ICheckElementViewModel : IFieldViewModel
    {
        bool IsChecked { get; set; }
        bool DefaultIsChecked { get; set; }
        string Content { get; set; }

        new CheckElement Model { get; }
    }
}