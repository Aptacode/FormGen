using System;
using Aptacode.Forms.Shared.Layout;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormGroupSelectorViewModel : BindableBase
    {
        #region Events

        public EventHandler<FormGroupViewModel> OnGroupSelected { get; set; }

        #endregion

        #region Methods

        public void Load()
        {
            if (FormViewModel == null)
            {
                return;
            }

            FormViewModel.Load();
            SelectedGroup = null;
        }

        #endregion

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set
            {
                SetProperty(ref _formViewModel, value);
                Load();
            }
        }

        private FormGroupViewModel _selectedGroup;

        public FormGroupViewModel SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                SetProperty(ref _selectedGroup, value);

                OnGroupSelected?.Invoke(this, SelectedGroup);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(() =>
            {
                if (SelectedGroup == null)
                {
                    return;
                }

                FormViewModel.Remove(SelectedGroup.Group);
                Load();
            }));

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ?? (_createCommand = new DelegateCommand(() =>
            {
                if (FormViewModel == null)
                {
                    return;
                }

                var groupPosition = FormViewModel.Groups.Count + 1;
                var newGroup = FormGroup.EmptyGroup;
                newGroup.Label = $"{FormGroup.DefaultName} {groupPosition.ToString()}";

                FormViewModel.Add(newGroup);
                Load();
                SelectedGroup = new FormGroupViewModel(newGroup);
            }));

        #endregion
    }
}