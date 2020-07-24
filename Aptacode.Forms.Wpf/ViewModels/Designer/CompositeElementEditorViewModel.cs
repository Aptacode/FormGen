using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Builders.Elements.Layouts;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Factories;
using Microsoft.VisualBasic;
using BindableBase = Prism.Mvvm.BindableBase;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public static class CompositeElementViewModelExtensions
    {
        public static CompositeElementViewModel TransformInto(this CompositeElementViewModel viewModel,
            string destinationTypeName)
        {
            switch (destinationTypeName)
            {
                case nameof(GroupElement):
                    return new GroupElementViewModel(new GroupBuilder().FromTemplate(viewModel.Model).Build());
                case nameof(RowElement):
                    return new RowElementViewModel(new RowBuilder().FromTemplate(viewModel.Model).Build());
                case nameof(UniformRowElement):
                    return new UniformRowElementViewModel(new UniformRowBuilder().FromTemplate(viewModel.Model)
                        .Build());
                case nameof(ColumnElement):
                    return new ColumnElementViewModel(new ColumnBuilder().FromTemplate(viewModel.Model).Build());
            }

            return viewModel;
        }
    }

    public class CompositeElementEditorViewModel : BindableBase
    {
        #region Properties

        private string _selectedElementType;

        public string SelectedElementType
        {
            get => _selectedElementType;
            set
            {
                SetProperty(ref _selectedElementType, value);
                if (_selectedElement != null && SelectedElementType != _selectedElement?.Model.GetType().Name)
                {
                    var newElementViewModel = SelectedElement.TransformInto(SelectedElementType);

                    if (SelectedElement != FormViewModel.RootElement)
                    {
                        var parentElement = FormViewModel.GetParent(SelectedElement);
                        var selectedElementIndex = parentElement.Children.IndexOf(SelectedElement);
                        parentElement.Children.RemoveAt(selectedElementIndex);
                        parentElement.Children.Insert(selectedElementIndex, newElementViewModel);
                    }
                    else
                    {
                        FormViewModel.RootElement = newElementViewModel;
                    }

                    SelectedElement = newElementViewModel;
                }
            }
        }

        private string _newElementType;

        public string NewElementType
        {
            get => _newElementType;
            set => SetProperty(ref _newElementType, value);
        }

        private string _selectedHorizontalAlignment;

        public string SelectedHorizontalAlignment
        {
            get => _selectedHorizontalAlignment;
            set
            {
                SetProperty(ref _selectedHorizontalAlignment, value);

                if (Enum.TryParse(_selectedHorizontalAlignment, true, out HorizontalAlignment alignment))
                {
                    SelectedElement.HorizontalAlignment = alignment;
                }
            }
        }

        private string _selectedVerticalAlignment;

        public string SelectedVerticalAlignment
        {
            get => _selectedVerticalAlignment;
            set
            {
                SetProperty(ref _selectedVerticalAlignment, value);

                if (Enum.TryParse(_selectedVerticalAlignment, true, out VerticalAlignment alignment))
                {
                    SelectedElement.VerticalAlignment = alignment;
                }
            }
        }


        private FormElementViewModel _selectedChildElement;

        public FormElementViewModel SelectedChildElement
        {
            get => _selectedChildElement;
            set => SetProperty(ref _selectedChildElement, value);
        }

        private CompositeElementViewModel _selectedElement;

        public CompositeElementViewModel SelectedElement
        {
            get => _selectedElement;
            set
            {
                SetProperty(ref _selectedElement, value);
                SelectedElementType = _selectedElement?.Model.GetType().Name;
                SelectedHorizontalAlignment = _selectedElement?.Model.HorizontalAlignment.ToString();
                SelectedVerticalAlignment = _selectedElement?.Model.VerticalAlignment.ToString();
            }
        }

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        #endregion

        #region Commands

        private DelegateCommand _addElementCommand;

        public DelegateCommand AddElementCommand =>
            _addElementCommand ??= new DelegateCommand(_ =>
            {
                if (SelectedElement != null)
                {
                    var elementName = Interaction.InputBox("Enter a name for the new Element", "New Element");

                    var element = FormElementViewModelFactory.Create(NewElementType, elementName);
                    var elementViewModel = FormElementViewModelFactory.Create(element);
                    SelectedElement.Children.Add(elementViewModel);
                }
            });

        private DelegateCommand<FormElementViewModel> _removeElementCommand;

        public DelegateCommand<FormElementViewModel> RemoveElementCommand =>
            _removeElementCommand ??= new DelegateCommand<FormElementViewModel>(parameter =>
            {
                if (parameter != null)
                {
                    SelectedElement.Children.Remove(parameter);
                }
            });

        private DelegateCommand<FormElementViewModel> _moveElementUpCommand;

        public DelegateCommand<FormElementViewModel> MoveElementUpCommand =>
            _moveElementUpCommand ??= new DelegateCommand<FormElementViewModel>(parameter =>
            {
                if (parameter != null)
                {
                    var position = SelectedElement.Children.IndexOf(parameter);
                    var newPosition = position - 1;
                    if (newPosition >= 0)
                    {
                        SelectedElement.Children.RemoveAt(position);
                        SelectedElement.Children.Insert(newPosition, parameter);
                    }
                }
            });

        private DelegateCommand<FormElementViewModel> _moveElementDownCommand;

        public DelegateCommand<FormElementViewModel> MoveElementDownCommand =>
            _moveElementDownCommand ??= new DelegateCommand<FormElementViewModel>(parameter =>
            {
                if (parameter != null)
                {
                    var position = SelectedElement.Children.IndexOf(parameter);
                    var newPosition = position + 1;

                    if (newPosition < SelectedElement.Children.Count)
                    {
                        SelectedElement.Children.RemoveAt(position);
                        SelectedElement.Children.Insert(newPosition, parameter);
                    }
                }
            });

        #endregion
    }
}