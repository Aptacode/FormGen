using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Wpf.ViewModels.Elements;

namespace Aptacode.Forms.Wpf.ViewModels.Factories
{
    public class FormElementViewModelFactory
    {
        public static FormElementViewModel Create(FormElement formElement)
        {
            switch (formElement)
            {
                case FormField field:
                    return FormFieldViewModelFactory.Create(field);
                case HtmlElement htmlElement:
                    return new HtmlElementViewModel(htmlElement);
                case ButtonElement butonElement:
                    return new ButtonElementViewModel(butonElement);
            }

            return null;
        }
    }
}