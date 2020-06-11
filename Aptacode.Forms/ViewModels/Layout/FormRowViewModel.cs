using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models.Layout;

namespace Aptacode.Forms.Shared.ViewModels.Layout
{
    public class FormRowViewModel : BindableBase
    {
        public FormRowViewModel(string name, int span, params FormColumnModel[] columns) : this(
            new FormRowModel(name, span, columns?.ToList() ?? new List<FormColumnModel>())) { }

        public FormRowViewModel(FormRowModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(FormRowModel));
            Columns.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_model != null && !_swappingModel)
            {
                _model.Columns = Columns.Select(e => e.Model);
            }
        }

        #region Properties

        private bool _swappingModel;

        private FormRowModel _model;

        public FormRowModel Model
        {
            get => _model;
            set
            {
                _swappingModel = true;
                SetProperty(ref _model, value);

                Name = Model?.Name;

                Columns.Clear();
                if (_model != null)
                {
                    foreach (var group in _model?.Columns.Select(g => new FormColumnViewModel(g)))
                    {
                        Columns.Add(group);
                    }
                }

                _swappingModel = false;
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                if (Model != null)
                {
                    Model.Name = _name;
                }
            }
        }

        public ObservableCollection<FormColumnViewModel> Columns { get; } =
            new ObservableCollection<FormColumnViewModel>();

        #endregion
    }
}