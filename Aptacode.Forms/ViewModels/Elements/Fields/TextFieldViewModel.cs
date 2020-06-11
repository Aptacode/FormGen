using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.Results;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Events;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Fields
{
    public class TextFieldViewModel : FormFieldViewModel, ITextFieldViewModel
    {
        public TextFieldViewModel(string name, ElementLabel label, string defaultContent,
            params ValidationRule<ITextFieldViewModel>[] rules) : this(new TextFieldModel(name, label, defaultContent,
            rules?.ToList() ?? new List<ValidationRule<ITextFieldViewModel>>())) { }

        public TextFieldViewModel(TextFieldModel model) : base(model)
        {
            Model = model;
        }

        #region Properties

        private TextFieldModel _model;

        public TextFieldModel Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                FieldModel = _model;
                DefaultContent = _model?.DefaultContent;
                Content = string.Empty;
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                var oldValue = _content;
                SetProperty(ref _content, value);
                if (Model == null)
                {
                    return;
                }

                TriggerEvent(new TextFieldChangedEventArgs(DateTime.Now, this, Model, oldValue, value));
                UpdateValidationMessage();
            }
        }

        private string _defaultContent;

        public string DefaultContent
        {
            get => _defaultContent;
            set
            {
                SetProperty(ref _defaultContent, value);
                if (Model != null)
                {
                    Model.DefaultContent = _defaultContent;
                }
            }
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldResult GetResult() => new TextFieldResult(this, Model);

        #endregion
    }
}