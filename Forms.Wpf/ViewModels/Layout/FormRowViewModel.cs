using System.Collections.ObjectModel;
using Aptacode.Forms.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Layout
{
    public class FormRowViewModel : BindableBase
    {
        private ObservableCollection<FormColumnViewModel> _columns;

        public FormRowViewModel(FormRow row)
        {
            Row = row;
            Columns = new ObservableCollection<FormColumnViewModel>();
            foreach (var column in row.Columns)
            {
                Columns.Add(new FormColumnViewModel(column));
            }
        }

        public FormRow Row { get; }

        public ObservableCollection<FormColumnViewModel> Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }
    }
}