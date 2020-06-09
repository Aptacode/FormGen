using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Events;

namespace Aptacode.Forms.Shared.Elements
{
    public class ButtonElement : FormElement
    {
        internal ButtonElement()
        {
        }

        public ButtonElement(string name, string content, LabelPosition labelPosition, string label) : base(
            nameof(ButtonElement), name, labelPosition, label)
        {
            Content = content;
        }

        #region Properties

        public string Content { get; set; }

        #endregion


        public void Clicked()
        {
            TriggerEvent(new ButtonClickedEventArgs(this));
        }
    }
}