using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.Event;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Demo.Pages
{
    public class IndexBase : ComponentBase
    {
        public FormViewModel FormModel { get; set; }
        public List<FormElementEvent> FormEventLog { get; set; }

        public IEnumerable<FormElementEvent> GetRecentEvents() => FormEventLog.TakeLast(10).Reverse();

        protected override Task OnInitializedAsync()
        {
            FormEventLog = new List<FormElementEvent>();
            FormModel = CreateForm();
            FormModel.EventListeners.Add(new EventListener("validationTrigger", new EventTypeSpecification(nameof(ValidationChangedEvent)),new IdentitySpecification<FormViewModel>()));
            FormModel.OnTriggered += FormModelOnOnTriggered;
            return Task.CompletedTask;
        }

        private void FormModelOnOnTriggered(object? sender, (EventListener, FormElementEvent) e)
        {
            FormEventLog.Add(e.Item2);
            InvokeAsync(StateHasChanged);
        }

        public FormViewModel CreateForm()
        {
            var newForm = FormBuilder.CreateForm("New Form", "Demo Form");

            var testGroup1 = FormBuilder.NewGroup("Test Group 1", "Test Group 1 Title");

            testGroup1.AddRows("htmlRow", 1).AddColumns("htmlColumn", 1,
                FormBuilder.CreateHtml("htmlContent", ElementLabel.Above("HtmlContent"),
                    "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>"));

            var nameRow = testGroup1.AddRows("nameRow", 1);

            nameRow.AddColumns("firstNameColumn", 1,
                FormBuilder.CreateText("firstName", ElementLabel.Left("First Name: "), "First Name",
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximunLength_Validator(10)),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))));

            nameRow.AddColumns("lastNameColumn", 1,
                FormBuilder.CreateText("lastName", ElementLabel.Left("Last Name: "), "Last Name",
                      ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximunLength_Validator(10)),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))));

            testGroup1.AddRows("CheckBox", 1).AddColumns("CheckBox", 1,
                FormBuilder.CreateCheckBox("CheckBox", ElementLabel.Above("Do you accept the terms and conditions"),
                    "I Agree", false));

            testGroup1.AddRows("comboBox", 1).AddColumns("comboBox", 1,
                FormBuilder.CreateComboBox("experienceSelection", ElementLabel.Above("How many years experience have you got?"),
                    new[] { "0-1", "1-5", "5+" }, "0-1"));
            testGroup1.AddRows("submit", 1)
                .AddColumns("submit", 1, FormBuilder.CreateButton("submit", ElementLabel.None, "Submit"));

            newForm.RootElement = testGroup1;
            return newForm;
        }

   
    }
}
