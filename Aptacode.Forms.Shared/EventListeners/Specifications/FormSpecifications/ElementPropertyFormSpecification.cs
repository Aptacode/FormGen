using System;
using System.Linq.Expressions;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications
{
    public class ElementPropertyFormSpecification : PropertyValueSpecification<FormViewModel>
    {
        public ElementPropertyFormSpecification(string elementName, string propertyName, object propertyValue) : base(
            propertyName, propertyValue)
        {
            ElementName = elementName;
        }

        public string ElementName { get; set; }

        public override bool Interpret(FormViewModel context)
        {
            return ValuesMatch(PropertyValue, GetValue(context[ElementName], PropertyName));
        }
    }
}