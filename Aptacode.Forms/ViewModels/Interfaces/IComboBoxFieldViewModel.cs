using System.Collections.Generic;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces
{
    public interface IComboBoxFieldViewModel : IFieldViewModel
    {
        List<string> Items { get; set; }
        string SelectedItem { get; set; }
    }
}