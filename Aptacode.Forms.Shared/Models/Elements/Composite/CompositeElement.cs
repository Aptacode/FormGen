using System.Collections.Generic;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Shared.Models.Elements.Composite
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public abstract class CompositeElement : FormElement
    {
        #region Properties

        public IEnumerable<FormElement> Children { get; set; }
        public LayoutMode LayoutMode { get; set; }
        public LayoutOrientation LayoutOrientation { get; set; }

        #endregion
    }
}