using System.Collections.Generic;

namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public abstract class CompositeElement : FormElement
    {
        #region Properties

        public IEnumerable<FormElement> Children { get; set; }

        #endregion
    }
}