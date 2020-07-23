using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Shared.EventListeners
{
    public sealed class EventListener
    {
        public EventListener(
            string name,
            Specification<FormElementEvent> eventTrigger,
            Specification<FormViewModel> formCondition)
        {
            Name = name;
            EventTrigger = eventTrigger;
            FormCondition = formCondition;
        }

        public bool IsSatisfiedBy(FormViewModel formViewModel, FormElementEvent formEvent) =>
            EventTrigger.IsSatisfiedBy(formEvent) &&
            (FormCondition == null || FormCondition.IsSatisfiedBy(formViewModel));

        #region Properties

        public string Name { get; set; }
        public Specification<FormElementEvent> EventTrigger { get; set; }
        public Specification<FormViewModel> FormCondition { get; set; }

        #endregion
    }
}