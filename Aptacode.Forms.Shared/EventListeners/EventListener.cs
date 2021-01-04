using Aptacode.Expressions;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Shared.EventListeners
{
    public sealed class EventListener
    {
        public EventListener(
            string name,
            IExpression<bool, FormElementEvent> eventTrigger,
            IExpression<bool, FormViewModel> formCondition)
        {
            Name = name;
            EventTrigger = eventTrigger;
            FormCondition = formCondition;
        }

        public bool IsSatisfiedBy(FormViewModel formViewModel, FormElementEvent formEvent)
        {
            return EventTrigger.Interpret(formEvent) &&
                   FormCondition?.Interpret(formViewModel) != false;
        }

        #region Properties

        public string Name { get; set; }
        public IExpression<bool, FormElementEvent> EventTrigger { get; set; }
        public IExpression<bool, FormViewModel> FormCondition { get; set; }

        #endregion
    }
}