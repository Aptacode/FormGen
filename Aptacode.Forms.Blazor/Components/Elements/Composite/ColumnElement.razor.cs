using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Composite
{
    public class ColumnElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ColumnElementViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<ColumnElementViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}