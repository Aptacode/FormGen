﻿using System.Linq;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification.Conditions
{
    public class TypeNameEventSpecificationViewModel : SpecificationViewModel<FormElementEvent>
    {
        public TypeNameEventSpecificationViewModel() : base(nameof(TypeNameEventSpecification)) { }

        public override Specification<FormElementEvent> BuildSpecification()
        {
            var parameters = Parameters?.Split(',');
            var parameter1 = parameters?.ElementAt(0);
            return new TypeNameEventSpecification(parameter1);
        }


        public override void LoadParameters(Specification<FormElementEvent> specification)
        {
            if (specification is TypeNameEventSpecification spec)
            {
                Parameters = $"{spec?.EventType}";
            }
        }
    }
}