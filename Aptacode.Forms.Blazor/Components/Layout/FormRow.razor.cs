using Aptacode.Forms.Shared.ViewModels.Layout;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Layout
{
    public class FormRowBase : ComponentBase
    {
        #region Properties

        [Parameter] public FormRowViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<FormRowViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}