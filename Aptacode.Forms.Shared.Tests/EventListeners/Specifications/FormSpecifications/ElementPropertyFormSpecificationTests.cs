using Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications;
using Aptacode.Forms.Shared.Models.Builders;
using Aptacode.Forms.Shared.Models.Builders.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Builders.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.EventListeners.Specifications.FormSpecifications
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
            var testForm = new FormBuilder().SetName("Test Form Name").SetTitle("Test Form Title").SetRoot(
                new RowBuilder().SetName("Test Group").AddChildren(
                        new TextElementBuilder().SetName(TextElementName).SetDefaultValue(TextElementValue).Build(),
                        new CheckElementBuilder().SetName(CheckElementName).SetDefaultValue(CheckElementValue).Build())
                    .Build()
            ).Build();
            var testFormVm = new FormViewModel(testForm);
            //Act
            var result = sut.IsSatisfiedBy(testFormVm);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}