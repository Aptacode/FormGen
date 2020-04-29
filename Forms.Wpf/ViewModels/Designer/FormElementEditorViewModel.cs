using System;
using System.Collections.ObjectModel;
using System.Linq;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Elements.Fields;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Commands;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class FormElementEditorViewModel : BindableBase
    {
        private FormField _elementConfiguration;
        private readonly TextField _elementLabelTextBox;
        private readonly TextField _elementNameTextBox;
        private readonly ComboBoxField _elementTypeComboBox;

        public FormElementEditorViewModel()
        {
            _elementNameTextBox = new TextField("elementNameTextBox", LabelPosition.AboveElement, "Name",
                new ValidationRule<TextField>[]
                {
                });

            _elementLabelTextBox = new TextField("elementLabelTextBox", LabelPosition.AboveElement, "Label",
                new ValidationRule<TextField>[]
                {
                });

            _elementTypeComboBox = new ComboBoxField("elementTypeComboBox", LabelPosition.AboveElement,
                "Type",
                new ValidationRule<ComboBoxField>[]
                {
                    new ComboBoxSelectionRequiredValidationRule()
                }, new[] {"Button", "Html", "CheckBox", "ComboBox", "TextBox"});

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
            var oldElement = FormElement.FormElement;

            if (!(e is ComboBoxFieldChangedEventArgs eventArgs))
            {
                return;
            }

            if (ElementTypeToFriendlyName(FormElement.FormElement.Type) == eventArgs.NewValue)
            {
                return;
            }

            
            switch (eventArgs.NewValue)
            {
                case "Button":
                    FormColumn.FormElementViewModel = new ButtonElementViewModel(new ButtonElement(oldElement.Name, string.Empty,
                        LabelPosition.AboveElement, oldElement.Label));
                    break;
                case "Html":
                    FormColumn.FormElementViewModel = new HtmlElementViewModel(new HtmlElement(oldElement.Name, string.Empty,
                        LabelPosition.AboveElement, oldElement.Label));
                    break;
                case "CheckBox":
                    FormColumn.FormElementViewModel = new CheckBoxFieldViewModel(new CheckBoxField(oldElement.Name,
                        LabelPosition.AboveElement, oldElement.Label, new ValidationRule<CheckBoxField>[0],
                        string.Empty, false));
                    break;
                case "TextBox":
                    FormColumn.FormElementViewModel = new TextFieldViewModel(new TextField(oldElement.Name, LabelPosition.AboveElement,
                        oldElement.Label, new ValidationRule<TextField>[0]));
                    break;
                case "ComboBox":
                    FormColumn.FormElementViewModel = new ComboBoxFieldViewModel(new ComboBoxField(oldElement.Name,
                        LabelPosition.AboveElement, oldElement.Label, new ValidationRule<ComboBoxField>[0],
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
                case nameof(ButtonElement):
                    return "Button";
                case nameof(HtmlElement):
                    return "Html";
                case nameof(CheckBoxField):
                    return "CheckBox";
                case nameof(TextField):
                    return "TextBox";
                case nameof(ComboBoxField):
                    return "ComboBox";
            }

            return string.Empty;
        }

        private void AddButtonConfigurationRows(FormGroup group, ButtonElementViewModel button)
        {
            var textField = new TextField("buttonContentTextBox", LabelPosition.AboveElement, "Content",
                new ValidationRule<TextField>[]
                {
                }, button.Content);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    button.Content = eventArgs.NewContent;
                }
            };

            group.Rows.Add(new FormRow(1, new[]
            {
                new FormColumn(1, textField)
            }));
        }

        private void AddHtmlConfigurationRows(FormGroup group, HtmlElementViewModel element)
        {
            var textField = new TextField("htmlContent", LabelPosition.AboveElement, "Html",
                new ValidationRule<TextField>[]
                {
                }, element.Content);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.Content = eventArgs.NewContent;
                }
            };

            group.Rows.Add(new FormRow(1, new[]
            {
                new FormColumn(1, textField)
            }));
        }

        private void AddTextConfigurationRows(FormGroup group, TextFieldViewModel element)
        {
            var textField = new TextField("htmlContent", LabelPosition.AboveElement, "Content",
                new ValidationRule<TextField>[]
                {
                }, element.DefaultContent);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.DefaultContent = eventArgs.NewContent;
                }
            };

            group.Rows.Add(new FormRow(1, new[]
            {
                new FormColumn(1, textField)
            }));
        }

        private void AddComboBoxConfigurationRows(FormGroup group, ComboBoxFieldViewModel element)
        {
            var optionsField = new TextField("options", LabelPosition.AboveElement, "Options",
                new ValidationRule<TextField>[]
                {
                }, string.Join(",", element.Items));

            optionsField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {

                    element.Items.Clear();
                    element.Items.AddRange(eventArgs.NewContent.Split(',').ToList());
                }
            };

            var textField = new TextField("defaultItem", LabelPosition.AboveElement, "Default Item",
                new ValidationRule<TextField>[]
                {
                }, element.DefaultSelectedItem);

            textField.OnFormEvent += (s, e) =>
            {
                if (e is TextFieldChangedEventArgs eventArgs)
                {
                    element.DefaultSelectedItem = eventArgs.NewContent;
                }
            };

            group.Rows.Add(new FormRow(1, new[]
            {
                new FormColumn(1, optionsField),
                new FormColumn(1, textField)
            }));
        }

        private void AddCheckBoxConfigurationRows(FormGroup group, CheckBoxFieldViewModel element)
        {

            var textField = new TextField("defaultItem", LabelPosition.AboveElement, "Default Item",
                new ValidationRule<TextField>[]
                {
                }, element.Content);

            var checkedField = new CheckBoxField("checkbox", LabelPosition.AboveElement, "Default Value",
                new ValidationRule<CheckBoxField>[]
                {
                }, element.Content, element.DefaultIsChecked);

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

            group.Rows.Add(new FormRow(1, new[]
            {
                new FormColumn(1, textField),
                new FormColumn(1, checkedField)
            }));
        }

        private void AddElementConfigurationRows(FormGroup group, FormElementViewModel formElement)
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
            _elementTypeComboBox.DefaultSelectedItem = ElementTypeToFriendlyName(FormElement.FormElement.Type);

            var group = new FormGroup("Element Editor", new[]
            {
                new FormRow(1, new[]
                {
                    new FormColumn(1, _elementNameTextBox)
                }),

                new FormRow(1, new[]
                {
                    new FormColumn(1, _elementLabelTextBox)
                }),

                new FormRow(1, new[]
                {
                    new FormColumn(1, _elementTypeComboBox)
                })
            });

            AddElementConfigurationRows(group, FormElement);

            var form = new Form("elementEditorForm", "Element Editor",
                new[]
                {
                    group
                });

            FormViewModel = new FormViewModel(form);
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
            set
            {
                SetProperty(ref _formElement, value);
            }
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