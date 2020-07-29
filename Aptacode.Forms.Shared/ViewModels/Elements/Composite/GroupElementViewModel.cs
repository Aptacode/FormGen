using Aptacode.Forms.Shared.Interfaces.Composite;
using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Composite
{
    public class GroupElementViewModel : CompositeElementViewModel<GroupElement>, IGroupElementViewModel
    {
        public GroupElementViewModel(GroupElement model) : base(model)
        {
            Title = model.Title;
        }

        GroupElement IGroupElementViewModel.Model => base.Model;

        #region Properties

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                Model.Title = _title;
            }
        }

        #endregion
    }
}