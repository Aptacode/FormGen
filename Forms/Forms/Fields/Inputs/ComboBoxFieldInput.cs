using System.Collections.Generic;
using Aptacode.Forms.Forms.Fields.ValidationRules;

namespace Aptacode.Forms.Forms.Fields.Inputs
{
    public class ComboBoxFieldInput : FieldInput
    {
        public ComboBoxFieldInput()
        {

        }

        public ComboBoxFieldInput(IEnumerable<ValidationRule<ComboBoxFieldInput>> rules) : base(nameof(ComboBoxFieldInput), rules)
        {

        }
    }
}