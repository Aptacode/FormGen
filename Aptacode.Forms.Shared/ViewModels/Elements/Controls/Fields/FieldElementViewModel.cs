using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields
{
    public abstract class FieldElementViewModel : ControlElementViewModel, IFieldViewModel, IDataErrorInfo
    {
        protected FieldElementViewModel(FieldElement fieldModel) : base(fieldModel)
        {
            FieldModel = fieldModel;
        }

        public bool IsValid => Validate().All(result => result.IsValid);

        public ObservableCollection<ValidationResult> ValidationResults { get; set; } =
            new ObservableCollection<ValidationResult>();

        public string this[string columnName] => GetValidationMessage();

        public string Error { get; }

        public void UpdateValidationMessage()
        {
            ValidationResults.Clear();
            ValidationResults.AddRange(Validate());
            TriggerEvent(new ValidationChangedEvent(DateTime.Now, Name, GetValidationErrors()));
        }

        public abstract IEnumerable<ValidationResult> Validate();

        public IEnumerable<string> GetValidationErrors() => ValidationResults.SelectMany(r => r.ErrorMessages);
        public string GetValidationMessage() => string.Join("\n", GetValidationErrors());

        public abstract FieldElementResult GetResult();

        #region Properties

        private FieldElement _fieldModel;

        public FieldElement FieldModel
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