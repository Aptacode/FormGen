using System;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormRowSelectorViewModel : BindableBase
    {
        #region Methods

        public void Load(FormGroupViewModel formGroup)
        {
            FormGroup = formGroup;
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
            set => SetProperty(ref _formGroup, value);
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

        private DelegateCommand _removeCommand;

        public DelegateCommand RemoveCommand =>
            _removeCommand ?? (_removeCommand = new DelegateCommand(async () =>
            {
                if (SelectedRow == null)
                {
                }

                //FormGroup...RemoveGroup(SelectedRow);
                //Load();
            }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() =>
            {
                //if (SelectedRow != null && !SelectedRow.Row.Equals(FormRow.EmptyRow))
                //{
                //    FormViewModel.Add(SelectedGroup.Group);
                //}

                //Load();
            }));

        #endregion
    }
}