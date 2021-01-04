using Aptacode.Forms.Shared.Enums;

namespace Aptacode.Forms.Shared.Models.Elements.Controls
{
    public class ElementLabel
    {
        /// <summary>
        ///     The position of a FormElement's Label relative to its content
        /// </summary>
        public ElementLabel(LabelPosition position, string text)
        {
            Position = position;
            Text = text;
        }

        public string Text { get; set; }
        public LabelPosition Position { get; set; }
        public bool IsHidden => Position == LabelPosition.Hidden;

        public static ElementLabel None => new(LabelPosition.Hidden, "");

        public static ElementLabel Above(string text)
        {
            return new(LabelPosition.Above, text);
        }

        public static ElementLabel Below(string text)
        {
            return new(LabelPosition.Below, text);
        }

        public static ElementLabel Left(string text)
        {
            return new(LabelPosition.Left, text);
        }

        public static ElementLabel Right(string text)
        {
            return new(LabelPosition.Right, text);
        }
    }
}