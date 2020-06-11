using Aptacode.Forms.Shared.ViewModels.Layout;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Layout
{
    public class FormColumnBase : ComponentBase
    {
        #region Properties

        [Parameter] public FormColumnViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<FormColumnViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}