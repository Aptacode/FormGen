using System;
using Aptacode.CSharp.Common.Persistence;
using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Shared.Models.Elements
{
    /// <summary>
    ///     Abstract Form Element Model
    /// </summary>
    public abstract class FormElement : IEntity<Guid>
    {
        protected FormElement()
        {
            Id = Guid.Empty;
        }

        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }

        public VerticalAlignment VerticalAlignment { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }

        #endregion
    }
}