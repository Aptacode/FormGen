using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface IButtonElementViewModel : IFormElementViewModel
    {
        string Content { get; set; }
        DelegateCommand ButtonClickedCommand { get; }

        new ButtonElement Model { get; }
    }
}