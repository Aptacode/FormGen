using System.Collections.Generic;
using System.ComponentModel;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.Results;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Fields
{
    public abstract class FormFieldViewModel : FormElementViewModel, IFieldViewModel, IDataErrorInfo
    {
        private bool _isValid;
        private string _validationMessage;

        protected FormFieldViewModel(FormFieldModel fieldModel) : base(fieldModel)
        {
            FieldModel = fieldModel;
        }

        public string ValidationMessage
        {
            get => _validationMessage;
            protected set => SetProperty(ref _validationMessage, value);
        }

        public bool IsValid
        {
            get => _isValid = CheckIsValid();
            protected set => SetProperty(ref _isValid, value);
        }

        public string this[string columnName] => GetValidationMessage();

        public string Error { get; }

        public void UpdateValidationMessage()
        {
            IsValid = CheckIsValid();
            ValidationMessage = GetValidationMessage();
        }

        public abstract bool CheckIsValid();

        public abstract IEnumerable<string> GetValidationMessages();

        public string GetValidationMessage() => string.Join("\n", GetValidationMessages());

        public abstract FieldResult GetResult();

        #region Properties

        private FormFieldModel _fieldModel;

        public FormFieldModel FieldModel
        {
            get => _fieldModel;
            set
            {
                SetProperty(ref _fieldModel, value);
                ElementModel = _fieldModel;
            }
        }

        #endregion
    }
}