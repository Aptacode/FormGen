using System;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.EventListeners.Specifications.EventSpecifications
{
    public class EventTypeSpecificationTests
    {
        [Theory]
        [InlineData(nameof(ButtonElementClickedEvent), true)]
        [InlineData(nameof(TextElementChangedEvent), false)]
        public void IsSatisfiedBy(string eventType, bool expectedResult)
        {
            //Arrange
            var sut = new TypeNameEventSpecification(eventType);
            var elementEvent = new ButtonElementClickedEvent(DateTime.Now, "Test Button");

            //Act
            var result = sut.IsSatisfiedBy(elementEvent);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}