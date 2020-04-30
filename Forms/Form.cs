using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Events;
using Aptacode.Forms.Json;
using Aptacode.Forms.Layout;
using Newtonsoft.Json;

namespace Aptacode.Forms
{
    public class Form
    {
        internal Form()
        {
        }

        public Form(string name, string title, IEnumerable<FormGroup> groups)
        {
            Groups = new List<FormGroup>();
            Name = name;
            Title = title;

            if (groups != null)
            {
                Groups.AddRange(groups);
            }

            SubscribeToElementEvents();
        }

        [JsonIgnore] public bool IsValid => Fields().All(field => field.IsValid());

        public IEnumerable<string> GetValidationMessages()
        {
            return Fields().Select(field => field.GetValidationMessages())
                .SelectMany(list => list);
        }

        public string GetValidationMessage()
        {
            return string.Join("\n", GetValidationMessages());
        }

        private IEnumerable<FormElement> Elements()
        {
            if (Groups.Count == 0)
            {
                return new FormElement[0];
            }

            return Groups
                .Select(group => group.Rows).SelectMany(list => list)
                .Select(row => row.Columns).SelectMany(list => list)
                .Select(column => column.Element);
        }

        private IEnumerable<FormField> Fields()
        {
            return Elements()
                .Select(element => element as FormField)
                .Where(field => field != null);
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

        public List<FormGroup> Groups { get; set; }
        public static readonly string DefaultName = "Default";
        public static readonly string DefaultTitle = "Default";
        public static Form EmptyForm => new Form( DefaultName, DefaultTitle, new FormGroup[0]);
        #endregion

        #region Results

        private IEnumerable<FieldResult> GetResults()
        {
            return Fields().Select(field => field.GetResult());
        }

        public FormResult GetResult()
        {
            return new FormResult(this, GetResults());
        }

        #endregion

        #region Json

        public static Form FromJson(string input)
        {
            return JsonConvert.DeserializeObject<Form>(input);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        #endregion
    }
}