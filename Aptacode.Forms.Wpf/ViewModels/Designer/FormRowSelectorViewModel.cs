using System;
using Aptacode.Forms.Shared.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormRowSelectorViewModel : BindableBase
    {
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
                SelectedRow = null;
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
            _deleteCommand ??= new DelegateCommand(() =>
            {
                if (SelectedRow == null)
                {
                    return;
                }

                FormGroup.Rows.Remove(SelectedRow);
                SelectedRow = null;
            });

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(() =>
            {
                if (FormGroup == null)
                {
                    return;
                }

                var rowPosition = FormGroup.Rows.Count + 1;

                var newRow = new FormRowViewModel($"Default {rowPosition}", 1);
                FormGroup.Rows.Add(newRow);
                SelectedRow = newRow;
            });

        #endregion
    }
}