using Aptacode.Forms.Shared.ViewModels.Elements;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class FormElementBase : ComponentBase
    {
        #region Properties

        [Parameter] 
        public FormElementViewModel ViewModel { get; set; }

        public bool IsFormHorizontal => ViewModel.Label.Position == Shared.Models.Elements.ElementLabel.LabelPosition.Left;

        #endregion
    }
}