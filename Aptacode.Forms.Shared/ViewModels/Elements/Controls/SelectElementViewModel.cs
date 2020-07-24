using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Controls;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class SelectElementViewModel : FieldElementViewModel<SelectElement>, ISelectElementViewModel
    {
        public SelectElementViewModel(SelectElement model) : base(model)
        {
            Items = new ObservableCollection<string>(Model.Values);
            Items.CollectionChanged += Items_CollectionChanged;
            SelectedItem = DefaultSelectedItem = Model.DefaultValue;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldElementResult GetResult() => new SelectElementResult(Name, SelectedItem);

        private void Items_CollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            Model.Values = Items.ToList();
        }

        #region Properties

        public ObservableCollection<string> Items { get; set; }

        private string _defaultSelectedItem;

        public string DefaultSelectedItem
        {
            get => _defaultSelectedItem;
            set
            {
                SetProperty(ref _defaultSelectedItem, value);
                Model.DefaultValue = _defaultSelectedItem;
            }
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                TriggerEvent(new SelectElementChangedEvent(DateTime.Now, Name, value));
                UpdateValidationMessage();
            }
        }

        #endregion
    }
}