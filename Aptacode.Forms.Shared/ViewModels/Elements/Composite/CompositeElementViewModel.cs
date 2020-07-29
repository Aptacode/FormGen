using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.Interfaces;
using Aptacode.Forms.Shared.Interfaces.Composite;
using Aptacode.Forms.Shared.Models.Elements.Composite;
using Aptacode.Forms.Shared.ViewModels.Factories;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Composite
{
    public abstract class CompositeElementViewModel<TElement> : FormElementViewModel<TElement>,
        ICompositeElementViewModel where TElement : CompositeElement, new()
    {
        protected CompositeElementViewModel(TElement model) : base(model)
        {
            Children = new ObservableCollection<IFormElementViewModel>(
                model.Children.Select(FormElementViewModelFactory.Create));
            Children.CollectionChanged += CollectionChanged;
            LayoutOrientation = model.LayoutOrientation;
            LayoutMode = model.LayoutMode;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Model.Children = Children.Select(child => child.Model);
        }

        #region Properties

        public ObservableCollection<IFormElementViewModel> Children { get; }

        private LayoutMode _layoutMode;

        public LayoutMode LayoutMode
        {
            get => _layoutMode;
            set
            {
                SetProperty(ref _layoutMode, value);
                Model.LayoutMode = _layoutMode;
            }
        }

        private LayoutOrientation _layoutOrientation;

        public LayoutOrientation LayoutOrientation
        {
            get => _layoutOrientation;
            set
            {
                SetProperty(ref _layoutOrientation, value);
                Model.LayoutOrientation = _layoutOrientation;
            }
        }

        CompositeElement ICompositeElementViewModel.Model => base.Model;

        #endregion
    }
}