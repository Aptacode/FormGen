using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Expressions;
using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class ValidationRule<TField> where TField : IFieldViewModel
    {
        public ValidationRule(IExpression<bool,TField> specification, string successMessage = "", string failMessage = "")
        {
            SuccessMessage = successMessage;
            FailMessage = failMessage;
            Specification = specification;
        }

        public string SuccessMessage { get; set; }
        public string FailMessage { get; set; }
        public IExpression<bool,TField> Specification { get; set; }

        public static ValidationRule<TField> Create(NaryBoolExpression<TField> specification, string successMessage = "",
            string failMessage = "") => new ValidationRule<TField>(specification, successMessage, failMessage);

        public ValidationResult Validate(TField instance)
        {
            return Specification.Interpret(instance) ? ValidationResult.Success(SuccessMessage) : ValidationResult.Fail(FailMessage);
        }
    }
}