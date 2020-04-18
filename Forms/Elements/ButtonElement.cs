using Aptacode.Forms.Enums;
using Aptacode.Forms.Events;

namespace Aptacode.Forms.Elements
{
    public class ButtonElement : FormElement
    {
        public ButtonElement()
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