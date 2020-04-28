using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            Elements = new ObservableCollection<FormElementViewModel>();
        }

        #region Events

        public EventHandler<FormElementViewModel> OnSelected { get; set; }
        public EventHandler<FormElementViewModel> OnRemoved { get; set; }
        public EventHandler<FormElementViewModel> OnCreated { get; set; }


        #endregion

        #region Methods

        public void Load(FormRowViewModel formRow)
        {
            SelectedElement = null;
            FormRow = formRow;
            Elements.Clear();
            if(formRow == null)
                return;

            Elements.AddRange(formRow.Columns.Select(c => c.FormElementViewModel).ToList());
        }

        #endregion

        #region Properties

        private FormRowViewModel _formRow;

        public FormRowViewModel FormRow
        {
            get => _formRow;
            set => SetProperty(ref _formRow, value);
        }

        public ObservableCollection<FormElementViewModel> Elements { get; set; }

        private FormElementViewModel _selectedElement;

        public FormElementViewModel SelectedElement
        {
            get => _selectedElement;
            set
            {
                SetProperty(ref _selectedElement, value);
                OnSelected?.Invoke(this, _selectedElement);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _removeCommand;

        public DelegateCommand RemoveCommand =>
            _removeCommand ?? (_removeCommand = new DelegateCommand(async () =>
            {

            }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() =>
            {

            }));

        #endregion
    }
}