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
        private TextField _elementNameTextBox;
        private TextField _elementLabelTextBox;
        private ComboBoxField _elementTypeComboBox;
        private ButtonElement _saveElementButton;

        private FormField _elementConfiguration;
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

            _saveElementButton = new ButtonElement("SaveButton",
                "Save", LabelPosition.AboveElement, "");

            _elementTypeComboBox.OnFormEvent += ElementTypeComboBoxOnOnFormEvent;
            _saveElementButton.OnFormEvent += SaveElementButtonOnOnFormEvent;

        }

        private void SaveElementButtonOnOnFormEvent(object sender, FormElementEvent e)
        {
            if (e is ButtonClickedEventArgs eventArgs)
            {
                FormElement.FormElement.Name = _elementNameTextBox.Content;
                FormElement.Label = _elementLabelTextBox.Content;
            }
        }

        private void ElementTypeComboBoxOnOnFormEvent(object sender, FormElementEvent e)
        {

            var oldElement = FormElement.FormElement;
            
            if (e is ComboBoxFieldChangedEventArgs eventArgs)
            {
                if (ElementTypeToFriendlyName(FormElement.FormElement.Type) == eventArgs.NewValue)
                    return;

                FormElementViewModel newElement = null;
                switch (eventArgs.NewValue)
                {
                    case "Button":
                        newElement = new ButtonElementViewModel(new ButtonElement(oldElement.Name, string.Empty,
                            LabelPosition.AboveElement, oldElement.Label));
                        break;
                    case "Html":
                        newElement = new HtmlElementViewModel(new HtmlElement(oldElement.Name, string.Empty,
                            LabelPosition.AboveElement, oldElement.Label));
                        break;
                    case "CheckBox":
                        newElement = new CheckBoxFieldViewModel(new CheckBoxField(oldElement.Name, LabelPosition.AboveElement, oldElement.Label, new ValidationRule<CheckBoxField>[0], string.Empty, false));
                        break;
                    case "TextBox":
                        newElement = new TextFieldViewModel(new TextField(oldElement.Name, LabelPosition.AboveElement, oldElement.Label, new ValidationRule<TextField>[0]));
                        break;
                    case "ComboBox":
                        newElement = new ComboBoxFieldViewModel(new ComboBoxField(oldElement.Name, LabelPosition.AboveElement, oldElement.Label, new ValidationRule<ComboBoxField>[0], new string[0], string.Empty));
                        break;
                    default:
                        newElement = null;
                        break;
                }

                Load(newElement);

            }
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

        private void AddElementConfigurationRows(FormGroup group, FormElementViewModel formElement)
        {
            switch (formElement.FormElement)
            {
                case ButtonElement buttonElement:
                    group.Rows.Add(new FormRow(1, new[]
                    {
                        new FormColumn(1,new TextField("elementNameTextBox", LabelPosition.AboveElement, "Content",
                            new ValidationRule<TextField>[]
                            {
                            }, buttonElement.Content))
                    }));
                    break;
                case HtmlElement htmlElement:
                    group.Rows.Add(new FormRow(1, new[]
                    {
                        new FormColumn(1,new TextField("elementNameTextBox", LabelPosition.AboveElement, "Html",
                            new ValidationRule<TextField>[]
                            {
                            },htmlElement.Content))
                    }));
                    break;
                case CheckBoxField checkBox:
                    group.Rows.Add(new FormRow(1, new[]
                    {
                        new FormColumn(1,new TextField("elementNameTextBox", LabelPosition.AboveElement, "Content",
                            new ValidationRule<TextField>[]
                            {
                            }))
                    }));
                    group.Rows.Add(new FormRow(1, new[]
                    {
                        new FormColumn(1,new CheckBoxField("checkbox", LabelPosition.AboveElement, "Default Value",
                            new ValidationRule<CheckBoxField>[]
                            {
                            }, checkBox.Content, checkBox.DefaultIsChecked))
                    }));
                    break;
                case TextField textField:
                    group.Rows.Add(new FormRow(1, new[]
                    {
                        new FormColumn(1,new TextField("elementNameTextBox", LabelPosition.AboveElement, "Content",
                            new ValidationRule<TextField>[]
                            {
                            }, textField.DefaultContent))
                    }));
                    break;
                case ComboBoxField comboBox:
                    group.Rows.Add(new FormRow(1, new[]
                    {
                        new FormColumn(1,new TextField("elementNameTextBox", LabelPosition.AboveElement, "Default Value",
                            new ValidationRule<TextField>[]
                            {
                            }, comboBox.DefaultSelectedItem))
                    }));
                    break;
            }
        }


        public void Load(FormElementViewModel formElement)
        {
            FormViewModel = null;

            if (formElement == null)
            {
                return;
            }

            _elementNameTextBox.DefaultContent = formElement.Label;
            _elementLabelTextBox.DefaultContent = formElement.Label;
            _elementTypeComboBox.DefaultSelectedItem = ElementTypeToFriendlyName(formElement.FormElement.Type);
            FormElement = formElement;

            var group = new FormGroup("Element Editor", new[]
            {

                new FormRow(1, new[]
                {
                    new FormColumn(1,_elementNameTextBox)
                }),

                new FormRow(1, new[]
                {
                    new FormColumn(1, _elementLabelTextBox)
                }),

                new FormRow(1, new[]
                {
                    new FormColumn(1,_elementTypeComboBox)
                })
            });

            AddElementConfigurationRows(group, formElement);

            group.Rows.Add(new FormRow(1, new[]
            {
                new FormColumn(1,_saveElementButton)
            }));

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

        #region Commands

        private DelegateCommand _removeCommand;

        public DelegateCommand RemoveCommand =>
            _removeCommand ?? (_removeCommand = new DelegateCommand(async () => { }));


        private DelegateCommand _updateCommand;

        public DelegateCommand UpdateCommand =>
            _updateCommand ?? (_updateCommand = new DelegateCommand(() => { }));

        #endregion
    }
}