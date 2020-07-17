using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class SelectElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public SelectElementViewModel ViewModel { get; set; }

        #endregion
    }
}