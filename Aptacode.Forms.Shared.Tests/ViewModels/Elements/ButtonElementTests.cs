using Aptacode.Forms.Shared.Builders.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Xunit;

namespace Aptacode.Forms.Shared.Tests.ViewModels.Elements
{
    public class ButtonElementTests
    {
        [Fact]
        public void ButtonClickEvent_Fires()
        {
            //Arrange
            var sut = new ButtonElementViewModel(new ButtonElementBuilder().Build());
            var buttonClicked = false;
            sut.OnFormEvent += (s, e) => buttonClicked = true;

            //Act
            sut.ButtonClickedCommand.Execute(null);

            //Assert
            Assert.True(buttonClicked);
        }
    }
}