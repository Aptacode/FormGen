using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class TextFieldBase : ComponentBase
    {
        #region Properties

        [Parameter] public TextFieldViewModel ViewModel { get; set; }

        #endregion
    }
}