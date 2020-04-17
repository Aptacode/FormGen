using Aptacode.Forms.Fields;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormElementViewModel : BindableBase
    {
        public FormElement Element { get; }

        public FormElementViewModel(FormElement element)
        {
            Element = element;
        }
    }
}