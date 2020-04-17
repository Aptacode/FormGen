using Aptacode.Forms.Fields;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public abstract class FormRowViewModel : BindableBase
    {
        public FormRow Row { get; }

        public FormRowViewModel(FormRow row)
        {
            Row = row;
        }
    }
}