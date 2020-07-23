using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public static class ValidationRuleExtensions
    {
        public static ValidationRule<TField> WithSpecification<TField>(this ValidationRule<TField> rule,
            Specification<TField> specification) where TField : IFieldViewModel
        {
            rule.Specification = specification;
            return rule;
        }

        public static ValidationRule<TField> WithSuccessMessage<TField>(this ValidationRule<TField> rule,
            string successMessage) where TField : IFieldViewModel
        {
            rule.SuccessMessage = successMessage;
            return rule;
        }

        public static ValidationRule<TField> WithFailMessage<TField>(this ValidationRule<TField> rule,
            string failMessage) where TField : IFieldViewModel
        {
            rule.FailMessage = failMessage;
            return rule;
        }
    }
}