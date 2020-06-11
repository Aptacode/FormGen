using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Fields;

namespace Aptacode.Forms.Shared.ViewModels.Factories
{
    public static class FormFieldViewModelFactory
    {
        public static FormFieldViewModel Create(FormFieldModel model)
        {
            switch (model)
            {
                case TextFieldModel textField:
                    return new TextFieldViewModel(textField);
                case ComboBoxFieldModel comboBoxField:
                    return new ComboBoxFieldViewModel(comboBoxField);
                case CheckBoxFieldModel checkBoxField:
                    return new CheckBoxFieldViewModel(checkBoxField);
                default:
                    return null;
            }
        }
    }
}