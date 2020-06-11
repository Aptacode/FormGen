using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Layout;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public static class FormIO
    {
        public static FormViewModel CreateForm()
        {
            var newForm = FormBuilder.CreateForm("New Form", "Demo Form");
            var testGroup1 = newForm.AddGroup("Test Group 1", "Test Group 1 Title");

            testGroup1.AddRow("htmlRow", 1).AddColumn("htmlColumn", 1,
                FormBuilder.CreateHtml("htmlContent", ElementLabel.Above("HtmlContent"),
                    "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>"));

            var nameRow = testGroup1.AddRow("nameRow", 1);

            nameRow.AddColumn("firstNameColumn", 1,
                FormBuilder.CreateText("firstName", ElementLabel.Left("First Name: "), "First Name",
                    new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2),
                    new TextFieldLengthValidationRule(EqualityOperator.LessThan, 10)));

            nameRow.AddColumn("lastNameColumn", 1,
                FormBuilder.CreateText("lastName", ElementLabel.Left("Last Name: "), "Last Name",
                    new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2),
                    new TextFieldLengthValidationRule(EqualityOperator.LessThan, 10)));

            testGroup1.AddRow("CheckBox", 1).AddColumn("CheckBox", 1,
                FormBuilder.CreateCheckBox("CheckBox", ElementLabel.Above("Do you accept the terms and conditions"),
                    "I Agree", false));

            testGroup1.AddRow("comboBox", 1).AddColumn("comboBox", 1,
                FormBuilder.CreateComboBox("comboBox", ElementLabel.Above("How many years experiance have you got?"),
                    new[] {"0-1", "1-5", "5+"}, "0-1"));
            testGroup1.AddRow("submit", 1)
                .AddColumn("submit", 1, FormBuilder.CreateButton("submit", ElementLabel.None, "Submit"));
            return newForm;
        }

        public static FormModel ProgrammaticForm()
        {
            return new FormModel("form1", "Test Form",
                new[]
                {
                    new FormGroupModel("Test Form Group", "Label", new[]
                    {
                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel("Column1", 1,
                                new HtmlElementModel("Paragraph", ElementLabel.Above("Some HTML Content"),
                                    "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>"
                                ))
                        }),
                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel("Default", 1,
                                new TextFieldModel("firstName", ElementLabel.Left("First Name"), "First Name",
                                    new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2))
                            ),
                            new FormColumnModel("", 1,
                                new TextFieldModel("lastName", ElementLabel.Left("Last Name"), "Last Name",
                                    new TextFieldLengthValidationRule(
                                        EqualityOperator.LessThan | EqualityOperator.EqualTo, 10))
                            )
                        }),
                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel("", 1,
                                new CheckBoxFieldModel("receiveEmail",
                                    ElementLabel.Above("Do you accept the terms and conditions"),
                                    "I Agree", false)
                            )
                        }),
                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel("Default", 1,
                                new ComboBoxFieldModel("yearsOfExperience",
                                    ElementLabel.Above("How many years experiance have you got?"),
                                    new[] {"0-1", "1-5", "5+"}, "0-1")
                            )
                        }),
                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel("Default", 1,
                                new ButtonElementModel("SubmitButton", ElementLabel.None,
                                    "Submit")
                            )
                        })
                    })
                });
        }

        //public static void SaveForm(string filename, FormModel form)
        //{
        //   // File.WriteAllText(filename, form.ToJson());
        //}

        //public static FormModel LoadForm(string filename)
        //{
        //    var jsonString = File.ReadAllText(filename);
        //    return FormModel.FromJson(jsonString);
        //}
    }
}