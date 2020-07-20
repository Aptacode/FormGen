using System;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.Event;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.EventListeners.Specifications.Events
{
    public class EventElementNameSpecificationTests
    {
        [Theory]
        [InlineData("matchingElement", "matchingElement", true)]
        [InlineData("unmatchingElement", "testElement", false)]

        public void IsSatisfiedBy(string elementName, string eventElementName, bool expectedResult)
        {
            //Arrange
            var sut = new EventElementNameSpecification(elementName);
            var elementEvent = new ButtonElementClickedEvent(DateTime.Now, eventElementName);

            //Act
            var result = sut.IsSatisfiedBy(elementEvent);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
