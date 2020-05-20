using System;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Layout;
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
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(() =>
            {
                if (SelectedColumn == null)
                {
                    return;
                }

                FormRow.Remove(SelectedColumn.Column);

                OnElementRemoved?.Invoke(this, SelectedColumn.FormElementViewModel);
                SelectedColumn = null;
            }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() =>
            {
                OnElementSelected?.Invoke(this, SelectedColumn.FormElementViewModel);
            }));

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ?? (_createCommand = new DelegateCommand(() =>
            {
                if (FormRow == null)
                {
                    return;
                }

                var columnPosition = FormRow.Columns.Count + 1;
                var newField = new TextField($"Column {columnPosition.ToString()}", LabelPosition.AboveElement, "Label",
                    new ValidationRule<TextField>[0]);

                var column = new FormColumn(1, newField);
                FormRow.Add(column);
                SelectedColumn = new FormColumnViewModel(column);
            }));

        #endregion
    }
}