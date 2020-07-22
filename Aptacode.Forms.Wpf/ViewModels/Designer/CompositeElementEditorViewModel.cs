using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Factories;
using Aptacode.Forms.Wpf.Views;
using Aptacode.Forms.Wpf.Views.Designer;
using BindableBase = Prism.Mvvm.BindableBase;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class CompositeElementEditorViewModel : BindableBase
    {

        #region Properties

        private string _selectedElementType;

        public string SelectedElementType
        {
            get { return _selectedElementType; }
            set
            {
                SetProperty(ref _selectedElementType, value);
                if (_selectedElement != null && SelectedElementType != _selectedElement?.Model.GetType().Name)
                {
                    CompositeElementViewModel newElementViewModel = _selectedElement;
                    switch (SelectedElementType)
                    {
                        case nameof(GroupElement):
                            newElementViewModel = new GroupElementViewModel(new GroupElement(SelectedElement.Model.Name, "", SelectedElement.Model.Children.ToArray()));
                            break;
                        case nameof(RowElement):
                            newElementViewModel = new RowElementViewModel(new RowElement(SelectedElement.Model.Name, 1, SelectedElement.Model.Children.ToArray()));
                            break;
                        case nameof(ColumnElement):
                            newElementViewModel = new ColumnElementViewModel(new ColumnElement(SelectedElement.Model.Name,1, SelectedElement.Model.Children.ToArray()));
                            break;
                    }

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
            get { return _newElementType; }
            set
            {
                SetProperty(ref _newElementType, value);
            }
        }
        

        private FormElementViewModel _selectedChildElement;

        public FormElementViewModel SelectedChildElement
        {
            get => _selectedChildElement;
            set
            {
                SetProperty(ref _selectedChildElement, value);
            }
        }

        private CompositeElementViewModel _selectedElement;

        public CompositeElementViewModel SelectedElement
        {
            get => _selectedElement;
            set
            {
                SetProperty(ref _selectedElement, value);
                SelectedElementType = _selectedElement?.Model.GetType().Name;
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
            _addElementCommand ??= new DelegateCommand((_) =>
            {

                if (SelectedElement != null)
                {
                    FormElement newChildElement = null;
                    var elementName =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter a name for the new Element", "New Element");
                    switch (NewElementType)
                    {
                        case nameof(GroupElement):
                            newChildElement = new GroupElement(elementName, "");
                            break;
                        case nameof(RowElement):
                            newChildElement = new RowElement(elementName, 1);
                            break;
                        case nameof(ColumnElement):
                            newChildElement = new ColumnElement(elementName, 1);
                            break;

                        case nameof(CheckElement):
                            newChildElement = new CheckElement(elementName, ElementLabel.None, ControlElement.VerticalAlignment.Center, "", false);
                            break;
                        case nameof(SelectElement):
                            newChildElement = new SelectElement(elementName, ElementLabel.None, ControlElement.VerticalAlignment.Center, new List<string>(), "");
                            break;
                        case nameof(TextElement):
                            newChildElement = new TextElement(elementName, ElementLabel.None, ControlElement.VerticalAlignment.Center, "");
                            break;
                        case nameof(ButtonElement):
                            newChildElement = new ButtonElement(elementName, ElementLabel.None, ControlElement.VerticalAlignment.Center, "");
                            break;
                        case nameof(HtmlElement):
                            newChildElement = new HtmlElement(elementName, ElementLabel.None, ControlElement.VerticalAlignment.Center, "");
                            break;
                    }

                    SelectedElement.Children.Add(FormElementViewModelFactory.Create(newChildElement));
                }


            });

        private DelegateCommand<CompositeElementViewModel> _removeElementCommand;

        public DelegateCommand<CompositeElementViewModel> RemoveElementCommand =>
            _removeElementCommand ??= new DelegateCommand<CompositeElementViewModel>((parameter) =>
            {
                if (parameter != null)
                {
                    SelectedElement.Children.Remove(parameter);
                }

            });

        private DelegateCommand<CompositeElementViewModel> _moveElementUpCommand;

        public DelegateCommand<CompositeElementViewModel> MoveElementUpCommand =>
            _moveElementUpCommand ??= new DelegateCommand<CompositeElementViewModel>((parameter) =>
            {
                if (parameter != null)
                {
                    var position = SelectedElement.Children.IndexOf(parameter);
                    var newPosition = position - 1;
                    if(newPosition >= 0)
                    {
                        SelectedElement.Children.RemoveAt(position);
                        SelectedElement.Children.Insert(newPosition, parameter);
                    }


                }

            });

        private DelegateCommand<CompositeElementViewModel> _moveElementDownCommand;

        public DelegateCommand<CompositeElementViewModel> MoveElementDownCommand =>
            _moveElementDownCommand ??= new DelegateCommand<CompositeElementViewModel>((parameter) =>
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