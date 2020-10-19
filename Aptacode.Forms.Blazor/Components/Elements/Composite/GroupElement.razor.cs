using Aptacode.Forms.Shared.ViewModels.Elements.Composite;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Composite
{
    public class GroupElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public GroupElementViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<GroupElementViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}