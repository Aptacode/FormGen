using Aptacode.Forms.Shared.ViewModels.Elements;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class HtmlElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public HtmlElementViewModel ViewModel { get; set; }

        #endregion
    }
}