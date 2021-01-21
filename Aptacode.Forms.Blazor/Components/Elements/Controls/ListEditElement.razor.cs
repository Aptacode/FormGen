using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Interfaces;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Components.Elements.Controls
{
    public class ListEditElementBase : ComponentBase
    {
        #region Properties

        [Parameter] public ListEditElementViewModel ViewModel { get; set; }

        #endregion

        public void OnAddClicked()
        {
            ViewModel.Add();
            StateHasChanged();
        }
    
        private DelegateCommand<IFormElementViewModel> _removeCommand;

        public DelegateCommand<IFormElementViewModel> RemoveCommand => _removeCommand ??= new DelegateCommand<IFormElementViewModel>(
            (IFormElementViewModel e) =>
        {
            ViewModel.Remove(e);
            StateHasChanged();
        }
        );

    }
}