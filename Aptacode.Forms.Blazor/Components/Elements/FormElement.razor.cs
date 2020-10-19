using Aptacode.Forms.Shared.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements
{
    public class FormElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public IFormElementViewModel ViewModel { get; set; }


        #endregion
    }
}