using System;
using System.Collections.ObjectModel;
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
        public FormElementSelectorViewModel()
        {
            Columns = new ObservableCollection<FormColumnViewModel>();
        }

        #region Methods

        public void Load()
        {
            Clear();
            if (FormRow == null)
            {
            }
        }

        public void Clear()
        {
            SelectedColumn = null;
        }

        #endregion

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
            set
            {
                SetProperty(ref _formRow, value);
                Load();
            }
        }

        public ObservableCollection<FormColumnViewModel> Columns { get; set; }

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
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(async () =>
            {
                if (SelectedColumn == null)
                {
                    return;
                }

                FormRow.Remove(SelectedColumn.Column);

                OnElementRemoved?.Invoke(this, SelectedColumn.FormElementViewModel);
                SelectedColumn = null;
                Load();
            }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() =>
            {
                OnElementSelected?.Invoke(this, SelectedColumn.FormElementViewModel);
            }));

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ?? (_createCommand = new DelegateCommand(async () =>
            {
                if (FormRow == null)
                {
                    return;
                }

                var newField = new TextField("Default", LabelPosition.AboveElement, "Default",
                    new ValidationRule<TextField>[0]);
                var column = new FormColumn(1, newField);
                FormRow.Add(column);
                Load();
                SelectedColumn = new FormColumnViewModel(column);
            }));

        #endregion
    }
}