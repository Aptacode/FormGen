using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields.Results;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Events;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Demo.Pages
{
    public class IndexBase : ComponentBase
    {
        public FormViewModel FormModel { get; set; }
        public List<FormEventArgs> FormEventLog { get; set; }

        public IEnumerable<FormEventArgs> GetRecentEvents() => FormEventLog.TakeLast(10).Reverse();

        protected override Task OnInitializedAsync()
        {
            FormEventLog = new List<FormEventArgs>();
            FormModel = CreateForm();
            FormModel.Setup();

            FormModel.OnFormEvent += (s, e) =>
            {
                FormEventLog.Add(e);
                InvokeAsync(StateHasChanged);
            };

            return Task.CompletedTask;
        }

        public FormViewModel CreateForm()
        {
            var newForm = FormBuilder.CreateForm("New Form", "Demo Form");
            var testGroup1 = newForm.AddGroup("Test Group 1", "Test Group 1 Title");

            testGroup1.AddRow("htmlRow", 1).AddColumn("htmlColumn", 1, FormBuilder.CreateHtml("htmlContent", ElementLabel.Above("HtmlContent"), "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>"));

            var nameRow = testGroup1.AddRow("nameRow", 1);

            nameRow.AddColumn("firstNameColumn", 1,
                FormBuilder.CreateText("firstName", ElementLabel.Left("First Name: "), "First Name", new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2), new TextFieldLengthValidationRule(EqualityOperator.LessThan, 10)));

            nameRow.AddColumn("lastNameColumn", 1,
                FormBuilder.CreateText("lastName", ElementLabel.Left("Last Name: "), "Last Name", new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2), new TextFieldLengthValidationRule(EqualityOperator.LessThan, 10)));

            testGroup1.AddRow("CheckBox", 1).AddColumn("CheckBox", 1, FormBuilder.CreateCheckBox("CheckBox", ElementLabel.Above("Do you accept the terms and conditions"), "I Agree", false));

            testGroup1.AddRow("comboBox", 1).AddColumn("comboBox", 1, FormBuilder.CreateComboBox("comboBox", ElementLabel.Above("How many years experiance have you got?"), new[] { "0-1", "1-5", "5+" }, "0-1"));

            testGroup1.AddRow("submit", 1).AddColumn("submit", 1, FormBuilder.CreateButton("submit", ElementLabel.None, "Submit"));


            newForm.OnFormEvent += NewForm_OnFormEvent;

            return newForm;
        }

        private void NewForm_OnFormEvent(object sender, FormEventArgs e)
        {
            if (sender is ButtonElementViewModel button && button.Name == "submit" && e is ButtonClickedEventArgs buttonClickedEventArgs)
            {
                var validationResults = FormModel.GetValidationResults();
                var formResult = FormModel.GetResult();
                var firstNameResult = formResult.Get<TextFieldResult>("firstName");
                var textResults = formResult.GetAll<TextFieldResult>();

            }
        }
    }
}
