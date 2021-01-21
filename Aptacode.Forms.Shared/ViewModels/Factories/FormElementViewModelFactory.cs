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
        public static IFormElementViewModel ToViewModel(this FormElement model)
        {
            return model switch
            {
                //Layouts
                CompositeElement compositeElement => CreateComposite(compositeElement),
                //Controls
                HtmlElement htmlElement => new HtmlElementViewModel(htmlElement),
                ButtonElement buttonElement => new ButtonElementViewModel(buttonElement),
                //Fields
                TextElement textField => new TextElementViewModel(textField),
                SelectElement comboBoxField => new SelectElementViewModel(comboBoxField),
                CheckElement checkBoxField => new CheckElementViewModel(checkBoxField),
                ListEditElement listEditElement => new ListEditElementViewModel(listEditElement),
                _ => new NullElementViewModel()
            };
        }

        public static ICompositeElementViewModel CreateComposite(CompositeElement model)
        {
            return model switch
            {
                GroupElement elementGroup => new GroupElementViewModel(elementGroup),
                LinearLayoutElement linearLayout => new LinearLayoutElementViewModel(linearLayout),
                _ => new NullCompositeViewModel()
            };
        }

        public static FormElement Create(string elementType, string elementName)
        {
            return elementType switch
            {
                nameof(GroupElement) => new GroupBuilder().SetName(elementName).Build(),
                nameof(LinearLayoutElement) => new LinearLayoutBuilder().SetName(elementName).Build(),
                nameof(CheckElement) => new CheckElementBuilder().SetName(elementName).Build(),
                nameof(SelectElement) => new SelectElementBuilder().SetName(elementName).Build(),
                nameof(TextElement) => new TextElementBuilder().SetName(elementName).Build(),
                nameof(ButtonElement) => new ButtonElementBuilder().SetName(elementName).Build(),
                nameof(HtmlElement) => new HtmlElementBuilder().SetName(elementName).Build(),
                nameof(ListEditElement) => new ListEditElementBuilder().SetName(elementName).Build(),
                _ => new NullElement()
            };
        }
    }
}