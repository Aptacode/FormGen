namespace Aptacode.Forms.Shared.Models.Elements
{
    public class ButtonElementModel : FormElementModel
    {
        internal ButtonElementModel() { }

        public ButtonElementModel(string name, ElementLabel label, string content) : base(
            nameof(ButtonElementModel), name, label)
        {
            Content = content;
        }

        #region Properties

        public string Content { get; internal set; }

        #endregion
    }
}