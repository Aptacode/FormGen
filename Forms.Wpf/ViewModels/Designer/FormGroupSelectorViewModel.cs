using System;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormGroupSelectorViewModel : BindableBase
    {
        public FormGroupSelectorViewModel(FormViewModel formViewModel)
        {
            FormViewModel = formViewModel;
            Load();
        }

        #region Events

        public EventHandler<FormGroupViewModel> OnGroupSelected { get; set; }

        #endregion

        #region Methods

        public void Load()
        {
            FormViewModel.Load();
            FormViewModel.Groups.Add(new FormGroupViewModel(FormGroup.EmptyGroup));
            SelectedGroup = null;
        }

        #endregion

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        private FormGroupViewModel _selectedGroup;

        public FormGroupViewModel SelectedGroup
        {
            get => _selectedGroup;
            set
            {
                SetProperty(ref _selectedGroup, value);

                if (_selectedGroup == null || _selectedGroup.Group.Equals(FormGroup.EmptyGroup))
                {
                    OnGroupSelected?.Invoke(this, null);
                    return;
                }

                OnGroupSelected?.Invoke(this, SelectedGroup);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _removeCommand;

        public DelegateCommand RemoveCommand =>
            _removeCommand ?? (_removeCommand = new DelegateCommand(async () =>
            {
                if (SelectedGroup == null)
                {
                    return;
                }

                FormViewModel.Remove(SelectedGroup.Group);
                Load();
            }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() =>
            {
                if (SelectedGroup != null && !SelectedGroup.Group.Equals(FormGroup.EmptyGroup))
                {
                    FormViewModel.Add(SelectedGroup.Group);
                }

                Load();
            }));

        #endregion
    }
}