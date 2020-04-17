using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using Aptacode.Forms.Wpf.ViewModels;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private FormViewModel _formViewModel;

        public MainWindowViewModel()
        {
            var nameForm = new Form("form1", "Test Form",
                new[]
                {
                    new FormRow(new FormHtmlContent("Paragraph",
                        "<h1><em>This is a test</em></h1>\r\n<p>a</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">poops od&nbsp;&nbsp; </span></p>", LabelPosition.AboveElement, "HTML Content")),
                    new FormRow(new TextField("firstName", LabelPosition.AboveElement, "First Name",
                        new ValidationRule<TextField>[]
                        {
                            new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2)
                        })),
                    new FormRow(new TextField("lasName", LabelPosition.AboveElement, "Last Name",
                        new ValidationRule<TextField>[0])),

                    new FormRow(new CheckBoxField("receiveEmail", LabelPosition.AboveElement, "Do you want to receive emails",
                        new ValidationRule<CheckBoxField>[0], false)),

                        new FormRow(new ComboBoxField("yearsOfExperience", LabelPosition.AboveElement, "Years of experiance",
                        new ValidationRule<ComboBoxField>[0], new []{ "0-1", "1-5", "5+"}, "0-1")),
                });

            FormViewModel = new FormViewModel(nameForm);
        }

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }
    }
}