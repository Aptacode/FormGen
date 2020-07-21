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

        public FormElementEditorViewModel()
        {
            _elementNameTextBox = new TextElementViewModel("elementNameTextBox",
                ElementLabel.Above("Name"), "Name");

            _elementLabelTextBox =
                new TextElementViewModel("elementLabelTextBox", ElementLabel.Above("Label"), "Label");

            _elementTypeComboBox = new SelectElementViewModel("elementTypeComboBox", ElementLabel.Above("Type"),
                new List<string> {"Button", "Html", "CheckBox", "ComboBox", "TextBox", "Columns", "Rows", "Group"}, "");

            _elementTypeComboBox.OnFormEvent += ElementTypeComboBoxOnOnFormEvent;
            _elementNameTextBox.OnFormEvent += ElementNameTextBoxOnOnFormEvent;
            _elementLabelTextBox.OnFormEvent += ElementLabelTextBoxOnOnFormEvent;
        }

        private void ElementLabelTextBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is TextElementChangedEvent eventArgs)
            {
                FormElement.Label = new ElementLabel(FormElement.Label.Position, eventArgs.NewValue);
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

            if (ElementTypeToFriendlyName(FormElement?.ElementModel.GetType()) == eventArgs.NewValue)
            {
                return;
            }

            ControlElementViewModel newElementViewModel = null;

            switch (eventArgs.NewValue)
            {
                case "Button":
                    newElementViewModel = new ButtonElementViewModel(oldElement.Name, oldElement.Label, "");
                    break;
                case "Html":
                    newElementViewModel = new HtmlElementViewModel(oldElement.Name, oldElement.Label,
                        string.Empty);
                    break;
                case "CheckBox":
                    newElementViewModel =
                        new CheckElementViewModel(oldElement.Name, oldElement.Label, string.Empty, false);
                    break;
                case "TextBox":
                    newElementViewModel = new TextElementViewModel(oldElement.Name, oldElement.Label, "");
                    break;
                case "ComboBox":
                    newElementViewModel = new SelectElementViewModel(oldElement.Name, oldElement.Label,
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
            switch (elementType.GetType().Name)
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

        private void AddButtonConfigurationRows(GroupElementViewModel group, ButtonElementViewModel button)
        {
            var textField =
                new TextElementViewModel("buttonContentTextBox", ElementLabel.Above("Content"), button.Content);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextElementChangedEvent eventArgs)
                {
                    button.Content = eventArgs.NewValue;
                }
            };

            group.AddRows("Default", 1).AddColumns("buttonContentTextBox", 1, textField);
        }

        private void AddHtmlConfigurationRows(GroupElementViewModel group, HtmlElementViewModel element)
        {
            var buttonField =
                new ButtonElementViewModel("editHtml", ElementLabel.Above("Edit"), "Edit");

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

        private void AddTextConfigurationRows(GroupElementViewModel group, TextElementViewModel element)
        {
            var textField =
                new TextElementViewModel("htmlContent", ElementLabel.Above("Content"), element.DefaultContent);

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

        private void AddComboBoxConfigurationRows(GroupElementViewModel group, SelectElementViewModel element)
        {
            var optionsField = new TextElementViewModel("options", ElementLabel.Above("Options"),
                string.Join(",", element.Items));

            var defaultSelectedText = new TextElementViewModel("defaultText", ElementLabel.Above("Default Text"),
                element.DefaultSelectedItem);
            var defaultSelectedItem = new SelectElementViewModel("defaultItem", ElementLabel.Above("Default Item"),
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

        private void AddCheckBoxConfigurationRows(GroupElementViewModel group, CheckElementViewModel element)
        {
            var textField = new TextElementViewModel("contentTextField", ElementLabel.Above("Default Content"),
                element.Content);

            var checkedField = new CheckElementViewModel("checkbox", ElementLabel.Above("Default Value"),
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

        private void AddElementConfigurationRows(GroupElementViewModel group, FormElementViewModel formElement)
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
            var group = FormBuilder.NewGroup("Element Editor", "Element Editor");

            group.AddRows("Default", 1).AddColumns("Element Name", 1, _elementNameTextBox);
            group.AddRows("Default", 1).AddColumns("Element Label", 1, _elementLabelTextBox);
            group.AddRows("Default", 1).AddColumns("Element Type", 1, _elementTypeComboBox);

            _elementNameTextBox.Content = FormElement.Name;
            _elementLabelTextBox.Content = FormElement.Label.Text;
            _elementTypeComboBox.SelectedItem = ElementTypeToFriendlyName(FormElement?.ElementModel?.GetType());


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