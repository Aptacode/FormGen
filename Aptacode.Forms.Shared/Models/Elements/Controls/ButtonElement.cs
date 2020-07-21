namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    public class ButtonElement : ControlElement
    {
        public ButtonElement(string name, ElementLabel label, string content) : base(name, label)
        {
            Content = content;
        }

        #region Properties

        public string Content { get; set; }

        #endregion
    }
}