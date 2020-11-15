using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class TextElement_MaximumLength_Validator : TerminalBoolExpression<ITextElementViewModel>
    {
        public TextElement_MaximumLength_Validator(int maxLength)
        {
            MaxLength = maxLength;
        }

        public int MaxLength { get; set; }

        public override bool Interpret(ITextElementViewModel context) => context.Content.Length <= MaxLength;
    }
}