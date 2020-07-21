using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class ButtonElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ButtonElementViewModel ViewModel { get; set; }

        #endregion
    }
}