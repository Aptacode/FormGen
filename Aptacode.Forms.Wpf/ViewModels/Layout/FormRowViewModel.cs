using System.Collections.ObjectModel;
using Aptacode.Forms.Shared.Elements;
using Aptacode.Forms.Shared.Layout;
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
            Clear();

            if (Row == null)
            {
                return;
            }

            Name = Row.Name;
            foreach (var column in Row.Columns)
            {
                Columns.Add(new FormColumnViewModel(column));
            }
        }

        public void Clear()
        {
            Columns.Clear();
            Name = string.Empty;
        }

        public void Add(FormElement element)
        {
            if (Row == null)
            {
                return;
            }

            Add(new FormColumn(1, element));
        }

        public void Add(FormColumn column)
        {
            if (column == null)
            {
                return;
            }

            Row.Columns.Add(column);
            Load();
        }

        public void Remove(FormElement element)
        {
            var column = Row?.Columns.Find(c => c.Element.Equals(element));
            Remove(column);
        }

        public void Remove(FormColumn column)
        {
            if (!Row.Columns.Contains(column))
            {
                return;
            }

            Row.Columns.Remove(column);
            Load();
        }

        #endregion


        #region Properties

        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

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