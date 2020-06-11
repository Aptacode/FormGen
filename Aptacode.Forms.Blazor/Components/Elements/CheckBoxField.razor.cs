using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class CheckBoxFieldBase : ComponentBase
    {
        #region Properties

        [Parameter] public CheckBoxFieldViewModel ViewModel { get; set; }

        #endregion
    }
}