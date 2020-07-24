using System.Collections.ObjectModel;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts
{
    public interface ICompositeElementViewModel : IFormElementViewModel
    {
        ObservableCollection<IFormElementViewModel> Children { get; }
        new CompositeElement Model { get; }
    }
}