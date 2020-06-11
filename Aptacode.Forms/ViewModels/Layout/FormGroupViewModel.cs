using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models.Layout;

namespace Aptacode.Forms.Shared.ViewModels.Layout
{
    public class FormGroupViewModel : BindableBase
    {
        public FormGroupViewModel(string name, string title, params FormRowModel[] rows) : this(
            new FormGroupModel(name, title, rows?.ToList() ?? new List<FormRowModel>())) { }

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

                Title = Model?.Title;

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

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                if (Model != null)
                {
                    Model.Title = _title;
                }
            }
        }

        public ObservableCollection<FormRowViewModel> Rows { get; } = new ObservableCollection<FormRowViewModel>();

        #endregion
    }
}