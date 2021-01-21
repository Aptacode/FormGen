using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.Forms.Shared.Interfaces;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Factories;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls
{
    public class ListEditElementViewModel : FieldElementViewModel<ListEditElement>, IListEditElementViewModel
    {
        public ListEditElementViewModel(ListEditElement model) : base(model)
        {
            Items = new ObservableCollection<IFormElementViewModel>(Model.Values.Select(e => e.ToViewModel()));
            Items.CollectionChanged += Items_CollectionChanged;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return Model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldElementResult GetResult()
        {
            return null;
        }

        private void Items_CollectionChanged(object sender,
            NotifyCollectionChangedEventArgs e)
        {
            Model.Values = Items.Select(i => i.Model).ToList();
        }

        #region Properties

        public ObservableCollection<IFormElementViewModel> Items { get; set; }

        public void Add()
        {
            Items.Add(Model.CreateItem().ToViewModel());
        }

        public void Remove(IFormElementViewModel item)
        {
            Items.Remove(item);
        }
        #endregion
    }
}