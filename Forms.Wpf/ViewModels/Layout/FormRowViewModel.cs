using System.Collections.ObjectModel;
using Aptacode.Forms.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Layout
{
    public class FormRowViewModel : BindableBase
    {
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

        #region Properties

        private ObservableCollection<FormColumnViewModel> _columns;

        public ObservableCollection<FormColumnViewModel> Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }

        #endregion
    }
}