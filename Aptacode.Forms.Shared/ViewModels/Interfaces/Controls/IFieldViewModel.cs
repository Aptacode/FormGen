using System.Collections.Generic;
using System.ComponentModel;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces.Controls
{
    public interface IFieldViewModel : IFormElementViewModel, IDataErrorInfo
    {
        IEnumerable<string> ValidationMessages { get; }
        bool IsValid { get; }

        new FieldElement Model { get; }
        IEnumerable<ValidationResult> Validate();
        FieldElementResult GetResult();
    }
}