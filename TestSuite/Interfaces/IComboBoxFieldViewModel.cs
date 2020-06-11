using System.Collections.Generic;

namespace TestSuite.Interfaces
{
    public interface IComboBoxFieldViewModel : IFieldViewModel
    {
        IEnumerable<string> Items { get; set; }
        string SelectedItem { get; set; }
    }
}