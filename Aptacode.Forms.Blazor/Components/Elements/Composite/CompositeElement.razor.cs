using Aptacode.Forms.Shared.Interfaces.Composite;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Composite
{
    public class CompositeElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ICompositeElementViewModel ViewModel { get; set; }

        #endregion
    }
}