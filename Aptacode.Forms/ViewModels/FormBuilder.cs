using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Models.Layout;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Layout;

namespace Aptacode.Forms.Shared.ViewModels
{
    public static class FormBuilder
    {
        public static FormViewModel CreateForm(string name, string title, params FormGroupModel[] groups) =>
            new FormViewModel(new FormModel(name, title, groups.ToList()));

        public static FormGroupViewModel AddGroup(this FormViewModel form, string label, params FormRowModel[] rows)
        {
            var newGroup = new FormGroupViewModel(label, rows);
            form.Groups.Add(newGroup);
            return newGroup;
        }

        public static FormGroupViewModel AddGroup(this FormViewModel form, string label, FormRowViewModel firstRow,
            params FormRowViewModel[] rows)
        {
            var newGroup = new FormGroupViewModel(label);

            newGroup.Rows.Add(firstRow);
            if (rows != null)
            {
                foreach (var row in rows)
                {
                    newGroup.Rows.Add(row);
                }
            }

            form.Groups.Add(newGroup);
            return newGroup;
        }

        public static FormRowViewModel AddRow(this FormGroupViewModel form, string name, int span,
            params FormColumnModel[] columns)
        {
            var newRow = new FormRowViewModel(name, span, columns);
            form.Rows.Add(newRow);
            return newRow;
        }

        public static FormRowViewModel AddRows(this FormGroupViewModel form, string name, int span,
            FormColumnViewModel firstColumn, params FormColumnViewModel[] columns)
        {
            var newRow = new FormRowViewModel(name, span);
            newRow.Columns.Add(firstColumn);
            if (columns != null)
            {
                foreach (var column in columns)
                {
                    newRow.Columns.Add(column);
                }
            }

            form.Rows.Add(newRow);
            return newRow;
        }

        public static FormColumnViewModel AddColumn(this FormRowViewModel form, int span) => AddColumn(form, span,
            new ButtonElementModel("default", "default", LabelPosition.AboveElement, "default"));

        public static FormColumnViewModel AddColumn(this FormRowViewModel form, int span, FormElementModel element)
        {
            var newColumn = new FormColumnViewModel(new FormColumnModel(span, element));
            form.Columns.Add(newColumn);
            return newColumn;
        }

        public static FormColumnViewModel AddColumn(this FormRowViewModel form, int span, FormElementViewModel element)
        {
            var newColumn = new FormColumnViewModel(new FormColumnModel(span, element.ElementModel))
            {
                FormElementViewModel = element
            };

            form.Columns.Add(newColumn);
            return newColumn;
        }


        public static FormGroupViewModel NewGroup(string label, params FormRowModel[] rows) =>
            new FormGroupViewModel(new FormGroupModel(label, rows));

        public static FormGroupViewModel NewGroup(string label, params FormRowViewModel[] rows)
        {
            var newGroup = new FormGroupViewModel(new FormGroupModel(label, new List<FormRowModel>()));
            foreach (var row in rows)
            {
                newGroup.Rows.Add(row);
            }

            return newGroup;
        }

        public static FormRowViewModel NewRow(string name, int span, params FormColumnModel[] columns) =>
            new FormRowViewModel(new FormRowModel(name, span, columns));

        public static FormRowViewModel NewRow(string name, int span, params FormColumnViewModel[] columns)
        {
            var newRow = new FormRowViewModel(new FormRowModel(name, span, new List<FormColumnModel>()));
            foreach (var column in columns)
            {
                newRow.Columns.Add(column);
            }

            return newRow;
        }

        public static FormColumnViewModel NewColumn(int span, FormElementViewModel element) =>
            new FormColumnViewModel(new FormColumnModel(span, element.ElementModel))
            {
                FormElementViewModel = element
            };
    }
}