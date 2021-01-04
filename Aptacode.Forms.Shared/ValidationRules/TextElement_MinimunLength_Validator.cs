using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MinimunLength_Validator : NaryBoolExpression<ITextElementViewModel>
    {
        public TextElement_MinimunLength_Validator(int minimunLength)
        {
            MinimunLength = minimunLength;
        }

        public int MinimunLength { get; set; }

        public override bool Interpret(ITextElementViewModel context) => context.Content.Length >= MinimunLength;
    }
}