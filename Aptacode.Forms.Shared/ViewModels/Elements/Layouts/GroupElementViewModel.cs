using System.Security.AccessControl;
using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class GroupElementViewModel : CompositeElementViewModel
    {
        public GroupElementViewModel(GroupElement model) : base(model)
        {
            Model = model;
            Title = model.Title;
        }

        private GroupElement _model;

        public new GroupElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
                Title = _model?.Title;
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

    }
}