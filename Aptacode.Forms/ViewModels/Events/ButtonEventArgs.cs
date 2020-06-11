using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class ButtonEventArgs : FormElementEvent
    {
        protected ButtonEventArgs(ButtonElementModel button)
        {
            Button = button;
        }

        public ButtonElementModel Button { get; set; }
    }

    public class ButtonClickedEventArgs : ButtonEventArgs
    {
        public ButtonClickedEventArgs(ButtonElementModel button) : base(button) { }
    }
}