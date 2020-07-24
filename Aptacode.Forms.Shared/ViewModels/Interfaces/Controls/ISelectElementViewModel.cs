using System.Collections.ObjectModel;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface ISelectElementViewModel : IFieldViewModel
    {
        ObservableCollection<string> Items { get; }
        string SelectedItem { get; set; }
        string DefaultSelectedItem { get; set; }


        new SelectElement Model { get; }
    }
}