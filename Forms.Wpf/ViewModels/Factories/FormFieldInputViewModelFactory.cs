using Aptacode.Forms.Fields;
using Aptacode.Forms.Fields.Inputs;
using Aptacode.Forms.Wpf.ViewModels.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Factories
{
    public class FormFieldViewModelFactory
    {
        public static FormFieldViewModel Create(FormField formField)
        {
            switch (formField)
            {
                case TextField textField:
                    return new TextFieldViewModel(textField);
                case ComboBoxField comboBoxField:
                    return new ComboBoxFieldViewModel(comboBoxField);
            }

            return null;
        }
    }
}