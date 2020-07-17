using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Json;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models.Elements.Layouts
{
    /// <summary>
    ///     Models a Form Row
    ///     Contains a collection of Form Columns
    /// </summary>
    public abstract class CompositeElement : FormElement
    {
        internal CompositeElement() { }

        protected CompositeElement(string elementType, string name, IEnumerable<FormElement> children) : base(
            elementType, name)
        {
            Children = children?.ToList() ?? new List<FormElement>();
        }

        #region Properties

        [JsonConverter(typeof(SingleOrArrayConverter<FormElement>))]
        public IEnumerable<FormElement> Children { get; set; }

        #endregion
    }
}