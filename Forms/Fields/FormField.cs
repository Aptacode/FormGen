﻿using System.Collections.Generic;
using Aptacode.Forms.Fields.ValidationRules;
using Aptacode.Forms.Results;

namespace Aptacode.Forms.Fields
{
    public abstract class FormField : FormElement
    {
        public FormField()
        {
        }

        public FormField(string type, string name, FieldLabelPosition labelPosition, string label, IEnumerable<ValidationRule> rules) : base(
            nameof(FormField), name)
        {
            LabelPosition = labelPosition;
            Label = label;
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

        public string Label { get; set; }
        public FieldLabelPosition LabelPosition { get; set; }
    }
}