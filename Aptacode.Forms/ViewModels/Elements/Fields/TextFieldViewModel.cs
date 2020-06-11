using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.Results;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.ViewModels.Events;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Fields
{
    public class TextFieldViewModel : FormFieldViewModel, ITextFieldViewModel
    {
        public TextFieldViewModel(string name, LabelPosition labelPosition, string label,
            params ValidationRule<ITextFieldViewModel>[] rules) : this(new TextFieldModel(name, labelPosition, label,
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
                Content = _model?.DefaultContent;
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
                TriggerEvent(new TextFieldChangedEventArgs(this, Model, oldValue, value));
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
                Model.DefaultContent = _defaultContent;
            }
        }

        public override bool CheckIsValid()
        {
            return Model.Rules.All(rule => rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return Model.Rules.Select(rule => rule.GetMessage(this));
        }

        public override FieldResult GetResult() => new TextFieldResult(this, Model);

        #endregion
    }
}