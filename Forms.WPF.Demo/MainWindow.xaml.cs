using System.Windows;
using Aptacode.Forms.Elements;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;

namespace Aptacode.Forms.Wpf.Demo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var nameForm = new Form("form1", "Test Form",
                new[]
                {
                    new FormRow(new FormHtmlContent("Paragraph", "<p>This is a basic paragraph</p>")),
                    new FormRow(new TextField("firstName", FieldLabelPosition.AboveElement, "Firstname",
                        new ValidationRule<TextField>[]
                        {
                            new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2)
                        })),
                    new FormRow(new TextField("lasName", FieldLabelPosition.AboveElement, "LastName",
                        new ValidationRule<TextField>[0]))
                });
        }
    }
}