using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Factories
{
    public static class FormElementViewModelFactory
    {
        public static FormElementViewModel Create(FormElement model)
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

        public static CompositeElementViewModel CreateComposite(CompositeElement model)
        {
            switch (model)
            {
                //Layouts
                case GroupElement elementGroup:
                    return new GroupElementViewModel(elementGroup);
                case RowElement rowLayout:
                    return new RowElementViewModel(rowLayout);
                case ColumnElement columnLayout:
                    return new ColumnElementViewModel(columnLayout);
                default:
                    return new NullCompositeViewModel();
            }
        }
    }
}