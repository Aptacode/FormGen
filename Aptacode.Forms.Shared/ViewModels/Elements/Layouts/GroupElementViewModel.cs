using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Interfaces.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class GroupElementViewModel : CompositeElementViewModel<GroupElement>, IGroupElementViewModel
    {
        private string _title;

        public GroupElementViewModel(GroupElement model) : base(model)
        {
            Title = model.Title;
        }

        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                Model.Title = _title;
            }
        }

        GroupElement IGroupElementViewModel.Model => base.Model;
    }
}