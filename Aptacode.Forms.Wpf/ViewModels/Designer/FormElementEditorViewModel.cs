using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Events;
using Aptacode.Forms.Shared.ViewModels.Layout;
using Aptacode.Forms.Wpf.Views.Designer;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementEditorViewModel : BindableBase
    {
        private readonly TextFieldViewModel _elementLabelTextBox;
        private readonly TextFieldViewModel _elementNameTextBox;
        private readonly ComboBoxFieldViewModel _elementTypeComboBox;

        public FormElementEditorViewModel()
        {
            _elementNameTextBox = new TextFieldViewModel("elementNameTextBox",
                ElementLabel.Above("Name"), "Name");

            _elementLabelTextBox = new TextFieldViewModel("elementLabelTextBox", ElementLabel.Above("Label"), "Label");

            _elementTypeComboBox = new ComboBoxFieldViewModel("elementTypeComboBox", ElementLabel.Above("Type"),
                new List<string> {"Button", "Html", "CheckBox", "ComboBox", "TextBox"}, "TextBox");

            _elementTypeComboBox.OnFormEvent += ElementTypeComboBoxOnOnFormEvent;
            _elementNameTextBox.OnFormEvent += ElementNameTextBoxOnOnFormEvent;
            _elementLabelTextBox.OnFormEvent += ElementLabelTextBoxOnOnFormEvent;
        }

        private void ElementLabelTextBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is TextFieldChangedEventArgs eventArgs)
            {
                FormElement.Label = new ElementLabel(FormElement.Label.Position, eventArgs.NewContent);
            }
        }

        private void ElementNameTextBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is TextFieldChangedEventArgs eventArgs)
            {
                FormElement.Name = eventArgs.NewContent;
            }
        }

        private void ElementTypeComboBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            var oldElement = FormElement;

            if (!(e is ComboBoxFieldChangedEventArgs eventArgs))
            {
                return;
            }

            if (ElementTypeToFriendlyName(FormElement?.ElementModel?.ElementType) == eventArgs.NewValue)
            {
                return;
            }


            switch (eventArgs.NewValue)
            {
                case "Button":
                    FormColumn.FormElementViewModel = new ButtonElementViewModel(oldElement.Name, oldElement.Label, "");
                    break;
                case "Html":
                    FormColumn.FormElementViewModel =
                        new HtmlElementViewModel(oldElement.Name, oldElement.Label, string.Empty);
                    break;
                case "CheckBox":
                    FormColumn.FormElementViewModel =
                        new CheckBoxFieldViewModel(oldElement.Name, oldElement.Label, string.Empty, false);
                    break;
                case "TextBox":
                    FormColumn.FormElementViewModel = new TextFieldViewModel(oldElement.Name, oldElement.Label, "");
                    break;
                case "ComboBox":
                    FormColumn.FormElementViewModel = new ComboBoxFieldViewModel(oldElement.Name, oldElement.Label,
                        new string[0], string.Empty);
                    break;
                default:
                    FormColumn.FormElementViewModel = null;
                    break;
            }

            Load();
        }

        #region Methods

        private string ElementTypeToFriendlyName(string elementType)
        {
            switch (elementType)
            {
                case nameof(ButtonElementModel):
                    return "Button";
                case nameof(HtmlElementModel):
                    return "Html";
                case nameof(CheckBoxFieldModel):
                    return "CheckBox";
                case nameof(TextFieldModel):
                    return "TextBox";
                case nameof(ComboBoxFieldModel):
                    return "ComboBox";
            }

            return string.Empty;
        }

        private void AddButtonConfigurationRows(FormGroupViewModel group, ButtonElementViewModel button)
        {
            var textField =
                new TextFieldViewModel("buttonContentTextBox", ElementLabel.Above("Content"), button.Content);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    button.Content = eventArgs.NewContent;
                }
            };

            group.AddRow("Default", 1).AddColumn("buttonContentTextBox", 1, textField);
        }

        private void AddHtmlConfigurationRows(FormGroupViewModel group, HtmlElementViewModel element)
        {
            var buttonField =
                new ButtonElementViewModel("editHtml", ElementLabel.Above("Edit"), "Edit");

            buttonField.OnFormEvent += (s, e) =>
            {
                if (e is ButtonClickedEventArgs eventArgs)
                {
                    var htmlEditor = new HtmlEditorDialog(element.Content);
                    htmlEditor.ShowDialog();

                    element.Content = htmlEditor.ViewModel.Content;
                    Load();
                }
            };

            group.AddRow("Default", 1).AddColumn("editHtml", 1, buttonField);
        }

        private void AddTextConfigurationRows(FormGroupViewModel group, TextFieldViewModel element)
        {
            var textField =
                new TextFieldViewModel("htmlContent", ElementLabel.Above("Content"), element.DefaultContent);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.DefaultContent = eventArgs.NewContent;
                }
            };

            group.AddRow("Default", 1).AddColumn("htmlContent", 1, textField);
        }

        private void AddComboBoxConfigurationRows(FormGroupViewModel group, ComboBoxFieldViewModel element)
        {
            var optionsField = new TextFieldViewModel("options", ElementLabel.Above("Options"),
                string.Join(",", element.Items));

            optionsField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.Items.Clear();
                    element.Items.AddRange(eventArgs.NewContent.Split(',').ToList());
                }
            };

            var textField = new TextFieldViewModel("defaultItem", ElementLabel.Above("Default Item"),
                element.DefaultSelectedItem);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.DefaultSelectedItem = eventArgs.NewContent;
                }
            };

            var newRow = group.AddRow("Default", 1);

            newRow.AddColumn("options", 1, optionsField);
            newRow.AddColumn("selectedOption", 1, textField);
        }

        private void AddCheckBoxConfigurationRows(FormGroupViewModel group, CheckBoxFieldViewModel element)
        {
            var textField = new TextFieldViewModel("defaultItem", ElementLabel.Above("Default Item"), element.Content);

            var checkedField = new CheckBoxFieldViewModel("checkbox", ElementLabel.Above("Default Value"),
                element.Content, element.DefaultIsChecked);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.Content = eventArgs.NewContent;
                }
            };

            checkedField.OnFormEvent += (s, e) =>
            {
                if (e is CheckBoxFieldChangedEventArgs eventArgs)
                {
                    element.DefaultIsChecked = eventArgs.NewValue;
                }
            };


            var newRow = group.AddRow("Default", 1);

            newRow.AddColumn("defaultItem", 1, textField);
            newRow.AddColumn("checkbox", 1, checkedField);
        }

        private void AddElementConfigurationRows(FormGroupViewModel group, FormElementViewModel formElement)
        {
            switch (formElement)
            {
                case ButtonElementViewModel buttonElement:
                    AddButtonConfigurationRows(group, buttonElement);
                    break;
                case HtmlElementViewModel htmlElement:
                    AddHtmlConfigurationRows(group, htmlElement);
                    break;
                case CheckBoxFieldViewModel checkBox:
                    AddCheckBoxConfigurationRows(group, checkBox);
                    break;
                case TextFieldViewModel textField:
                    AddTextConfigurationRows(group, textField);
                    break;
                case ComboBoxFieldViewModel comboBox:
                    AddComboBoxConfigurationRows(group, comboBox);
                    break;
            }
        }

        public void Clear()
        {
            FormViewModel = null;
        }

        public void Load()
        {
            Clear();

            FormElement = FormColumn?.FormElementViewModel;

            if (FormElement == null)
            {
                return;
            }

            _elementNameTextBox.DefaultContent = FormElement.Name;
            _elementLabelTextBox.DefaultContent = FormElement.Label.Text;
            _elementTypeComboBox.DefaultSelectedItem =
                ElementTypeToFriendlyName(FormElement?.ElementModel?.ElementType);

            var form = FormBuilder.CreateForm("Element Editor Form", "Element Editor Form");
            var group = form.AddGroup("Element Editor", "Element Editor");

            group.AddRow("Default", 1).AddColumn("Element Name", 1, _elementNameTextBox);
            group.AddRow("Default", 1).AddColumn("Element Label", 1, _elementLabelTextBox);
            group.AddRow("Default", 1).AddColumn("Element Type", 1, _elementTypeComboBox);

            AddElementConfigurationRows(group, FormElement);

            FormViewModel = form;
        }

        #endregion

        #region Events

        public EventHandler<FormElementViewModel> OnSelected { get; set; }
        public EventHandler<FormElementViewModel> OnRemoved { get; set; }
        public EventHandler<FormElementViewModel> OnCreated { get; set; }

        #endregion

        #region Properties

        private FormColumnViewModel _formColumn;

        public FormColumnViewModel FormColumn
        {
            get => _formColumn;
            set
            {
                SetProperty(ref _formColumn, value);
                Load();
            }
        }

        private FormElementViewModel _formElement;

        public FormElementViewModel FormElement
        {
            get => _formElement;
            set => SetProperty(ref _formElement, value);
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