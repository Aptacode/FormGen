using System;
using System.Linq.Expressions;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications
{
    public class ElementPropertyFormSpecification : PropertyValueSpecification<FormViewModel>
    {
        internal ElementPropertyFormSpecification() { }

        public ElementPropertyFormSpecification(string elementName, string propertyName, object propertyValue) : base(
            propertyName, propertyValue)
        {
            ElementName = elementName;
        }

        public string ElementName { get; set; }

        public override Expression<Func<FormViewModel, bool>> ToExpression() => input =>
            ValuesMatch(PropertyValue, GetValue(input[ElementName], PropertyName));
    }
}