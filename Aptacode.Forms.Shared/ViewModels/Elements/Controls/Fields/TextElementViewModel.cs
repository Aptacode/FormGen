using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields
{
    public class TextElementViewModel : FieldElementViewModel, ITextElementViewModel
    {
        public TextElementViewModel(TextElement model) : base(model)
        {
            Model = model;
        }

        #region Properties

        private TextElement _model;

        public TextElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                DefaultContent = _model?.DefaultValue;
                Content = _model?.DefaultValue;
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

                if (oldValue == value)
                {
                    return;
                }

                TriggerEvent(new TextElementChangedEvent(DateTime.Now, Name, oldValue, value));
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
                    Model.DefaultValue = _defaultContent;
                }
            }
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldElementResult GetResult() => new TextElementResult(Name, Content);

        #endregion
    }
}