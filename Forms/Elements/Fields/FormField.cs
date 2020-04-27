﻿using System.Collections.Generic;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Elements.Fields
{
    public abstract class FormField : FormElement
    {
        protected FormField()
        {
            ValidationRules = new List<ValidationRule>();
        }

        protected FormField(string type, string name, LabelPosition labelPosition, string label,
            IEnumerable<ValidationRule> rules) : base(
            type, name, labelPosition, label)
        {
            ValidationRules = rules;
        }

        public IEnumerable<ValidationRule> ValidationRules { get; set; }

        public abstract bool IsValid();

        public abstract IEnumerable<string> GetValidationMessages();

        public string GetValidationMessage()
        {
            return string.Join("\n", GetValidationMessages());
        }

        public abstract FieldResult GetResult();
    }
}