using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;


namespace Aptacode.Forms.Shared.ViewModels
{
    public static class FormElementViewModelExtensions
    {
        public static IEnumerable<FormElementViewModel> GetDescendants(this FormElementViewModel element)
        {
            var elements = new List<FormElementViewModel> {element};

            if (element is CompositeElementViewModel compositeElement)
            {
                elements.AddRange(compositeElement.Children.SelectMany(GetDescendants));
            }

            return elements;
        }
    }
}