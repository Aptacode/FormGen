using System.Collections.Generic;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Interfaces
{
    public interface ISelectElementViewModel : IFieldViewModel
    {
        List<string> Items { get; set; }
        string SelectedItem { get; set; }
    }
}