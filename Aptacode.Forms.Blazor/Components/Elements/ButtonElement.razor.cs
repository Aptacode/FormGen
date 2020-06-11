using Aptacode.Forms.Shared.ViewModels.Elements;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class ButtonElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ButtonElementViewModel ViewModel { get; set; }

        #endregion
    }
}