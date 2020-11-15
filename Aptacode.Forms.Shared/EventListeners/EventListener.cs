using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Shared.EventListeners
{
    public sealed class EventListener
    {
        public EventListener(
            string name,
            IBooleanExpression<FormElementEvent> eventTrigger,
            IBooleanExpression<FormViewModel> formCondition)
        {
            Name = name;
            EventTrigger = eventTrigger;
            FormCondition = formCondition;
        }

        public bool IsSatisfiedBy(FormViewModel formViewModel, FormElementEvent formEvent) =>
            EventTrigger.Interpret(formEvent) &&
            (FormCondition?.Interpret(formViewModel) != false);

        #region Properties

        public string Name { get; set; }
        public IBooleanExpression<FormElementEvent> EventTrigger { get; set; }
        public IBooleanExpression<FormViewModel> FormCondition { get; set; }

        #endregion
    }
}