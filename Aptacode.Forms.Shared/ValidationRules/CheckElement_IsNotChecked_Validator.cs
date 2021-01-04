using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class CheckElement_IsNotChecked_Validator : NaryBoolExpression<ICheckElementViewModel>
    {
        public override bool Interpret(ICheckElementViewModel context)
        {
            return !context.IsChecked;
        }
    }
}