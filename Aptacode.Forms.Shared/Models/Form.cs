using System;
using System.Collections.Generic;
using Aptacode.CSharp.Common.Persistence;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.Models
{
    /// <summary>
    ///     Models a Form
    ///     Contains a collection of Form Groups
    /// </summary>
    public class Form : IEntity<Guid>
    {
        public Form()
        {
            Id = Guid.NewGuid();
        }


        #region Properties

        /// <summary>
        ///     The Forms ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     The Forms name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The Forms Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     The collection of groups that make up the form
        /// </summary>
        public CompositeElement RootElement { get; set; }

        public IEnumerable<EventListener> EventListeners { get; set; }

        #endregion
    }
}