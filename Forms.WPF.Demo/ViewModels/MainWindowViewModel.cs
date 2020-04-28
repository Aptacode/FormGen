using System.IO;
using System.Windows;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels;
using Aptacode.Forms.Wpf.ViewModels.Designer;
using Newtonsoft.Json;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly string _formFileName = "form.json";
        private readonly Form _myForm;
        private FormDesignerViewModel _formDesignerViewModel;
        private FormViewModel _formViewModel;


        public MainWindowViewModel()
        {
            //Generate the form programmatically
            var programmaticForm = ProgrammaticForm();
            //Save the form as a json file
            SaveForm(_formFileName, programmaticForm);
            //Generate the form from a json file
            _myForm = LoadForm(_formFileName);

            _myForm.OnFormEvent += NameForm_OnFormEvent;
            FormViewModel = new FormViewModel(_myForm);

            FormDesignerViewModel = new FormDesignerViewModel();
            FormDesignerViewModel.Load(FormViewModel);
        }

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        public FormDesignerViewModel FormDesignerViewModel
        {
            get => _formDesignerViewModel;
            set => SetProperty(ref _formDesignerViewModel, value);
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