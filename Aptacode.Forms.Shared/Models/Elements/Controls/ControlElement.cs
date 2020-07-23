using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class ControlElement : FormElement
    {
        #region Properties

        public ElementLabel Label { get; set; }

        #endregion
    }
}