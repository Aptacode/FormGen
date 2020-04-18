using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Events;

namespace Aptacode.Forms
{
    public class Form
    {
        public Form()
        {
        }

        public Form(string name, string title, IEnumerable<FormGroup> groups)
        {
            Name = name;
            Title = title;
            Groups = groups;
            SubscribeToElementEvents();
        }

        #region Events

        private void SubscribeToElementEvents()
        {
            foreach (var formField in Elements())
            {
                formField.OnFormEvent += FormField_OnFormEvent;
            }
        }

        public event EventHandler<FormEventArgs> OnFormEvent;
        private void FormField_OnFormEvent(object sender, FormElementEvent e)
        {
            OnFormEvent?.Invoke(this, e);
        }
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Title { get; set; }

        public IEnumerable<FormGroup> Groups { get; set; }

        #endregion


        public bool IsValid => Fields().All(field => field.IsValid());

        public IEnumerable<string> GetValidationMessages() => Fields().Select(field => field.GetValidationMessages())
            .Aggregate((a, b) => a.Concat(b));

        public string GetValidationMessage() => string.Join("\n", GetValidationMessages());

        private IEnumerable<FormElement> Elements()
        {
            return Groups
                .Select(group => group.Rows).Aggregate((a, b) => a.Concat(b))
                .Select(row => row.Columns).Aggregate((a, b) => a.Concat(b))
                .Select(column => column.Element);
        }

        private IEnumerable<FormField> Fields()
        {
            return Elements()
                .Select(element => element as FormField)
                .Where(field => field != null);
        }

        #region Results
        public IEnumerable<FieldResult> GetResults()
        {
            return Fields().Select(field => field.GetResult());
        }

        public FormResult GetResult()
        {
            return new FormResult(this, GetResults());
        }

        #endregion


    }
}