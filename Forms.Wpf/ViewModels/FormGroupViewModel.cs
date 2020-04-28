using System.Collections.ObjectModel;
using Aptacode.Forms.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormGroupViewModel : BindableBase
    {
        private string _label;
        private ObservableCollection<FormRowViewModel> _rows;

        public FormGroupViewModel(FormGroup group)
        {
            Group = group;
            Rows = new ObservableCollection<FormRowViewModel>();
            foreach (var row in group.Rows)
            {
                Rows.Add(new FormRowViewModel(row));
            }

            Label = group.Label;
        }

        public FormGroup Group { get; }

        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public ObservableCollection<FormRowViewModel> Rows
        {
            get => _rows;
            set => SetProperty(ref _rows, value);
        }
    }
}