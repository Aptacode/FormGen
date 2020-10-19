using Aptacode.Forms.Shared.ViewModels.Elements.Composite;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Composite
{
    public class LinearLayoutElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public LinearLayoutElementViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<LinearLayoutElementViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}