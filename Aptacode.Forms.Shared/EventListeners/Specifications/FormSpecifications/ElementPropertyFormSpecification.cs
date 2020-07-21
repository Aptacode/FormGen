using System;
using System.Linq.Expressions;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements;

namespace Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications {
    public class ElementPropertyFormSpecification : Specification<FormViewModel>
    {
        public ElementPropertyFormSpecification(string elementName, string propertyName, object propertyValue)
        {
            ElementName = elementName;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public string ElementName { get; set; }
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }

        public override Expression<Func<FormViewModel, bool>> ToExpression() => vm =>
            PropertyValue.Equals(vm[ElementName].GetValue(PropertyName));
    }

    public static class FormElementViewModelExtensions
    {
        public static object GetValue(this FormElementViewModel element, string propertyName)
        {
            return element?.GetType().GetProperty(propertyName)?.GetValue(element);
        }
    }
}