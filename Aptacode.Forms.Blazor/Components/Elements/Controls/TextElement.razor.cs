using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
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