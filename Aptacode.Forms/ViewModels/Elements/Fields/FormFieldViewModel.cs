using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.Results;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Fields
{
    public abstract class FormFieldViewModel : FormElementViewModel, IFieldViewModel, IDataErrorInfo
    {
        protected FormFieldViewModel(FormFieldModel fieldModel) : base(fieldModel)
        {
            FieldModel = fieldModel;
        }
        
        public bool IsValid => Validate().All(result => result.Passed);

        public string this[string columnName] => GetValidationMessage();

        public string Error { get; }

        public void UpdateValidationMessage()
        {
            ValidationResults.Clear();
            ValidationResults.AddRange(Validate());
        }

        public abstract IEnumerable<ValidationResult> Validate();

        public ObservableCollection<ValidationResult> ValidationResults { get; set; } = new ObservableCollection<ValidationResult>();

        public string GetValidationMessage() => string.Join("\n", ValidationResults.Select(r => r.Message));

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