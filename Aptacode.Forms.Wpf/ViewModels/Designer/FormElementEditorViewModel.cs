using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Aptacode.Forms.Wpf.Views.Designer;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementEditorViewModel : BindableBase
    {
        private readonly TextElementViewModel _elementLabelTextBox;
        private readonly TextElementViewModel _elementNameTextBox;
        private readonly SelectElementViewModel _elementTypeComboBox;
        private readonly SelectElementViewModel _elementLabelPosition;
        private readonly SelectElementViewModel _elementVerticalAlignment;

        public FormElementEditorViewModel()
        {
            _elementNameTextBox = new TextElementViewModel("elementNameTextBox",
                ElementLabel.Left("Control Name"), ControlElement.VerticalAlignment.Center, "");

            _elementLabelTextBox =
                new TextElementViewModel("elementLabelTextBox", ElementLabel.Left("Label Text"), ControlElement.VerticalAlignment.Center, "");

            _elementTypeComboBox = new SelectElementViewModel("elementTypeComboBox", ElementLabel.Left("Control Type"), ControlElement.VerticalAlignment.Center,
                new List<string> {"Button", "Html", "CheckBox", "ComboBox", "TextBox", "Columns", "Rows", "Group"}, "");

            _elementLabelPosition = new SelectElementViewModel("elementLabelPosition", ElementLabel.Left("Label Position"), ControlElement.VerticalAlignment.Center,
                new List<string> { "Hidden", "Above", "Below", "Left", "Right" }, "Hidden");

            _elementVerticalAlignment = new SelectElementViewModel("elementVerticalAlignment", ElementLabel.Left("Vertical Alignment"), ControlElement.VerticalAlignment.Center,
                new List<string> { "Center", "Top", "Bottom" }, "Center");

            _elementTypeComboBox.OnFormEvent += ElementTypeComboBoxOnOnFormEvent;
            _elementNameTextBox.OnFormEvent += ElementNameTextBoxOnOnFormEvent;
            _elementLabelTextBox.OnFormEvent += ElementLabelTextBoxOnOnFormEvent;
            _elementLabelPosition.OnFormEvent += _elementLabelPosition_OnFormEvent;
            _elementVerticalAlignment.OnFormEvent += _elementVerticalAlignment_OnFormEvent;
        }

        private void _elementVerticalAlignment_OnFormEvent(object sender, FormElementEvent e)
        {
            if (e is SelectElementChangedEvent eventArgs)
            {
                if (!Enum.TryParse(eventArgs.NewValue, out ControlElement.VerticalAlignment alignment))
                {
                    alignment = ControlElement.VerticalAlignment.Center;
                }

                FormElement.Alignment = alignment;
            }
        }

        private void _elementLabelPosition_OnFormEvent(object sender, FormElementEvent e)
        {
            if (e is SelectElementChangedEvent eventArgs)
            {
                if(!Enum.TryParse(eventArgs.NewValue, out ElementLabel.LabelPosition position))
                {
                    position = ElementLabel.LabelPosition.Hidden;
                }

                FormElement.Label.Position = position;
            }
        }

        private void ElementLabelTextBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is TextElementChangedEvent eventArgs)
            {
                FormElement.Label.Text = eventArgs.NewValue;
            }
        }

        private void ElementNameTextBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is TextElementChangedEvent eventArgs)
            {
                FormElement.Name = eventArgs.NewValue;
            }
        }

        private void ElementTypeComboBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            var oldElement = FormElement;

            if (!(e is SelectElementChangedEvent eventArgs))
            {
                return;
            }

            if (ElementTypeToFriendlyName(FormElement?.ControlModel.GetType()) == eventArgs.NewValue)
            {
                return;
            }

            ControlElementViewModel newElementViewModel = null;

            switch (eventArgs.NewValue)
            {
                case "Button":
                    newElementViewModel = new ButtonElementViewModel(oldElement.Name, oldElement.Label.Model, ControlElement.VerticalAlignment.Center, "");
                    break;
                case "Html":
                    newElementViewModel = new HtmlElementViewModel(oldElement.Name, oldElement.Label.Model, ControlElement.VerticalAlignment.Center,
                        string.Empty);
                    break;
                case "CheckBox":
                    newElementViewModel =
                        new CheckElementViewModel(oldElement.Name, oldElement.Label.Model, ControlElement.VerticalAlignment.Center, string.Empty, false);
                    break;
                case "TextBox":
                    newElementViewModel = new TextElementViewModel(oldElement.Name, oldElement.Label.Model, ControlElement.VerticalAlignment.Center, "");
                    break;
                case "ComboBox":
                    newElementViewModel = new SelectElementViewModel(oldElement.Name, oldElement.Label.Model, ControlElement.VerticalAlignment.Center,
                        new string[0], string.Empty);
                    break;
            }

            ParentElement.Children.Remove(oldElement);
            ParentElement.Children.Add(newElementViewModel);
            FormElement = newElementViewModel;
        }

        #region Methods

        private string ElementTypeToFriendlyName(Type elementType)
        {
            switch (elementType.Name)
            {
                case nameof(ButtonElement):
                    return "Button";
                case nameof(HtmlElement):
                    return "Html";
                case nameof(CheckElement):
                    return "CheckBox";
                case nameof(TextElement):
                    return "TextBox";
                case nameof(SelectElement):
                    return "ComboBox";
            }

            return string.Empty;
        }

        private void AddButtonConfigurationRows(CompositeElementViewModel group, ButtonElementViewModel button)
        {
            var textField =
                new TextElementViewModel("buttonContentTextBox", ElementLabel.Left("Content"), ControlElement.VerticalAlignment.Center, button.Content);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextElementChangedEvent eventArgs)
                {
                    button.Content = eventArgs.NewValue;
                }
            };

            group.AddRows("Default", 1).AddColumns("buttonContentTextBox", 1, textField);
        }

        private void AddHtmlConfigurationRows(CompositeElementViewModel group, HtmlElementViewModel element)
        {
            var buttonField =
                new ButtonElementViewModel("editHtml", ElementLabel.Left("Edit"), ControlElement.VerticalAlignment.Center, "Edit");

            buttonField.OnFormEvent += (s, e) =>
            {
                if (e is ButtonElementClickedEvent eventArgs)
                {
                    var htmlEditor = new HtmlEditorDialog(element.Content);
                    htmlEditor.ShowDialog();

                    element.Content = htmlEditor.ViewModel.Content;
                    Refresh();
                }
            };

            group.AddRows("Default", 1).AddColumns("editHtml", 1, buttonField);
        }

        private void AddTextConfigurationRows(CompositeElementViewModel group, TextElementViewModel element)
        {
            var textField =
                new TextElementViewModel("htmlContent", ElementLabel.Left("Content"), ControlElement.VerticalAlignment.Center, element.DefaultContent);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextElementChangedEvent eventArgs)
                {
                    element.DefaultContent = eventArgs.NewValue;
                    element.Content = eventArgs.NewValue;
                }
            };

            group.AddRows("Default", 1).AddColumns("htmlContent", 1, textField);
        }

        private void AddComboBoxConfigurationRows(CompositeElementViewModel group, SelectElementViewModel element)
        {
            var optionsField = new TextElementViewModel("options", ElementLabel.Left("Options"), ControlElement.VerticalAlignment.Center,
                string.Join(",", element.Items));

            var defaultSelectedText = new TextElementViewModel("defaultText", ElementLabel.Left("Default Text"), ControlElement.VerticalAlignment.Center,
                element.DefaultSelectedItem);
            var defaultSelectedItem = new SelectElementViewModel("defaultItem", ElementLabel.Left("Default Item"), ControlElement.VerticalAlignment.Center,
                element.Items, element.DefaultSelectedItem);

            optionsField.OnFormEvent += (s, e) =>
            {
                if (e is TextElementChangedEvent eventArgs)
                {
                    var newModel = element.Model;
                    newModel.Items = eventArgs.NewValue.Split(',').ToList();

                    defaultSelectedItem.Items.Clear();
                    defaultSelectedItem.Items.AddRange(eventArgs.NewValue.Split(',').ToList());
                    if (!defaultSelectedItem.Items.Contains(element.DefaultSelectedItem))
                    {
                        defaultSelectedItem.DefaultSelectedItem = string.Empty;
                        newModel.DefaultSelectedItem = string.Empty;
                    }

                    element.Model = newModel;
                }
            };


            defaultSelectedItem.OnFormEvent += (s, e) =>
            {
                if (e is SelectElementChangedEvent eventArgs && element.SelectedItem != eventArgs.NewValue)
                {
                    element.DefaultSelectedItem = eventArgs.NewValue;
                    element.SelectedItem = eventArgs.NewValue;
                    defaultSelectedText.Content = eventArgs.NewValue;
                }
            };

            defaultSelectedText.OnFormEvent += (s, e) =>
            {
                if (e is TextElementChangedEvent eventArgs && element.SelectedItem != eventArgs.NewValue)
                {
                    element.DefaultSelectedItem = eventArgs.NewValue;
                    element.SelectedItem = string.Empty;
                    defaultSelectedItem.SelectedItem = string.Empty;
                    defaultSelectedItem.DefaultSelectedItem = eventArgs.NewValue;
                }
            };

            var newRow = group.AddRows("Default", 1);

            newRow.AddColumns("options", 1, optionsField);
            newRow.AddColumns("selectedOption", 1, defaultSelectedItem);
            newRow.AddColumns("selectedText", 1, defaultSelectedText);
        }

        private void AddCheckBoxConfigurationRows(CompositeElementViewModel group, CheckElementViewModel element)
        {
            var textField = new TextElementViewModel("contentTextField", ElementLabel.Left("Default Content"), ControlElement.VerticalAlignment.Center,
                element.Content);

            var checkedField = new CheckElementViewModel("checkbox", ElementLabel.Left("Default Value"), ControlElement.VerticalAlignment.Center,
                element.Content, element.DefaultIsChecked);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextElementChangedEvent eventArgs)
                {
                    element.Content = eventArgs.NewValue;
                }
            };

            checkedField.OnFormEvent += (s, e) =>
            {
                if (e is CheckElementChangedEvent eventArgs)
                {
                    element.DefaultIsChecked = eventArgs.NewValue;
                    element.IsChecked = eventArgs.NewValue;
                }
            };


            var newRow = group.AddRows("Default", 1);

            newRow.AddColumns("contentTextField", 1, textField);
            newRow.AddColumns("checkbox", 1, checkedField);
        }

        private void AddElementConfigurationRows(CompositeElementViewModel group, FormElementViewModel formElement)
        {
            switch (formElement)
            {
                case ButtonElementViewModel buttonElement:
                    AddButtonConfigurationRows(group, buttonElement);
                    break;
                case HtmlElementViewModel htmlElement:
                    AddHtmlConfigurationRows(group, htmlElement);
                    break;
                case CheckElementViewModel checkBox:
                    AddCheckBoxConfigurationRows(group, checkBox);
                    break;
                case TextElementViewModel textField:
                    AddTextConfigurationRows(group, textField);
                    break;
                case SelectElementViewModel comboBox:
                    AddComboBoxConfigurationRows(group, comboBox);
                    break;
            }
        }

        public void Clear()
        {
            ElementEditorFormViewModel = null;
        }

        public void Refresh()
        {
            if (FormElement == null)
            {
                ParentElement = null;
                return;
            }

            ParentElement = FormViewModel.Elements.OfType<CompositeElementViewModel>()
                .FirstOrDefault(e => e.Children.Contains(FormElement));

            var form = FormBuilder.CreateForm("Element Editor Form", "Element Editor Form");
            var group = FormBuilder.NewRow("Element Editor", 1);

            group.AddRows("Default", 1).AddColumns("Element Type", 1, _elementTypeComboBox);
            group.AddRows("Default", 1).AddColumns("Element Name", 1, _elementNameTextBox);
            group.AddRows("Default", 1).AddColumns("Label", 1, _elementLabelTextBox, _elementLabelPosition);
            group.AddRows("Default", 1).AddColumns("Vertical Alignment", 1, _elementVerticalAlignment);

            _elementNameTextBox.Content = FormElement.Name;
            _elementLabelTextBox.Content = FormElement.Label.Text;
            _elementLabelPosition.SelectedItem = FormElement.Label.Position.ToString();
            _elementVerticalAlignment.SelectedItem = FormElement.Alignment.ToString();
            _elementTypeComboBox.SelectedItem = ElementTypeToFriendlyName(FormElement?.ControlModel?.GetType());


            AddElementConfigurationRows(group, FormElement);

            form.RootElement = group;
            ElementEditorFormViewModel = form;
        }

        #endregion

        #region Events

        public EventHandler<FormElementViewModel> OnSelected { get; set; }
        public EventHandler<FormElementViewModel> OnRemoved { get; set; }
        public EventHandler<FormElementViewModel> OnCreated { get; set; }

        #endregion

        #region Properties

        private CompositeElementViewModel _parentElement;

        public CompositeElementViewModel ParentElement
        {
            get => _parentElement;
            set => SetProperty(ref _parentElement, value);
        }


        private ControlElementViewModel _formElement;

        public ControlElementViewModel FormElement
        {
            get => _formElement;
            set
            {
                SetProperty(ref _formElement, value);
                Refresh();
            }
        }

        private FormViewModel _elementEditorFormViewModel;

        public FormViewModel ElementEditorFormViewModel
        {
            get => _elementEditorFormViewModel;
            set => SetProperty(ref _elementEditorFormViewModel, value);
        }


        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        #endregion
    }
}