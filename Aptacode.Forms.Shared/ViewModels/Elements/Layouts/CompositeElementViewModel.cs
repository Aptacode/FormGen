using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Factories;
using Aptacode.Forms.Shared.ViewModels.Interfaces;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public abstract class CompositeElementViewModel<TElement> : FormElementViewModel<TElement>,
        ICompositeElementViewModel where TElement : CompositeElement, new()
    {
        protected CompositeElementViewModel(TElement model) : base(model)
        {
            Children = new ObservableCollection<IFormElementViewModel>(
                model.Children.Select(FormElementViewModelFactory.Create));
            Children.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Model.Children = Children.Select(child => child.Model);
        }

        #region Properties

        public ObservableCollection<IFormElementViewModel> Children { get; }

        CompositeElement ICompositeElementViewModel.Model => base.Model;

        #endregion
    }
}