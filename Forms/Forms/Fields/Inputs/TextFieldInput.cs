using System.Collections.Generic;
using Aptacode.Forms.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Forms.Fields.Inputs
{
    public class TextFieldInput : FieldInput
    {
        public TextFieldInput()
        {

        }

        public TextFieldInput(IEnumerable<ValidationRule<TextFieldInput>> rules) : base(nameof(TextFieldInput), rules)
        {

        }
    }
}