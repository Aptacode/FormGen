using System.Collections.ObjectModel;
using System.Linq;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Layout
{
    public class FormRowViewModel : BindableBase
    {
        public FormRowViewModel() : this(null)
        {
        }

        public FormRowViewModel(FormRow row)
        {
            Columns = new ObservableCollection<FormColumnViewModel>();
            Row = row;
        }

        #region Methods

        public void Load()
        {
            Columns.Clear();
            if (Row == null)
            {
                return;
            }

            foreach (var column in Row.Columns)
            {
                Columns.Add(new FormColumnViewModel(column));
            }
        }

        public void Add(FormElement element)
        {
            if (Row == null)
            {
                return;
            }

            Row.Columns.Add(new FormColumn(1, element));
            Load();
        }

        public void Remove(FormElement element)
        {
            var column = Row?.Columns.FirstOrDefault(c => c.Element.Equals(element));
            if (column == null)
            {
                return;
            }

            Row.Columns.Remove(column);
        }

        #endregion


        #region Properties

        private FormRow _row;

        public FormRow Row
        {
            get => _row;
            set
            {
                SetProperty(ref _row, value);
                Load();
            }
        }

        private ObservableCollection<FormColumnViewModel> _columns;

        public ObservableCollection<FormColumnViewModel> Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }

        #endregion
    }
}