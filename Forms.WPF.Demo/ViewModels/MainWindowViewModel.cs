using System.Windows;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;
using Aptacode.Forms.Wpf.ViewModels;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private FormViewModel _formViewModel;

        private readonly Form _myForm;

        public MainWindowViewModel()
        {
            _myForm = new Form("form1", "Test Form",
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

            _myForm.OnFormEvent += NameForm_OnFormEvent;
            FormViewModel = new FormViewModel(_myForm);
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
                System.IO.File.WriteAllText("./results.json", JsonConvert.SerializeObject(formResults, Formatting.Indented));

                MessageBox.Show("Submitted");
            }
            else
            {
                MessageBox.Show(_myForm.GetValidationMessage());
            }
        }
    }
}