using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class ElementLabelViewModel : BindableBase
    {
        public ElementLabelViewModel(ElementLabel model)
        {
            Model = model;
            Text = Model.Text;
            Position = Model.Position;
        }

        #region Properties

        public ElementLabel Model { get; }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                SetProperty(ref _text, value);
                Model.Text = _text;
            }
        }

        private LabelPosition _position;

        public LabelPosition Position
        {
            get => _position;
            set
            {
                SetProperty(ref _position, value);
                Model.Position = _position;
            }
        }

        #endregion
    }
}