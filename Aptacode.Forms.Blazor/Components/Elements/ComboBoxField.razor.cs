using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class ComboBoxFieldBase : ComponentBase
    {
        #region Properties

        [Parameter] public ComboBoxFieldViewModel ViewModel { get; set; }

        #endregion
    }
}