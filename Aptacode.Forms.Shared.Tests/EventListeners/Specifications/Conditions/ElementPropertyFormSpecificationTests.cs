using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.EventListeners.Specifications.Conditions
{
    public class ElementPropertyFormSpecificationTests
    {

        private const string TextElementName = "Test Text Element";
        private const string TextElementValue = "Test Text Value";

        private const string CheckElementName = "Test Check Element";
        private const bool CheckElementValue = true;

        [Theory]
        [InlineData(TextElementName, "Content", TextElementValue, true)]
        [InlineData(CheckElementName, "IsChecked", CheckElementValue, true)]
        [InlineData(CheckElementName, "IsChecked", !CheckElementValue, false)]

        [InlineData(TextElementName, "Content", "IncorrectValue", false)]
        [InlineData("IncorrectElementName", "Content", TextElementValue, false)]
        [InlineData(TextElementName, "IncorrectPropertyName", TextElementValue, false)]

        public void IsSatisfiedBy(string elementName, string propertyName, object propertyValue, bool expectedResult)
        {

            //Arrange
            var sut = new ElementPropertyFormSpecification(elementName, propertyName, propertyValue);
            var testForm = FormBuilder.CreateForm("Test Form Name", "Test Form Title");
            var rootElement = FormBuilder.NewGroup("Test Group", "Test Group Title")
                .AddText(TextElementName, ElementLabel.None, TextElementValue)
                .AddCheck(CheckElementName, ElementLabel.None, "Test Check Content", CheckElementValue);

            testForm.SetRoot(rootElement);

            //Act
            var result = sut.IsSatisfiedBy(testForm);

            //Assert
            Assert.Equal(expectedResult, result);
        }

    }
}
