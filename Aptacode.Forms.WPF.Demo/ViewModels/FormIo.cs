using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public static class FormIO
    {
        public static FormViewModel CreateForm()
        {
            var newForm = FormBuilder.CreateForm("New Form", "Demo Form");

            var testGroup1 = FormBuilder.NewGroup("Test Group 1", "Test Group 1 Title");

            testGroup1.AddRows("htmlRow", 1).AddColumns("htmlColumn", 1,
                FormBuilder.CreateHtml("htmlContent", ElementLabel.Above("HtmlContent"),
                    "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>"));

            var nameRow = testGroup1.AddRows("nameRow", 1);

            nameRow.AddColumns("firstNameColumn", 1,
                FormBuilder.CreateText("First Name", ElementLabel.Left("First Name: "), "First Name",
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximunLength_Validator(10)).WithFailMessage("First Name must be less then 10 characters"),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2)).WithFailMessage("First Name must be greater then 2 characters")));

            nameRow.AddColumns("lastNameColumn", 1,
                FormBuilder.CreateText("Last Name", ElementLabel.Left("Last Name: "), "Last Name",
                         ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximunLength_Validator(10)),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))));

            testGroup1.AddRows("CheckBox", 1).AddColumns("CheckBox", 1,
                FormBuilder.CreateCheck("CheckBox", ElementLabel.Above("Do you accept the terms and conditions"),
                    "I Agree", false));

            testGroup1.AddRows("comboBox", 1).AddColumns("comboBox", 1,
                FormBuilder.CreateSelect("experienceSelection",
                    ElementLabel.Above("How many years experience have you got?"),
                    new[] {"0-1", "1-5", "5+"}, "0-1"));
            testGroup1.AddRows("submit", 1)
                .AddColumns("submit", 1, FormBuilder.CreateButton("submit", ElementLabel.None, "Submit"));

            newForm.RootElement = testGroup1;

            newForm.EventListeners.Add(new EventListener("submit",
                new ElementNameEventSpecification("submit").And(
                    new TypeNameEventSpecification(nameof(ButtonElementClickedEvent))),
                new IdentitySpecification<FormViewModel>()));

            return newForm;
        }

        public static Form ProgrammaticForm()
        {
            var rootGroup = FormBuilder.NewGroup("Test Form Group", "Label", new RowElement("Default", 1,
                new ColumnElement("Column1", 1,
                    new HtmlElement("Paragraph", ElementLabel.Above("Some HTML Content"),
                        "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>"
                    ))), new RowElement("Default", 1, new ColumnElement("Default", 1,
                new TextElement("firstName", ElementLabel.Left("First Name"), "First Name",
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximunLength_Validator(10)),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2)))
            ), new ColumnElement("", 1,
                new TextElement("lastName", ElementLabel.Left("Last Name"), "Last Name")
            )), new RowElement("Default", 1, new ColumnElement("", 1,
                new CheckElement("receiveEmail",
                    ElementLabel.Above("Do you accept the terms and conditions"),
                    "I Agree", false)
            )), new RowElement("Default", 1, new ColumnElement("Default", 1,
                new SelectElement("yearsOfExperience",
                    ElementLabel.Above("How many years experiance have you got?"),
                    new[] {"0-1", "1-5", "5+"}, "0-1")
            )), new RowElement("Default", 1, new ColumnElement("Default", 1,
                new ButtonElement("SubmitButton", ElementLabel.None,
                    "Submit")
            )));
            return new Form("form1", "Test Form", rootGroup.Model);
        }
    }
}