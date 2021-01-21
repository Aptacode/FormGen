using System.Collections.ObjectModel;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;

namespace Aptacode.Forms.Shared.Interfaces.Controls
{
    public interface IListEditElementViewModel : IFieldViewModel
    {
        ObservableCollection<IFormElementViewModel> Items { get; }

        new ListEditElement Model { get; }

        public void Add();

        public void Remove(IFormElementViewModel item);
    }
}