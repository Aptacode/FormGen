using Aptacode.Forms.Shared.Interfaces.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class TextElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ITextElementViewModel ViewModel { get; set; }

        #endregion
    }
}