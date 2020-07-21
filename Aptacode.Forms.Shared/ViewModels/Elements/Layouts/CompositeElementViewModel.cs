using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Factories;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public abstract class CompositeElementViewModel : FormElementViewModel
    {
        protected CompositeElementViewModel(CompositeElement model) : base(model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(CompositeElement));
            Children.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_model != null && !_swappingModel)
            {
                _model.Children = Children.Select(e => e.ElementModel);
            }
        }

        #region Properties

        private bool _swappingModel;

        private CompositeElement _model;

        public CompositeElement Model
        {
            get => _model;
            set
            {
                _swappingModel = true;
                SetProperty(ref _model, value);

                Name = Model?.Name;

                Children.Clear();
                if (_model != null)
                {
                    foreach (var group in _model?.Children.Select(FormElementViewModelFactory.Create))
                    {
                        Children.Add(group);
                    }
                }

                _swappingModel = false;
            }
        }

        public ObservableCollection<FormElementViewModel> Children { get; } =
            new ObservableCollection<FormElementViewModel>();

        #endregion

    }
}