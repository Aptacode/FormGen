using System.IO;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Layout;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public class FormIO
    {
        public static Form ProgrammaticForm()
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

        public static void SaveForm(string filename, Form form)
        {
            File.WriteAllText(filename, form.ToJson());
        }

        public static Form LoadForm(string filename)
        {
            var jsonString = File.ReadAllText(filename);
            return Form.FromJson(jsonString);
        }
    }
}