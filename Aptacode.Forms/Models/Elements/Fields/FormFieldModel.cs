using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Aptacode.Forms.Shared.Models.Elements.Fields
{
    public abstract class FormFieldModel : FormElementModel
    {
        internal FormFieldModel() { }
        protected FormFieldModel(string type, string name, ElementLabel label) : base(
           type, name, label)
        {

        }
    }

    public abstract class FormFieldModel<TFieldViewModel> : FormFieldModel where TFieldViewModel : IFieldViewModel
    {
        internal FormFieldModel() { }
         protected FormFieldModel(string type, string name, ElementLabel label, IEnumerable<ValidationRule<TFieldViewModel>> rules) : base(
            type, name, label)
        {
            Rules = rules?.ToList() ?? new List<ValidationRule<TFieldViewModel>>();
        }

        public IEnumerable<ValidationRule<TFieldViewModel>> Rules { get; internal set; }
    }
}