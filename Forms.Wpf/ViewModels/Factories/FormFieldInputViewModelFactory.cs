using Aptacode.Forms.Fields.Inputs;
using Aptacode.Forms.Wpf.ViewModels.Elements.Fields.Inputs;

namespace Aptacode.Forms.Wpf.ViewModels.Factories
{
    public class FormFieldInputFactory
    {
        public static FormFieldInputViewModel Create(BaseFieldInput fieldInput)
        {
            switch (fieldInput)
            {
                case TextField textField:
                    return new TextFieldInputViewModel(textField);
                case ComboBoxField comboBoxField:
                    return new ComboBoxFieldInputViewModel(comboBoxField);
            }

            return null;
        }
    }
}