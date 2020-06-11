using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Factories
{
    public static class FormElementViewModelFactory
    {
        public static FormElementViewModel Create(FormElementModel model)
        {
            switch (model)
            {
                case FormFieldModel field:
                    return FormFieldViewModelFactory.Create(field);
                case HtmlElementModel htmlElement:
                    return new HtmlElementViewModel(htmlElement);
                case ButtonElementModel buttonElement:
                    return new ButtonElementViewModel(buttonElement);
                default:
                    return null;
            }
        }
    }
}