using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Layout;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Layout;

namespace Aptacode.Forms.Shared.ViewModels
{
    public static class FormBuilder
    {
        public static FormViewModel CreateForm(string name, string title, params FormGroupModel[] groups) =>
            new FormViewModel(new FormModel(name, title, groups.ToList()));

        public static FormGroupViewModel AddGroup(this FormViewModel form, string name, string title, params FormRowModel[] rows)
        {
            var newGroup = new FormGroupViewModel(name, title, rows);
            form.Groups.Add(newGroup);
            return newGroup;
        }

        public static FormGroupViewModel AddGroup(this FormViewModel form, string name, string title, FormRowViewModel firstRow,
            params FormRowViewModel[] rows)
        {
            var newGroup = new FormGroupViewModel(name, title);

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

        public static FormColumnViewModel AddColumn(this FormRowViewModel form, string name, int span) => AddColumn(form, name, span,
            new ButtonElementModel("default", ElementLabel.None, "default"));

        public static FormColumnViewModel AddColumn(this FormRowViewModel form, string name, int span, FormElementModel element)
        {
            var newColumn = new FormColumnViewModel(new FormColumnModel(name, span, element));
            form.Columns.Add(newColumn);
            return newColumn;
        }

        public static FormColumnViewModel AddColumn(this FormRowViewModel form, string name, int span, FormElementViewModel element)
        {
            var newColumn = new FormColumnViewModel(new FormColumnModel(name, span, element.ElementModel))
            {
                FormElementViewModel = element
            };

            form.Columns.Add(newColumn);
            return newColumn;
        }


        public static FormGroupViewModel NewGroup(string name, string title, params FormRowModel[] rows) =>
            new FormGroupViewModel(new FormGroupModel(name, title, rows));

        public static FormGroupViewModel NewGroup(string name, string title, params FormRowViewModel[] rows)
        {
            var newGroup = new FormGroupViewModel(new FormGroupModel(name, title, new List<FormRowModel>()));
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

        public static FormColumnViewModel NewColumn(string name, int span, FormElementViewModel element) =>
            new FormColumnViewModel(new FormColumnModel(name, span, element.ElementModel))
            {
                FormElementViewModel = element
            };
    }
}