using System.Collections.ObjectModel;
using Aptacode.Forms.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Layout
{
    public class FormGroupViewModel : BindableBase
    {
        public FormGroupViewModel(FormGroup group)
        {
            Rows = new ObservableCollection<FormRowViewModel>();
            Group = group;
            LoadRows();
            Label = group.Label;
        }


        public FormGroup Group { get; }

        private void LoadRows()
        {
            Rows.Clear();
            foreach (var row in Group.Rows)
            {
                Rows.Add(new FormRowViewModel(row));
            }
        }

        #region Methods

        public void Add(FormRow row)
        {
            if (row == null || Group.Rows.Contains(row))
            {
                return;
            }

            Group.Rows.Add(row);
            LoadRows();
        }

        public void Remove(FormRow row)
        {
            Group.Rows.Remove(row);
            LoadRows();
        }

        #endregion

        #region Properties

        private string _label;

        public string Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);
                Group.Label = _label;
            }
        }

        private ObservableCollection<FormRowViewModel> _rows;

        public ObservableCollection<FormRowViewModel> Rows
        {
            get => _rows;
            set => SetProperty(ref _rows, value);
        }

        #endregion
    }
}