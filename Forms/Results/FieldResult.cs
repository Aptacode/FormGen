﻿using Aptacode.Forms.Fields;

namespace Aptacode.Forms.Results
{
    public abstract class FieldResult
    {
        protected FieldResult(FormField formField)
        {
            FormField = formField;
        }

        public FormField FormField { get; set; }
    }
}