using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.ViewModels.Elements
{
    public class ButtonElementTests
    {
        [Fact]
        public void ButtonClickEvent_Fires()
        {
            //Arrange
            var sut = new ButtonElementViewModel("submit button", ElementLabel.None, "submit");
            var buttonClicked = false;
            sut.OnFormEvent += (s, e) => { buttonClicked = true; };

            //Act
            sut.ButtonClickedCommand.Execute(null);

            //Assert
            Assert.True(buttonClicked);
        }
    }
}