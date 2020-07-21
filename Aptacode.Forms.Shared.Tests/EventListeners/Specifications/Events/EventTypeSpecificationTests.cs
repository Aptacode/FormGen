using System;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.Event;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.EventListeners.Specifications.Events
{
    public class EventTypeSpecificationTests
    {
        [Theory]
        [InlineData(nameof(ButtonElementClickedEvent), true)]
        [InlineData(nameof(TextElementChangedEvent), false)]

        public void IsSatisfiedBy(string eventType, bool expectedResult)
        {
            //Arrange
            var sut = new EventTypeSpecification(eventType);
            var elementEvent = new ButtonElementClickedEvent(DateTime.Now, "Test Button");

            //Act
            var result = sut.IsSatisfiedBy(elementEvent);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
