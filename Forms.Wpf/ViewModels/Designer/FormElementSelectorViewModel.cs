using System;
using System.Collections.ObjectModel;
using System.Linq;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Elements.Fields;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementSelectorViewModel : BindableBase
    {
        public FormElementSelectorViewModel()
        {
            Elements = new ObservableCollection<FormElementViewModel>();
        }

        #region Methods

        public void Load()
        {
            Clear();
            if (FormRow == null)
            {
                return;
            }

            Elements.AddRange(FormRow.Columns.Select(c => c.FormElementViewModel).ToList());
        }

        public void Clear()
        {
            SelectedElement = null;
            Elements.Clear();
        }

        #endregion

        #region Events

        public EventHandler<FormElementViewModel> OnElementSelected { get; set; }
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

        public ObservableCollection<FormElementViewModel> Elements { get; set; }

        private FormElementViewModel _selectedElement;

        public FormElementViewModel SelectedElement
        {
            get => _selectedElement;
            set
            {
                SetProperty(ref _selectedElement, value);
                OnElementSelected?.Invoke(this, _selectedElement);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _removeCommand;

        public DelegateCommand RemoveCommand =>
            _removeCommand ?? (_removeCommand = new DelegateCommand(async () =>
            {
                if (SelectedElement == null)
                {
                    return;
                }

                FormRow.Remove(SelectedElement.FormElement);

                OnElementRemoved?.Invoke(this, SelectedElement);
                SelectedElement = null;
                Load();
            }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() =>
            {
                OnElementSelected?.Invoke(this, _selectedElement);
            }));

        private DelegateCommand _addButtonCommand;
        public DelegateCommand AddButtonCommand =>
            _addButtonCommand ?? (_addButtonCommand = new DelegateCommand(async () =>
            {
                var newField = new TextField("Default", LabelPosition.AboveElement, "Default", new ValidationRule<TextField>[0]);
                FormRow.Add(newField);
                Load();
                SelectedElement = new TextFieldViewModel(newField);
            }));

        #endregion
    }
}