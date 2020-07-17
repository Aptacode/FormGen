using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Composite
{
    public class CompositeElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public CompositeElementViewModel ViewModel { get; set; }

        #endregion
    }
}