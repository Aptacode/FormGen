using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Events;
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

            var sut = new TextFieldViewModel("Test Text Field", ElementLabel.None, "Test") {Content = startString};
            sut.OnFormEvent += (s, e) =>
            {
                if (!(e is TextFieldChangedEventArgs textChangedEvent))
                {
                    return;
                }

                textChangedOldString = textChangedEvent.OldContent;
                textChangedNewString = textChangedEvent.NewContent;
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