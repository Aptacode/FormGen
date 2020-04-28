using System.Collections.Generic;
using Aptacode.Forms.Elements.Fields;
using Aptacode.Forms.Elements.Fields.ValidationRules;
using Aptacode.Forms.Enums;
using NUnit.Framework;

namespace TestSuite
{
    [TestFixture]
    public class TextFieldMainConstructor
    {
        [SetUp]
        public void SetUp()
        {
            _testRulesList = new List<ValidationRule<TextField>>();
            _textField = new TextField(_testName, LabelPosition.AboveElement, _testLabel, _testRulesList);
        }

        private TextField _textField;

        private List<ValidationRule<TextField>> _testRulesList;
        private readonly string _testName = "test name";
        private readonly string _testLabel = "test label";

        [Test]
        public void TextField_IsValid_NoRulesShouldReturnTrue()
        {
            _testRulesList.Clear();
            var allRulesPass = _textField.IsValid();

            Assert.IsTrue(allRulesPass, "A TextField with no rules should be valid");
        }

        [Test]
        public void TextField_IsValid_SingleValidRuleShouldReturnTrue()
        {
            var test_content = "test content";

            _testRulesList.Clear();
            var _newRule = new TextFieldLengthValidationRule(EqualityOperator.EqualTo, test_content.Length);
            _testRulesList.Add(_newRule);

            _textField = new TextField(_testName, LabelPosition.AboveElement, _testLabel, _testRulesList);
            _textField.Content = test_content;

            var allRulesPass = _textField.IsValid();

            Assert.IsTrue(allRulesPass, "A TextField with one passing rule should be valid");
        }
    }
}