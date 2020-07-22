using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields
{
    public class CheckElementViewModel : FieldElementViewModel, ICheckElementViewModel
    {
        public CheckElementViewModel(string name, ElementLabel label, ControlElement.VerticalAlignment alignment, string content,
            bool defaultIsChecked, params ValidationRule<ICheckElementViewModel>[] rules) : this(
            new CheckElement(name, label, alignment, content, defaultIsChecked,
                rules?.ToList() ?? new List<ValidationRule<ICheckElementViewModel>>())) { }

        public CheckElementViewModel(CheckElement model) : base(model)
        {
            Model = model;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldElementResult GetResult() => new CheckElementResult(Name, IsChecked);

        #region Properties

        private CheckElement _model;

        public CheckElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                FieldModel = _model;
                Content = _model.Content;
                IsChecked = _model.DefaultIsChecked;
                DefaultIsChecked = _model.DefaultIsChecked;
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                SetProperty(ref _isChecked, value);
                if (Model == null)
                {
                    return;
                }

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
                if (Model != null)
                {
                    Model.DefaultIsChecked = _defaultIsChecked;
                }
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                SetProperty(ref _content, value);
                if (Model != null)
                {
                    _model.Content = _content;
                }
            }
        }

        #endregion
    }
}