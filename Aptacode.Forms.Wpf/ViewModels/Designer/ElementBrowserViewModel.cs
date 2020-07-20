using System;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Microsoft.VisualBasic;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class ElementBrowserViewModel : BindableBase
    {
        #region Events

        public EventHandler<FormElementViewModel> OnEditElement { get; set; }

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
                SelectedCompositeElement = FormViewModel?.RootElement;
            }
        }

        private CompositeElementViewModel _selectedCompositeElement;

        public CompositeElementViewModel SelectedCompositeElement
        {
            get => _selectedCompositeElement;
            set => SetProperty(ref _selectedCompositeElement, value);
        }

        private string _selectedCompositeElementType;

        public string SelectedCompositeElementType
        {
            get => _selectedCompositeElementType;
            set
            {
                SetProperty(ref _selectedCompositeElementType, value);

                var oldElement = SelectedCompositeElement;
                switch (value)
                {
                    case "Columns":
                        SelectedCompositeElement = FormBuilder.NewColumn(SelectedCompositeElement.Name, 1);
                        SelectedCompositeElement.Children.AddRange(oldElement.Children);
                        break;
                    case "Rows":
                        SelectedCompositeElement = FormBuilder.NewRow(SelectedCompositeElement.Name, 1);
                        SelectedCompositeElement.Children.AddRange(oldElement.Children);
                        break;
                    case "Groups":
                        var groupTitle = Interaction.InputBox("Enter a group title", "Group Title");
                        SelectedCompositeElement = FormBuilder.NewGroup(SelectedCompositeElement.Name, groupTitle);
                        SelectedCompositeElement.Children.AddRange(oldElement.Children);
                        break;
                }

                var parentElement = FormViewModel.Elements.OfType<CompositeElementViewModel>()
                    .FirstOrDefault(e => e.Children.Contains(oldElement));
                if (parentElement != null)
                {
                    parentElement.Children.Remove(oldElement);
                    parentElement.Children.Add(SelectedCompositeElement);
                }
                else
                {
                    FormViewModel.RootElement = SelectedCompositeElement;
                }
            }
        }

        #endregion

        #region Commands

        private DelegateCommand<ControlElementViewModel> _editCommand;

        public DelegateCommand<ControlElementViewModel> EditCommand =>
            _editCommand ??= new DelegateCommand<ControlElementViewModel>(selectedElement =>
            {
                OnEditElement?.Invoke(this, selectedElement);
            });


        private DelegateCommand<CompositeElementViewModel> _browseCommand;

        public DelegateCommand<CompositeElementViewModel> BrowseCommand =>
            _browseCommand ??= new DelegateCommand<CompositeElementViewModel>(selectedElement =>
            {
                SelectedCompositeElement = selectedElement;
            });

        private DelegateCommand<CompositeElementViewModel> _backCommand;

        public DelegateCommand<CompositeElementViewModel> BackCommand =>
            _backCommand ??= new DelegateCommand<CompositeElementViewModel>(selectedElement =>
            {
                var parentElement = FormViewModel.Elements.OfType<CompositeElementViewModel>()
                    .FirstOrDefault(e => e.Children.Contains(selectedElement));
                SelectedCompositeElement = parentElement ?? FormViewModel?.RootElement;
            });

        private DelegateCommand _createGroupCommand;

        public DelegateCommand CreateGroupCommand =>
            _createGroupCommand ??= new DelegateCommand(_ =>
            {
                var groupName = Interaction.InputBox("Enter a group name", "Group Name");
                var groupTitle = Interaction.InputBox("Enter a group title", "Group Title");

                SelectedCompositeElement.Children.Add(FormBuilder.NewGroup(groupName, groupTitle));
            });


        private DelegateCommand _createControlCommand;

        public DelegateCommand CreateControlCommand =>
            _createControlCommand ??= new DelegateCommand(_ =>
            {
                var name = Interaction.InputBox("Enter a control name", "Control Name");
                var label = Interaction.InputBox("Enter a control label", "Control Label");

                SelectedCompositeElement.Children.Add(FormBuilder.CreateButton(name, ElementLabel.Left(label),
                    "New Button"));
            });


        private DelegateCommand<FormElementViewModel> _deleteCommand;

        public DelegateCommand<FormElementViewModel> DeleteCommand =>
            _deleteCommand ??= new DelegateCommand<FormElementViewModel>(selectedElement =>
            {
                if (selectedElement == SelectedCompositeElement)
                {
                    var parentElement = FormViewModel.Elements.OfType<CompositeElementViewModel>()
                        .FirstOrDefault(e => e.Children.Contains(selectedElement));
                    if (parentElement == null)
                    {
                        return;
                    }

                    SelectedCompositeElement = parentElement ?? FormViewModel?.RootElement;
                    parentElement.Children.Remove(selectedElement);
                }
                else
                {
                    SelectedCompositeElement.Children.Remove(selectedElement);
                }
            });

        #endregion
    }
}