using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.Interfaces;
using Aptacode.Forms.Shared.Interfaces.Composite;

namespace Aptacode.Forms.Shared.ViewModels
{
    public static class FormElementViewModelExtensions
    {
        public static IEnumerable<IFormElementViewModel> GetDescendants(this IFormElementViewModel element)
        {
            var elements = new List<IFormElementViewModel> {element};

            if (element is ICompositeElementViewModel compositeElement)
                elements.AddRange(compositeElement.Children.SelectMany(GetDescendants));

            return elements;
        }
    }
}