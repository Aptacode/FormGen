using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Shared.EventListeners
{
    public sealed class EventListener
    {
        public EventListener(string name, Specification<FormElementEvent> specification,
            Specification<FormViewModel> condition)
        {
            Name = name;
            Specification = specification;
            Condition = condition;
        }

        public string Name { get; }
        public Specification<FormElementEvent> Specification { get; set; }
        public Specification<FormViewModel> Condition { get; set; }

        public bool IsSatisfiedBy(FormViewModel formViewModel, FormElementEvent formEvent) =>
            Specification.IsSatisfiedBy(formEvent) && (Condition == null || Condition.IsSatisfiedBy(formViewModel));
    }
}