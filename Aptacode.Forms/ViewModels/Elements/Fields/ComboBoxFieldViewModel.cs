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
    public class ComboBoxFieldViewModel : FormFieldViewModel, IComboBoxFieldViewModel
    {
        public ComboBoxFieldViewModel(string name, LabelPosition labelPosition, string label, IEnumerable<string> items,
            params ValidationRule<IComboBoxFieldViewModel>[] rules) : this(new ComboBoxFieldModel(name, labelPosition,
            label, rules?.ToList() ?? new List<ValidationRule<IComboBoxFieldViewModel>>(), items)) { }

        public ComboBoxFieldViewModel(ComboBoxFieldModel model) : base(model)
        {
            Model = model;
        }

        public override bool CheckIsValid()
        {
            return Model.Rules.All(rule => rule.Passed(this));
        }

        public override IEnumerable<string> GetValidationMessages()
        {
            return Model.Rules.Select(rule => rule.GetMessage(this));
        }

        public override FieldResult GetResult() => new ComboBoxFieldResult(this, Model);

        #region Properties

        private ComboBoxFieldModel _model;

        public ComboBoxFieldModel Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                FieldModel = _model;
                Items.Clear();

                Items.AddRange(_model.Items);
                SelectedItem = _model.DefaultSelectedItem;
                DefaultSelectedItem = _model.DefaultSelectedItem;
            }
        }

        public List<string> Items { get; set; } = new List<string>();

        private string _defaultSelectedItem;

        public string DefaultSelectedItem
        {
            get => _defaultSelectedItem;
            set
            {
                SetProperty(ref _defaultSelectedItem, value);
                Model.DefaultSelectedItem = _defaultSelectedItem;
            }
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                TriggerEvent(new ComboBoxFieldChangedEventArgs(this, Model, value));
                UpdateValidationMessage();
            }
        }

        #endregion
    }
}