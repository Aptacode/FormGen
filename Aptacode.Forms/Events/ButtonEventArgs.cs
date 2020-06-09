using Aptacode.Forms.Shared.Elements;

namespace Aptacode.Forms.Shared.Events
{
    public abstract class ButtonEventArgs : FormElementEvent
    {
        protected ButtonEventArgs(ButtonElement button)
        {
            Button = button;
        }

        public ButtonElement Button { get; set; }
    }

    public class ButtonClickedEventArgs : ButtonEventArgs
    {
        public ButtonClickedEventArgs(ButtonElement button) : base(button)
        {
        }
    }
}