using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class CheckElementViewModel : FieldElementViewModel<CheckElement>, ICheckElementViewModel
    {
        public CheckElementViewModel(CheckElement model) : base(model)
        {
            Content = model.Content;
            IsChecked = model.DefaultValue;
            DefaultIsChecked = model.DefaultValue;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldElementResult GetResult()
        {
            return new CheckElementResult(Name, IsChecked);
        }

        #region Properties

        CheckElement ICheckElementViewModel.Model => base.Model;

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                SetProperty(ref _isChecked, value);

                TriggerEvent(new CheckElementChangedEvent(DateTime.Now, Name, value));
                UpdateValidationMessage();
            }
        }

        private bool _defaultIsChecked;

        public bool DefaultIsChecked
        {
            get => _defaultIsChecked;
            set
            {
                SetProperty(ref _defaultIsChecked, value);
                Model.DefaultValue = _defaultIsChecked;
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                Model.Content = _content;
            }
        }

        #endregion
    }
}