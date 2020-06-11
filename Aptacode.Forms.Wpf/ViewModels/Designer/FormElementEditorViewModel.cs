using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Events;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
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
            _elementNameTextBox = new TextFieldViewModel(new TextFieldModel("elementNameTextBox",
                LabelPosition.AboveElement, "Name", new List<ValidationRule<ITextFieldViewModel>>()));

            _elementLabelTextBox = new TextFieldViewModel(new TextFieldModel("elementLabelTextBox",
                LabelPosition.AboveElement, "Label", new List<ValidationRule<ITextFieldViewModel>>()));

            _elementTypeComboBox = new ComboBoxFieldViewModel(new ComboBoxFieldModel("elementTypeComboBox",
                LabelPosition.AboveElement,
                "Type",
                new[]
                {
                    new ComboBoxSelectionRequiredValidationRule()
                }, new[] {"Button", "Html", "CheckBox", "ComboBox", "TextBox"}));

            _elementTypeComboBox.OnFormEvent += ElementTypeComboBoxOnOnFormEvent;
            _elementNameTextBox.OnFormEvent += ElementNameTextBoxOnOnFormEvent;
            _elementLabelTextBox.OnFormEvent += ElementLabelTextBoxOnOnFormEvent;
        }

        private void ElementLabelTextBoxOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is TextFieldChangedEventArgs eventArgs)
            {
                FormElement.Label = eventArgs.NewContent;
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

            if (ElementTypeToFriendlyName(FormElement?.ElementModel?.Type) == eventArgs.NewValue)
            {
                return;
            }


            switch (eventArgs.NewValue)
            {
                case "Button":
                    FormColumn.FormElementViewModel = new ButtonElementViewModel(new ButtonElementModel(oldElement.Name,
                        string.Empty,
                        LabelPosition.AboveElement, oldElement.Label));
                    break;
                case "Html":
                    FormColumn.FormElementViewModel = new HtmlElementViewModel(new HtmlElementModel(oldElement.Name,
                        string.Empty,
                        LabelPosition.AboveElement, oldElement.Label));
                    break;
                case "CheckBox":
                    FormColumn.FormElementViewModel = new CheckBoxFieldViewModel(new CheckBoxFieldModel(oldElement.Name,
                        LabelPosition.AboveElement, oldElement.Label, new ValidationRule<ICheckBoxFieldViewModel>[0],
                        string.Empty, false));
                    break;
                case "TextBox":
                    FormColumn.FormElementViewModel = new TextFieldViewModel(new TextFieldModel(oldElement.Name,
                        LabelPosition.AboveElement,
                        oldElement.Label, new ValidationRule<ITextFieldViewModel>[0]));
                    break;
                case "ComboBox":
                    FormColumn.FormElementViewModel = new ComboBoxFieldViewModel(new ComboBoxFieldModel(oldElement.Name,
                        LabelPosition.AboveElement, oldElement.Label, new ValidationRule<IComboBoxFieldViewModel>[0],
                        new string[0], string.Empty));
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
            var textField = new TextFieldViewModel(new TextFieldModel("buttonContentTextBox",
                LabelPosition.AboveElement, "Content", new List<ValidationRule<ITextFieldViewModel>>(),
                button.Content));

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    button.Content = eventArgs.NewContent;
                }
            };

            group.AddRow("Default", 1).AddColumn(1, textField);
        }

        private void AddHtmlConfigurationRows(FormGroupViewModel group, HtmlElementViewModel element)
        {
            var buttonField =
                new ButtonElementViewModel(new ButtonElementModel("editHtml", "Edit", LabelPosition.AboveElement, ""));

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

            group.AddRow("Default", 1).AddColumn(1, buttonField);
        }

        private void AddTextConfigurationRows(FormGroupViewModel group, TextFieldViewModel element)
        {
            var textField = new TextFieldViewModel(new TextFieldModel("htmlContent", LabelPosition.AboveElement,
                "Content", new List<ValidationRule<ITextFieldViewModel>>(), element.DefaultContent));

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.DefaultContent = eventArgs.NewContent;
                }
            };

            group.AddRow("Default", 1).AddColumn(1, textField);
        }

        private void AddComboBoxConfigurationRows(FormGroupViewModel group, ComboBoxFieldViewModel element)
        {
            var optionsField = new TextFieldViewModel(new TextFieldModel("options", LabelPosition.AboveElement,
                "Options", new List<ValidationRule<ITextFieldViewModel>>(), string.Join(",", element.Items)));

            optionsField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.Items.Clear();
                    element.Items.AddRange(eventArgs.NewContent.Split(',').ToList());
                }
            };

            var textField = new TextFieldViewModel(new TextFieldModel("defaultItem", LabelPosition.AboveElement,
                "Default Item", new List<ValidationRule<ITextFieldViewModel>>(), element.DefaultSelectedItem));

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.DefaultSelectedItem = eventArgs.NewContent;
                }
            };

            var newRow = group.AddRow("Default", 1);

            newRow.AddColumn(1, optionsField);
            newRow.AddColumn(1, textField);
        }

        private void AddCheckBoxConfigurationRows(FormGroupViewModel group, CheckBoxFieldViewModel element)
        {
            var textField = new TextFieldViewModel(new TextFieldModel("defaultItem", LabelPosition.AboveElement,
                "Default Item", new List<ValidationRule<ITextFieldViewModel>>(), element.Content));

            var checkedField = new CheckBoxFieldViewModel(new CheckBoxFieldModel("checkbox", LabelPosition.AboveElement,
                "Default Value", new List<ValidationRule<ICheckBoxFieldViewModel>>(), element.Content,
                element.DefaultIsChecked));

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

            newRow.AddColumn(1, textField);
            newRow.AddColumn(1, checkedField);
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
            _elementLabelTextBox.DefaultContent = FormElement.Label;
            _elementTypeComboBox.DefaultSelectedItem = ElementTypeToFriendlyName(FormElement?.ElementModel?.Type);

            var form = FormBuilder.CreateForm("elementEditorForm", "Element Editor");
            var group = form.AddGroup("Element Editor");

            group.AddRow("Default", 1).AddColumn(1, _elementNameTextBox);
            group.AddRow("Default", 1).AddColumn(1, _elementLabelTextBox);
            group.AddRow("Default", 1).AddColumn(1, _elementTypeComboBox);

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