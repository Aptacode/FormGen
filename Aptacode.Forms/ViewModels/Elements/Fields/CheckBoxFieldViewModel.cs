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
    public class CheckBoxFieldViewModel : FormFieldViewModel, ICheckBoxFieldViewModel
    {
        public CheckBoxFieldViewModel(string name, ElementLabel label, string content,
            bool defaultIsChecked, params ValidationRule<ICheckBoxFieldViewModel>[] rules) : this(
            new CheckBoxFieldModel(name, label, content, defaultIsChecked,
                rules?.ToList() ?? new List<ValidationRule<ICheckBoxFieldViewModel>>())) { }

        public CheckBoxFieldViewModel(CheckBoxFieldModel model) : base(model)
        {
            Model = model;
        }
        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }
        public override FieldResult GetResult() => new CheckBoxFieldResult(this, Model);

        #region Properties

        private CheckBoxFieldModel _model;

        public CheckBoxFieldModel Model
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

                TriggerEvent(new CheckBoxFieldChangedEventArgs(DateTime.Now, this, Model, value));
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