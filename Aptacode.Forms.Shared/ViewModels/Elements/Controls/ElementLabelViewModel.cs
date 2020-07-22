using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class ElementLabelViewModel : BindableBase
    {
        public ElementLabelViewModel(ElementLabel model)
        {
            Model = model;
        }

        #region Properties

        private ElementLabel _model;

        public ElementLabel Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);

                if (_model != null)
                {
                    Text = _model.Text;
                    Position = _model.Position;
                }
                else
                {
                    Text = string.Empty;
                    Position = ElementLabel.LabelPosition.Hidden;
                }


            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                SetProperty(ref _text, value);
                if (_model != null)
                {
                    _model.Text = _text;
                }
            }
        }

        private ElementLabel.LabelPosition _position;

        public ElementLabel.LabelPosition Position
        {
            get => _position;
            set
            {
                SetProperty(ref _position, value);
                if (_model != null)
                {
                    _model.Position = _position;
                }
            }
        }

        #endregion


    }
}
