using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class CheckElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public CheckElementViewModel ViewModel { get; set; }

        #endregion
    }
}