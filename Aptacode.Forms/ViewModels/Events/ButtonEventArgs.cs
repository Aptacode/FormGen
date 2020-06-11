using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class ButtonEventArgs : FormElementEventArgs
    {
        protected ButtonEventArgs(DateTime time) : base(time) { }
    }

    public class ButtonClickedEventArgs : ButtonEventArgs
    {
        public ButtonClickedEventArgs(DateTime time) : base(time) { }

        public override string ToString() => "Button Clicked";
    }
}