using System;
using Aptacode.CSharp.Common.Persistence;

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

        #endregion
    }
}