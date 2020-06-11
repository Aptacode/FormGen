using Aptacode.Forms.Shared.ViewModels.Layout;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Layout
{
    public class FormGroupBase : ComponentBase
    {
        #region Properties

        [Parameter] public FormGroupViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<FormGroupViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}