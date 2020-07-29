using System.Collections.ObjectModel;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Interfaces.Composite
{
    public interface ICompositeElementViewModel : IFormElementViewModel
    {
        ObservableCollection<IFormElementViewModel> Children { get; }

        LayoutMode LayoutMode { get; set; }
        LayoutOrientation LayoutOrientation { get; set; }
        new CompositeElement Model { get; }
    }
}