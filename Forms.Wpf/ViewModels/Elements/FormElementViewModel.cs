using Aptacode.Forms.Fields;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Elements
{
    public abstract class FormElementViewModel : BindableBase
    {
        protected FormElementViewModel(FormElement formElement)
        {
            FormElement = formElement;
        }

        public FormElement FormElement { get; }
    }
}