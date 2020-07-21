using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public abstract class CompositeElement : FormElement
    {
        protected CompositeElement(string name, IEnumerable<FormElement> children) : base(name)
        {
            Children = children?.ToList() ?? new List<FormElement>();
        }

        #region Properties

        public IEnumerable<FormElement> Children { get; set; }



        #endregion
    }
}