using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Composite
{
    public class RowElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public RowElementViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<RowElementViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}