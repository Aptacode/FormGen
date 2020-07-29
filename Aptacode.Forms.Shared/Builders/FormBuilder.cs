using System;
using System.Collections.Generic;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Builders
{
    public class FormBuilder
    {
        private Guid Id { get; set; } = Guid.NewGuid();
        private string Name { get; set; } = string.Empty;
        private string Title { get; set; } = string.Empty;
        private CompositeElement RootElement { get; set; } = new NullCompositeElement();
        private List<EventListener> EventListeners { get; set; } = new List<EventListener>();

        public FormBuilder AddEventListeners(IEnumerable<EventListener> eventListeners)
        {
            EventListeners.AddRange(eventListeners);
            return this;
        }

        public FormBuilder AddEventListeners(params EventListener[] eventListeners)
        {
            EventListeners.AddRange(eventListeners);
            return this;
        }

        public FormBuilder SetName(string name)
        {
            Name = name;
            return this;
        }

        public FormBuilder SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public FormBuilder SetRoot(CompositeElement root)
        {
            RootElement = root;
            return this;
        }

        public FormBuilder SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public Form Build()
        {
            var newForm = new Form
            {
                Id = Id,
                Name = Name,
                Title = Title,
                RootElement = RootElement,
                EventListeners = EventListeners
            };

            Reset();
            return newForm;
        }

        public void Reset()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Title = string.Empty;
            RootElement = new NullCompositeElement();
            EventListeners = new List<EventListener>();
        }
    }
}