using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class TextElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public TextElementViewModel ViewModel { get; set; }

        #endregion
    }
}