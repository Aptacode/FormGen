using Aptacode.Forms.Shared.Models.Enums;

namespace Aptacode.Forms.Shared.Models.Elements
{
    public class ButtonElementModel : FormElementModel
    {
        internal ButtonElementModel() { }

        public ButtonElementModel(string name, string content, LabelPosition labelPosition, string label) : base(
            nameof(ButtonElementModel), name, labelPosition, label)
        {
            Content = content;
        }

        #region Properties

        public string Content { get; internal set; }

        #endregion
    }
}