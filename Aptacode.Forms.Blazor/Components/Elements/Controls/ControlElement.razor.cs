using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class ControlElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ControlElementViewModel ViewModel { get; set; }
        public bool IsFormHorizontal => ViewModel.Label.Position == ElementLabel.LabelPosition.Left;

        #endregion
    }
}