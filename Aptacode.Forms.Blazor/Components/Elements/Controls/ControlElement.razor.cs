using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class ControlElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public IControlElementViewModel ViewModel { get; set; }
        public bool IsFormHorizontal => ViewModel.Label.Position == LabelPosition.Left;

        #endregion
    }
}