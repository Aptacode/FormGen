using Aptacode.Forms.Fields;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormFieldViewModel : FormElementViewModel
    {
        public FormField Field { get; }

        public FormFieldViewModel(FormField field) : base(field)
        {
            Field = field;
        }
    }
}