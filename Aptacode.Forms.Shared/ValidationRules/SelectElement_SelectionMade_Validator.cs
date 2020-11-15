using System;
using System.Linq.Expressions;
using Aptacode.Expressions.Bool;
using Aptacode.Forms.Shared.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ValidationRules
{
    public class SelectElement_SelectionMade_Validator : TerminalBoolExpression<ISelectElementViewModel>
    {
        public SelectElement_SelectionMade_Validator(string selectedItem)
        {
            SelectedItem = selectedItem;
        }

        public string SelectedItem { get; set; }

        public override bool Interpret(ISelectElementViewModel context) => context.SelectedItem == SelectedItem;
    }
}