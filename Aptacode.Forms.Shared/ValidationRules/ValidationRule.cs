using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ValidationRules
{

    public class ValidationRule<TField> where TField : IFieldViewModel
    {
        public string SuccessMessage { get; set; }
        public string FailMessage { get; set; }

        public ValidationRule(Specification<TField> specification, string successMessage = "", string failMessage = "")
        {
            SuccessMessage = successMessage;
            FailMessage = failMessage;
            Specification = specification;
        }
        public static ValidationRule<TField> Create<TField>(Specification<TField> specification, string successMessage = "", string failMessage = "") where TField : IFieldViewModel
        {
            return new ValidationRule<TField>(specification, successMessage, failMessage);
        }
        public Specification<TField> Specification { get; set; }
        public ValidationResult Validate(TField instance)
        {
            if (Specification.IsSatisfiedBy(instance))
            {
                return ValidationResult.Success(SuccessMessage);
            }
            else
            {
                return ValidationResult.Fail(FailMessage);
            }
        }
    }

    
}