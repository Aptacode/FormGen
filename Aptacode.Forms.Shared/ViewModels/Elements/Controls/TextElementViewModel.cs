using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class TextElementViewModel : FieldElementViewModel<TextElement>, ITextElementViewModel
    {
        public TextElementViewModel(TextElement model) : base(model)
        {
            Content = DefaultContent = model.DefaultValue;
        }

        #region Properties

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                var oldValue = _content;
                SetProperty(ref _content, value);

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

                Model.DefaultValue = _defaultContent;
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