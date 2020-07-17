using System;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormGroupSelectorViewModel : BindableBase
    {
        #region Events

        public EventHandler<GroupElementViewModel> OnGroupSelected { get; set; }

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
                Selected = null;
            }
        }

        private GroupElementViewModel _selected;

        public GroupElementViewModel Selected
        {
            get => _selected;
            set
            {
                SetProperty(ref _selected, value);

                OnGroupSelected?.Invoke(this, Selected);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand =>
            _deleteCommand ??= new DelegateCommand(() =>
            {
                if (Selected == null)
                {
                    return;
                }

                //  FormViewModel.Groups.Remove(Selected);
                Selected = null;
            });

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(() =>
            {
                if (FormViewModel == null) { }

                //var groupPosition = FormViewModel.Groups.Count + 1;
                //var newGroupName = $"New Group {groupPosition}";
                //var newGroup = new GroupElementViewModel(newGroupName, newGroupName);
                //FormViewModel.Groups.Add(newGroup);
                //Selected = newGroup;
            });

        #endregion
    }
}