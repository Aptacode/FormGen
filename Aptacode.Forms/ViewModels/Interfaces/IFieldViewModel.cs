using Aptacode.Forms.Shared.Models.Elements;

namespace Aptacode.Forms.Shared.ViewModels.Interfaces
{
    public interface IFieldViewModel
    {
        string Name { get; set; }
        ElementLabel Label { get; set; }

    }
}