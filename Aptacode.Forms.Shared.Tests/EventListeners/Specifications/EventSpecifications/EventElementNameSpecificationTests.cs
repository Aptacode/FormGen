using System;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.EventListeners.Specifications.EventSpecifications
{
    public class EventElementNameSpecificationTests
    {
        [Theory]
        [InlineData("matchingElement", "matchingElement", true)]
        [InlineData("unmatchingElement", "testElement", false)]
        public void IsSatisfiedBy(string elementName, string eventElementName, bool expectedResult)
        {
            //Arrange
            var sut = new ElementNameEventSpecification(elementName);
            var elementEvent = new ButtonElementClickedEvent(DateTime.Now, eventElementName);

            //Act
            var result = sut.Interpret(elementEvent);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}