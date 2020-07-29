﻿using Aptacode.Forms.Shared.Models.Elements.Composite;

namespace Aptacode.Forms.Shared.Builders.Elements.Composite
{
    public class LinearLayoutBuilder : CompositeBuilder<LinearLayoutElement, LinearLayoutBuilder>
    {
        public override LinearLayoutElement Build()
        {
            var newElement = new LinearLayoutElement
            {
                Id = Id,
                Name = Name,
                Children = Children,
                HorizontalAlignment = HorizontalAlignment,
                VerticalAlignment = VerticalAlignment,
                LayoutMode = LayoutMode,
                LayoutOrientation = LayoutOrientation
            };

            Reset();

            return newElement;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}