using Aptacode.Forms.Forms.Fields.Inputs;

namespace Aptacode.Forms.Forms.Fields.ValidationRules
{
    public class TextInputLengthValidationRule : ValidationRule<TextFieldInput>
    {
        public TextInputLengthValidationRule() : base(nameof(TextInputLengthValidationRule))
        {

        }
    }
}