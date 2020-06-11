using System;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Layout;
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

        #endregion

        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set
            {
                SetProperty(ref _formViewModel, value);
                SelectedGroup = null;
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
            _deleteCommand ??= new DelegateCommand(() =>
            {
                if (SelectedGroup == null)
                {
                    return;
                }

                FormViewModel.Groups.Remove(SelectedGroup);
                SelectedGroup = null;
            });

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(() =>
            {
                if (FormViewModel == null)
                {
                    return;
                }

                var groupPosition = FormViewModel.Groups.Count + 1;
                string newGroupName = $"New Group {groupPosition}";
                var newGroup = new FormGroupViewModel(newGroupName, newGroupName);
                FormViewModel.Groups.Add(newGroup);
                SelectedGroup = newGroup;
            });

        #endregion
    }
}