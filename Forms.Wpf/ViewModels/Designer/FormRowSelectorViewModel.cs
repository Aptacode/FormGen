using System;
using System.Linq;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormRowSelectorViewModel : BindableBase
    {
        #region Methods

        public void Load()
        {
            SelectedRow = null;
        }

        #endregion

        #region Events

        public EventHandler<FormRowViewModel> OnRowSelected { get; set; }
        public EventHandler<FormRowViewModel> OnRemoved { get; set; }
        public EventHandler<FormRowViewModel> OnCreated { get; set; }

        #endregion

        #region Properties

        private FormGroupViewModel _formGroup;

        public FormGroupViewModel FormGroup
        {
            get => _formGroup;
            set
            {
                SetProperty(ref _formGroup, value);
                Load();
            }
        }

        private FormRowViewModel _selectedRow;

        public FormRowViewModel SelectedRow
        {
            get => _selectedRow;
            set
            {
                SetProperty(ref _selectedRow, value);
                OnRowSelected?.Invoke(this, _selectedRow);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(async () =>
            {
                if (SelectedRow == null)
                {
                    return;
                }

                FormGroup.Remove(SelectedRow.Row);
                SelectedRow = null;
                Load();
            }));

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ?? (_createCommand = new DelegateCommand(async () =>
            {
                if (FormGroup == null)
                {
                    return;
                }

                var rowPosition = FormGroup.Rows.Count + 1;

                var newRow = FormRow.EmptyRow;
                newRow.Name = $"{FormRow.DefaultName} {rowPosition.ToString()}";
                FormGroup.Add(newRow);
                Load();
                SelectedRow = new FormRowViewModel(newRow);
            }));

        #endregion
    }
}