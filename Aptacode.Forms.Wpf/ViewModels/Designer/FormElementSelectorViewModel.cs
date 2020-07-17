using System;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementSelectorViewModel : BindableBase
    {
        #region Events

        public EventHandler<FormElementViewModel> OnElementSelected { get; set; }
        public EventHandler<ColumnElementViewModel> OnColumnSelected { get; set; }

        public EventHandler<FormElementViewModel> OnElementRemoved { get; set; }
        public EventHandler<FormElementViewModel> OnCreated { get; set; }

        #endregion

        #region Properties

        private RowElementViewModel _rowElement;

        public RowElementViewModel RowElement
        {
            get => _rowElement;
            set => SetProperty(ref _rowElement, value);
        }

        private ColumnElementViewModel _selectedColumnLayout;

        public ColumnElementViewModel SelectedColumnLayout
        {
            get => _selectedColumnLayout;
            set
            {
                SetProperty(ref _selectedColumnLayout, value);
                OnColumnSelected?.Invoke(this, _selectedColumnLayout);
                OnElementSelected?.Invoke(this, _selectedColumnLayout?.Children.FirstOrDefault());
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand =>
            _deleteCommand ??= new DelegateCommand(() =>
            {
                if (SelectedColumnLayout == null)
                {
                    return;
                }

                RowElement.Children.Remove(SelectedColumnLayout);

                OnElementRemoved?.Invoke(this, SelectedColumnLayout.Children.FirstOrDefault());
                SelectedColumnLayout = null;
            });


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ??=
                new DelegateCommand(() =>
                    OnElementSelected?.Invoke(this, SelectedColumnLayout.Children.FirstOrDefault()));

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(() =>
            {
                if (RowElement == null)
                {
                    return;
                }

                var columnPosition = RowElement.Children.Count + 1;

                var newField = new TextElementViewModel($"New Text Field {columnPosition}", ElementLabel.Above("Label"),
                    "");
                var newColumnViewModel = FormBuilder.NewColumn("New Column", 1, newField);

                RowElement.Children.Add(newColumnViewModel);
                SelectedColumnLayout = newColumnViewModel;
            });

        #endregion
    }
}