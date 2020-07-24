using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public abstract class FieldElementViewModel<TElement> : ControlElementViewModel<TElement>, IFieldViewModel
        where TElement : FieldElement, new()
    {
        protected FieldElementViewModel(TElement model) : base(model) { }

        public ObservableCollection<ValidationResult> ValidationResults { get; set; } =
            new ObservableCollection<ValidationResult>();


        public abstract FieldElementResult GetResult();
        FieldElement IFieldViewModel.Model => base.Model;

        #region IDataErrorInfo

        public bool IsValid => Validate().All(result => result.IsValid);

        public string this[string columnName] => string.Join("\n", ValidationMessages);

        public string Error { get; }

        public void UpdateValidationMessage()
        {
            var newValidationResults = Validate();
            if (ValidationResults.SequenceEqual(newValidationResults))
            {
                return;
            }

            ValidationResults.Clear();
            ValidationResults.AddRange(newValidationResults);
            TriggerEvent(new ValidationChangedEvent(DateTime.Now, Name, ValidationMessages));
        }

        public abstract IEnumerable<ValidationResult> Validate();

        public IEnumerable<string> ValidationMessages =>
            ValidationResults.Where(r => r.HasMessage).Select(r => r.Message);

        #endregion
    }
}