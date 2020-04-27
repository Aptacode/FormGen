using System.Collections.ObjectModel;
using Prism.Mvvm;
using FormRow = Aptacode.Forms.Layout.FormRow;

namespace Aptacode.Forms.Wpf.ViewModels
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