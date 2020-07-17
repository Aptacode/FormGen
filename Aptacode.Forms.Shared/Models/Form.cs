using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.Models.Json;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Models
{
    /// <summary>
    ///     Models a Form
    ///     Contains a collection of Form Groups
    /// </summary>
    public class Form
    {
        internal Form() { }

        public Form(string name, string title, CompositeElement rootElement, params EventListener[] eventListeners)
        {
            Name = name;
            Title = title;
            RootElement = rootElement;
            EventListeners = eventListeners?.ToList() ?? new List<EventListener>();

        }

        #region Properties

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
        
        [JsonConverter(typeof(FormElementJsonConverter))]
        public CompositeElement RootElement { get; set; }


        [JsonConverter(typeof(SingleOrArrayConverter<EventListener>))]
        public IEnumerable<EventListener> EventListeners { get; set; }

        #endregion

    }
}