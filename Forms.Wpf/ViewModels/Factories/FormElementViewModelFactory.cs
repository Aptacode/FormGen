using Aptacode.Forms.Fields;
using Aptacode.Forms.Wpf.ViewModels.Elements;
using Aptacode.Forms.Wpf.ViewModels.Elements.Fields;

namespace Aptacode.Forms.Wpf.ViewModels.Factories
{
    public class FormElementViewModelFactory
    {
        public static FormElementViewModel Create(FormElement formElement)
        {
            switch (formElement)
            {
                case FormField field:
                    return new FormFieldViewModel(field);
                case FormHtmlContent htmlContent:
                    return new FormHtmlContentViewModel(htmlContent);
            }

            return null;
        }
    }
}