using System;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementSelectorViewModel : BindableBase
    {
        #region Events

        public EventHandler<FormElementViewModel> OnElementSelected { get; set; }
        public EventHandler<FormColumnViewModel> OnColumnSelected { get; set; }

        public EventHandler<FormElementViewModel> OnElementRemoved { get; set; }
        public EventHandler<FormElementViewModel> OnCreated { get; set; }

        #endregion

        #region Properties

        private FormRowViewModel _formRow;

        public FormRowViewModel FormRow
        {
            get => _formRow;
            set => SetProperty(ref _formRow, value);
        }

        private FormColumnViewModel _selectedColumn;

        public FormColumnViewModel SelectedColumn
        {
            get => _selectedColumn;
            set
            {
                SetProperty(ref _selectedColumn, value);
                OnColumnSelected?.Invoke(this, _selectedColumn);
                OnElementSelected?.Invoke(this, _selectedColumn?.FormElementViewModel);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand =>
            _deleteCommand ??= new DelegateCommand(() =>
            {
                if (SelectedColumn == null)
                {
                    return;
                }

                FormRow.Columns.Remove(SelectedColumn);

                OnElementRemoved?.Invoke(this, SelectedColumn.FormElementViewModel);
                SelectedColumn = null;
            });


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ??=
                new DelegateCommand(() => OnElementSelected?.Invoke(this, SelectedColumn.FormElementViewModel));

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(() =>
            {
                if (FormRow == null)
                {
                    return;
                }

                var columnPosition = FormRow.Columns.Count + 1;

                var newField = new TextFieldViewModel($"New Text Field {columnPosition}", ElementLabel.Above("Label"),
                    "");
                var newColumnViewModel = new FormColumnViewModel("New Column", 1, newField);

                FormRow.Columns.Add(newColumnViewModel);
                SelectedColumn = newColumnViewModel;
            });

        #endregion
    }
}