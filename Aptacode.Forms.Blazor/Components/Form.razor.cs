using Aptacode.Forms.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components
{
    public class FormBase : ComponentBase
    {
        #region Properties

        [Parameter] public FormViewModel ViewModel { get; set; }

        [Parameter] public EventCallback<FormViewModel> ViewModelChanged { get; set; }

        #endregion
    }
}