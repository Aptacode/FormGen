using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class ValidationRule<TField> where TField : IFieldViewModel
    {
        public ValidationRule(Specification<TField> specification, string successMessage = "", string failMessage = "")
        {
            SuccessMessage = successMessage;
            FailMessage = failMessage;
            Specification = specification;
        }

        public string SuccessMessage { get; set; }
        public string FailMessage { get; set; }
        public Specification<TField> Specification { get; set; }

        public static ValidationRule<TField> Create(Specification<TField> specification, string successMessage = "",
            string failMessage = "") => new ValidationRule<TField>(specification, successMessage, failMessage);

        public ValidationResult Validate(TField instance)
        {
            if (Specification.IsSatisfiedBy(instance))
            {
                return ValidationResult.Success(SuccessMessage);
            }

            return ValidationResult.Fail(FailMessage);
        }
    }
}