using System.IO;
using System.Windows;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;
using Aptacode.Forms.Wpf.ViewModels;
using Aptacode.Forms.Wpf.Views;
using Newtonsoft.Json;
using Prism.Mvvm;
using ButtonElement = Aptacode.Forms.Elements.ButtonElement;
using CheckBoxField = Aptacode.Forms.Elements.Fields.CheckBoxField;
using ComboBoxField = Aptacode.Forms.Elements.Fields.ComboBoxField;
using HtmlElement = Aptacode.Forms.Elements.HtmlElement;
using FormGroup = Aptacode.Forms.Layout.FormGroup;
using FormRow = Aptacode.Forms.Layout.FormRow;
using FormColumn = Aptacode.Forms.Layout.FormColumn;

namespace Aptacode.Forms.Wpf.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly Form _myForm;
        private FormViewModel _formViewModel;
        private readonly string _formFileName = "form.json";
        public MainWindowViewModel()
        {
            _myForm = ProgrammaticForm();
            SaveForm(_formFileName, _myForm);
            var loadedForm = LoadForm(_formFileName);

            _myForm.OnFormEvent += NameForm_OnFormEvent;
            FormViewModel = new FormViewModel(_myForm);
        }

        private void SaveForm(string filename, Form form)
        {
            File.WriteAllText(filename, form.ToJson());
        }

        private Form LoadForm(string filename)
        {
            var jsonString = File.ReadAllText(filename);
            return Form.FromJson(jsonString);
        }

        private Form ProgrammaticForm()
        {
            return new Form("form1", "Test Form",
    new[]
    {
                    new FormGroup("Test Form Group", new[]
                    {
                        new FormRow(1, new[]
                        {
                            new FormColumn(1,
                                new HtmlElement("Paragraph",
                                    "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>",
                                    LabelPosition.AboveElement, "Sample HTML Content"))
                        }),

                        new FormRow(1, new[]
                        {
                            new FormColumn(1,
                                new TextField("firstName", LabelPosition.AboveElement, "First Name",
                                    new ValidationRule<TextField>[]
                                    {
                                        new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2)
                                    })
                            ),
                            new FormColumn(1,
                                new TextField("lastName", LabelPosition.AboveElement, "Last Name",
                                    new ValidationRule<TextField>[]
                                    {
                                        new TextFieldLengthValidationRule(
                                            EqualityOperator.LessThan | EqualityOperator.EqualTo, 10)
                                    })
                            )
                        }),

                        new FormRow(1, new[]
                        {
                            new FormColumn(1,
                                new CheckBoxField("receiveEmail", LabelPosition.AboveElement,
                                    "Do you accept the terms and conditions",
                                    new ValidationRule<CheckBoxField>[]
                                    {
                                        new CheckBoxCheckedValidationRule(true)
                                    }, "I Agree", false)
                            )
                        }),

                        new FormRow(1, new[]
                        {
                            new FormColumn(1,
                                new ComboBoxField("yearsOfExperience", LabelPosition.AboveElement,
                                    "Years of Experience",
                                    new ValidationRule<ComboBoxField>[]
                                    {
                                        new ComboBoxSelectionRequiredValidationRule()
                                    }, new[] {"0-1", "1-5", "5+"})
                            )
                        }),

                        new FormRow(1, new[]
                        {
                            new FormColumn(1,
                                new ButtonElement("SubmitButton",
                                    "Submit", LabelPosition.AboveElement, "")
                            )
                        })
                    })
    });
        }

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        private void NameForm_OnFormEvent(object sender, FormEventArgs e)
        {
            if (!(e is ButtonClickedEventArgs buttonClickedEvent) || buttonClickedEvent.Button.Name != "SubmitButton")
            {
                return;
            }

            Submit();
        }

        private void Submit()
        {
            if (_myForm.IsValid)
            {
                var formResults = _myForm.GetResult();
                File.WriteAllText("./results.json", JsonConvert.SerializeObject(formResults, Formatting.Indented));

                MessageBox.Show("Submitted");
            }
            else
            {
                MessageBox.Show(_myForm.GetValidationMessage());
            }
        }
    }
}