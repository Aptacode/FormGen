using Aptacode.Forms.Shared.Models.Elements;
using System;

namespace Aptacode.Forms.Shared.ViewModels.Events
{
    public abstract class ButtonEventArgs : FormElementEvent
    {
        protected ButtonEventArgs(DateTime time, ButtonElementModel button) : base(time)
        {
            Button = button;
        }

        public ButtonElementModel Button { get; set; }
    }

    public class ButtonClickedEventArgs : ButtonEventArgs
    {
        public ButtonClickedEventArgs(DateTime time, ButtonElementModel button) : base(time, button) { }

        public override string ToString() => $"Button Clicked: {Button.Name}";
    }
}