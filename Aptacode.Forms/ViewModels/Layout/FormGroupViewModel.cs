using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.Forms.Shared.Models.Layout;
using Aptacode.Forms.Shared.Mvvm;

namespace Aptacode.Forms.Shared.ViewModels.Layout
{
    public class FormGroupViewModel : BindableBase
    {
        public FormGroupViewModel(string label, params FormRowModel[] rows) : this(
            new FormGroupModel(label, rows?.ToList() ?? new List<FormRowModel>())) { }

        public FormGroupViewModel(FormGroupModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(FormGroupModel));
            Rows.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_model != null && !_swappingModel)
            {
                _model.Rows = Rows.Select(e => e.Model);
            }
        }

        #region Properties

        private bool _swappingModel;

        private FormGroupModel _model;

        public FormGroupModel Model
        {
            get => _model;
            set
            {
                _swappingModel = true;
                SetProperty(ref _model, value);

                Label = Model?.Label;

                Rows.Clear();
                if (_model != null)
                {
                    foreach (var group in _model?.Rows.Select(g => new FormRowViewModel(g)))
                    {
                        Rows.Add(group);
                    }
                }

                _swappingModel = false;
            }
        }

        private string _label;

        public string Label
        {
            get => _label;
            set
            {
                SetProperty(ref _label, value);
                if (Model != null)
                {
                    Model.Label = _label;
                }
            }
        }

        public ObservableCollection<FormRowViewModel> Rows { get; } = new ObservableCollection<FormRowViewModel>();

        #endregion
    }
}