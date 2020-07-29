using Aptacode.Forms.Shared.Builders.Elements.Composite;
using Aptacode.Forms.Shared.Builders.Elements.Controls;
using Aptacode.Forms.Shared.Builders.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Interfaces;
using Aptacode.Forms.Shared.Interfaces.Composite;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Composite;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Composite;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Factories
{
    public static class FormElementViewModelFactory
    {
        public static IFormElementViewModel Create(FormElement model)
        {
            switch (model)
            {
                //Layouts
                case CompositeElement compositeElement:
                    return CreateComposite(compositeElement);
                //Controls
                case HtmlElement htmlElement:
                    return new HtmlElementViewModel(htmlElement);
                case ButtonElement buttonElement:
                    return new ButtonElementViewModel(buttonElement);
                //Fields
                case TextElement textField:
                    return new TextElementViewModel(textField);
                case SelectElement comboBoxField:
                    return new SelectElementViewModel(comboBoxField);
                case CheckElement checkBoxField:
                    return new CheckElementViewModel(checkBoxField);
                default:
                    return new NullElementViewModel();
            }
        }

        public static ICompositeElementViewModel CreateComposite(CompositeElement model)
        {
            switch (model)
            {
                case GroupElement elementGroup:
                    return new GroupElementViewModel(elementGroup);
                case LinearLayoutElement linearLayout:
                    return new LinearLayoutElementViewModel(linearLayout);
                default:
                    return new NullCompositeViewModel();
            }
        }

        public static FormElement Create(string elementType, string elementName)
        {
            switch (elementType)
            {
                case nameof(GroupElement):
                    return new GroupBuilder().SetName(elementName).Build();
                case nameof(LinearLayoutElement):
                    return new LinearLayoutBuilder().SetName(elementName).Build();
                case nameof(CheckElement):
                    return new CheckElementBuilder().SetName(elementName).Build();
                case nameof(SelectElement):
                    return new SelectElementBuilder().SetName(elementName).Build();
                case nameof(TextElement):
                    return new TextElementBuilder().SetName(elementName).Build();
                case nameof(ButtonElement):
                    return new ButtonElementBuilder().SetName(elementName).Build();
                case nameof(HtmlElement):
                    return new HtmlElementBuilder().SetName(elementName).Build();
            }

            return new NullElement();
        }
    }
}