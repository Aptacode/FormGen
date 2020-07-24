using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;
using Aptacode.Forms.Shared.Models.Builders;
using Aptacode.Forms.Shared.Models.Builders.Elements.Controls;
using Aptacode.Forms.Shared.Models.Builders.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Builders.Elements.Layouts;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aptacode.Forms.Blazor.Demo.Data
{
    public static class DemoForm
    {
        public static FormViewModel CreateForm()
        {
            var htmlContent = new HtmlElementBuilder().SetName("HtmlContent").SetContent(
                    "<h2 style=\"text-align: center;\"><strong>Demo Form<br /></strong></h2>\r\n<p>Test HTML Content embedded in the demo form</p>\r\n<ul>\r\n<li>FirstName / LastName</li>\r\n<li>Years of experiance</li>\r\n<li>Accept Terms and Conditions</li>\r\n<li>Submit</li>\r\n</ul>")
                .Build();

            var firstNameText = new TextElementBuilder()
                .SetName("First Name")
                .SetLabel(ElementLabel.Left("First Name: "))
                .SetDefaultValue("First Name")
                .AddRules(
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximumLength_Validator(10))
                        .WithFailMessage("First Name must be less then 10 characters"),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))
                        .WithFailMessage("First Name must be greater then 2 characters"))
                .Build();

            var lastNameText = new TextElementBuilder()
                .SetName("Last Name")
                .SetLabel(ElementLabel.Left("Last Name: "))
                .SetDefaultValue("Last Name")
                .AddRules(
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximumLength_Validator(10))
                        .WithFailMessage("Last Name must be less then 10 characters"),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))
                        .WithFailMessage("Last Name must be greater then 2 characters"))
                .Build();

            var personalDetails = new ColumnBuilder().SetName("personalDetails")
                .AddChildren(firstNameText, lastNameText).Build();


            var experienceSelection = new SelectElementBuilder().SetName("experienceSelection")
                .SetLabel(ElementLabel.Left("How many years experience have you got?")).AddValues("0-1", "1-5", "5+")
                .SetDefaultValue("Select a value").Build();
            var termsAndConditions = new CheckElementBuilder().SetName("TermsAndConditions")
                .SetLabel(ElementLabel.Left("Do you accept the terms and conditions?")).SetContent("Yes / No").AddRules(
                    ValidationRule<ICheckElementViewModel>.Create(new CheckElement_IsChecked_Validator())
                        .WithFailMessage("You must accept the terms and conditions")).Build();

            var submitButton = new ButtonElementBuilder().SetName("Submit Button").SetContent("Submit")
                .SetVerticalAlignment(VerticalAlignment.Bottom).Build();

            var submitEventListener = new EventListener("submit",
                new ElementNameEventSpecification("submit").And(
                    new TypeNameEventSpecification(nameof(ButtonElementClickedEvent))),
                new IdentitySpecification<FormViewModel>());

            var rowGroup1 = new RowBuilder().SetName("Data Entry Rows")
                .AddChildren(htmlContent, personalDetails, experienceSelection, termsAndConditions).Build();

            var rootGroup = new GroupBuilder().SetName("Test Group 1").SetTitle("Demo Form Title")
                .AddChildren(rowGroup1, submitButton).Build();

            var newForm = new FormBuilder().SetName("Demo Form").SetTitle("Demo Form Title").SetRoot(rootGroup)
                .AddEventListeners(submitEventListener)
                .Build();

            return new FormViewModel(newForm);
        }
    }
}
