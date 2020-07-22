using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels
{
    public static class FormBuilder
    {
        #region Layout

        public static FormViewModel CreateForm(string name, string title, CompositeElement rootElement) =>
            new FormViewModel(new Form(name, title, rootElement));

        public static FormViewModel CreateForm(string name, string title) =>
            new FormViewModel(new Form(name, title, new NullCompositeElement()));

        public static CompositeElementViewModel SetRoot(this FormViewModel form, CompositeElementViewModel compositeElement)
        {
            form.RootElement = compositeElement;
            return compositeElement;
        }

        public static GroupElementViewModel AddGroup(this CompositeElementViewModel compositeElement, string name,
            string title,
            params FormElement[] children)
        {
            var newGroup = new GroupElementViewModel(new GroupElement(name, title, children));
            compositeElement.Children.Add(newGroup);
            return newGroup;
        }

        public static GroupElementViewModel AddGroup(this CompositeElementViewModel compositeElement, string name,
            string title,
            FormElementViewModel firstChild,
            params FormElementViewModel[] children)
        {
            var newGroup = new GroupElementViewModel(new GroupElement(name, title));
            newGroup.Children.Add(firstChild);
            if (children != null)
            {
                foreach (var child in children)
                {
                    newGroup.Children.Add(child);
                }
            }

            compositeElement.Children.Add(newGroup);
            return newGroup;
        }

        public static RowElementViewModel AddRows(this CompositeElementViewModel compositeElement, string name,
            int span, params FormElement[] children)
        {
            var viewModel = new RowElementViewModel(new RowElement(name, span, children));
            compositeElement.Children.Add(viewModel);
            return viewModel;
        }

        public static RowElementViewModel AddRows(this CompositeElementViewModel compositeElement, string name,
            int span, FormElementViewModel firstChild, params FormElementViewModel[] children)
        {
            var viewModel = new RowElementViewModel(new RowElement(name, span));
            viewModel.Children.Add(firstChild);

            if (children != null)
            {
                foreach (var child in children)
                {
                    viewModel.Children.Add(child);
                }
            }

            compositeElement.Children.Add(viewModel);
            return viewModel;
        }

        public static ColumnElementViewModel AddColumns(this CompositeElementViewModel compositeElement, string name,
            int span,
            params FormElement[] children)
        {
            var newColumn = new ColumnElementViewModel(new ColumnElement(name, span, children));
            compositeElement.Children.Add(newColumn);
            return newColumn;
        }

        public static ColumnElementViewModel AddColumns(this CompositeElementViewModel compositeElement, string name,
            int span,
            FormElementViewModel firstChild,
            params FormElementViewModel[] children)
        {
            var newColumn = new ColumnElementViewModel(new ColumnElement(name, span));
            newColumn.Children.Add(firstChild);
            if (children != null)
            {
                foreach (var child in children)
                {
                    newColumn.Children.Add(child);
                }
            }

            compositeElement.Children.Add(newColumn);
            return newColumn;
        }


        public static GroupElementViewModel NewGroup(string name, string title, params FormElement[] children) =>
            new GroupElementViewModel(new GroupElement(name, title, children));

        public static RowElementViewModel NewRow(string name, int span, params FormElement[] children) =>
            new RowElementViewModel(new RowElement(name, span, children));

        public static ColumnElementViewModel NewColumn(string name, int span, params FormElement[] children) =>
            new ColumnElementViewModel(new ColumnElement(name, span, children));


        public static GroupElementViewModel NewGroup(string name, string title, FormElementViewModel firstChild,
            params FormElementViewModel[] children)
        {
            var viewModel = new GroupElementViewModel(new GroupElement(name, title));
            viewModel.Children.Add(firstChild);
            if (children != null)
            {
                foreach (var child in children)
                {
                    viewModel.Children.Add(child);
                }
            }

            return viewModel;
        }

        public static RowElementViewModel NewRow(string name, int span, FormElementViewModel firstChild,
            params FormElementViewModel[] children)
        {
            var viewModel = new RowElementViewModel(new RowElement(name, span));
            viewModel.Children.Add(firstChild);
            if (children != null)
            {
                foreach (var child in children)
                {
                    viewModel.Children.Add(child);
                }
            }

            return viewModel;
        }

        public static ColumnElementViewModel NewColumn(string name, int span, FormElementViewModel firstChild,
            params FormElementViewModel[] children)
        {
            var viewModel = new ColumnElementViewModel(new ColumnElement(name, span));
            viewModel.Children.Add(firstChild);
            if (children != null)
            {
                foreach (var child in children)
                {
                    viewModel.Children.Add(child);
                }
            }

            return viewModel;
        }

        #endregion


        #region Elements

        public static ButtonElementViewModel CreateButton(string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string content) =>
            new ButtonElementViewModel(name, label, alignment, content);

        public static HtmlElementViewModel CreateHtml(string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string content) =>
            new HtmlElementViewModel(name, label, alignment, content);

        public static TextElementViewModel CreateText(string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string defaultContent,
            params ValidationRule<ITextElementViewModel>[] rules) =>
            new TextElementViewModel(name, label, alignment, defaultContent, rules);

        public static CheckElementViewModel CreateCheck(string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string content,
            bool defaultValue, params ValidationRule<ICheckElementViewModel>[] rules) =>
            new CheckElementViewModel(name, label, alignment, content, defaultValue, rules);

        public static SelectElementViewModel CreateSelect(string name, ElementLabel label, ControlElement.VerticalAlignment alignment, IEnumerable<string> items,
            string defaultValue, params ValidationRule<ISelectElementViewModel>[] rules) =>
            new SelectElementViewModel(name, label, alignment, items, defaultValue, rules);



        public static CompositeElementViewModel AddButton(this CompositeElementViewModel parent, string name,
            ElementLabel label, ControlElement.VerticalAlignment alignment, string content)
        {
            parent.Children.Add(CreateButton(name, label, alignment, content));
            return parent;
        }

        public static CompositeElementViewModel AddHtml(this CompositeElementViewModel parent, string name,
            ElementLabel label, ControlElement.VerticalAlignment alignment, string content)
        {
            parent.Children.Add(CreateHtml(name, label, alignment, content));
            return parent;
        }

        public static CompositeElementViewModel AddText(this CompositeElementViewModel parent, string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string defaultContent,
            params ValidationRule<ITextElementViewModel>[] rules)
        {
            parent.Children.Add(CreateText(name, label, alignment, defaultContent, rules));
            return parent;
        }

        public static CompositeElementViewModel AddCheck(this CompositeElementViewModel parent, string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string content,
            bool defaultValue, params ValidationRule<ICheckElementViewModel>[] rules)
        {
            parent.Children.Add(CreateCheck(name, label, alignment, content, defaultValue, rules));
            return parent;
        }

        public static CompositeElementViewModel AddSelect(this CompositeElementViewModel parent, string name, ElementLabel label, ControlElement.VerticalAlignment alignment, IEnumerable<string> items,
            string defaultValue, params ValidationRule<ISelectElementViewModel>[] rules)
        {
            parent.Children.Add(CreateSelect(name, label, alignment, items, defaultValue, rules));
            return parent;
        }

        #endregion
    }
}