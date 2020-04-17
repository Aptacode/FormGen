using Aptacode.Forms.Forms.Fields.Inputs;

namespace Aptacode.Forms.Forms.Fields.ValidationRules
{
    public class TextInputIsRequiredValidationRule : ValidationRule<TextFieldInput>
    {
        public TextInputIsRequiredValidationRule() :base(nameof(TextInputIsRequiredValidationRule))
        {
                
        }
    }
}