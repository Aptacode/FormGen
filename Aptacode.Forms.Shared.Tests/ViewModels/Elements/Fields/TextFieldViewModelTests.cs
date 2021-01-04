using Aptacode.Forms.Shared.Builders.Elements.Controls.Fields;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.ViewModels.Elements.Fields
{
    public class TextFieldViewModelTests
    {
        [Fact]
        public void ContentChangeFiresTextFieldChangedEvent()
        {
            //Arrange
            const string startString = "Start";
            const string endString = "End";
            var textChangedOldString = string.Empty;
            var textChangedNewString = string.Empty;

            var sut = new TextElementViewModel(new TextElementBuilder().Build()) {Content = startString};
            sut.OnFormEvent += (s, e) =>
            {
                if (!(e is TextElementChangedEvent textChangedEvent)) return;

                textChangedOldString = textChangedEvent.OldValue;
                textChangedNewString = textChangedEvent.NewValue;
            };

            //Act
            sut.Content = endString;

            //Assert
            Assert.Equal(startString, textChangedOldString);
            Assert.Equal(endString, textChangedNewString);
            Assert.Equal(endString, sut.Content);
        }
    }
}