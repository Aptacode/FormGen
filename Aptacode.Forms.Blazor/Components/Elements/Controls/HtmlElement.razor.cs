using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class HtmlElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public HtmlElementViewModel ViewModel { get; set; }

        #endregion
    }
}