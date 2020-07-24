using Aptacode.Forms.Shared.Models.Builders.Elements;
using Aptacode.Forms.Shared.Models.Builders.Elements.Controls;
using Aptacode.Forms.Shared.Models.Builders.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Builders.Elements.Layouts;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using System;

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
                case UniformRowElement uniformRowLayout:
                    return new UniformRowElementViewModel(uniformRowLayout);
                case ColumnElement columnLayout:
                    return new ColumnElementViewModel(columnLayout);
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
                case nameof(RowElement):
                    return new RowBuilder().SetName(elementName).Build();
                case nameof(UniformRowElement):
                    return new UniformRowBuilder().SetName(elementName).Build();
                case nameof(ColumnElement):
                    return new ColumnBuilder().SetName(elementName).Build();
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