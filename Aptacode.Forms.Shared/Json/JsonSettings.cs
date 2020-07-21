using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.Conditions;
using Aptacode.Forms.Shared.EventListeners.Specifications.Event;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Models.Elements.Layouts;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;
using JsonSubTypes;
using Newtonsoft.Json;

namespace Aptacode.Forms.Shared.Json
{
    public static class JsonSerializerSettingsExtensions
    {
        public static JsonSerializerSettings AddElementConverter(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(FormElement), "Type") // type property is only defined here
                .RegisterSubtype(typeof(CompositeElement), nameof(CompositeElement))
                .RegisterSubtype(typeof(GroupElement), nameof(GroupElement))
                .RegisterSubtype(typeof(ColumnElement), nameof(ColumnElement))
                .RegisterSubtype(typeof(RowElement), nameof(RowElement))
                .RegisterSubtype(typeof(NullElement), nameof(NullElement))
                .RegisterSubtype(typeof(NullCompositeElement), nameof(NullCompositeElement))
                .RegisterSubtype(typeof(ControlElement), nameof(ControlElement))
                .RegisterSubtype(typeof(FieldElement), nameof(FieldElement))
                .RegisterSubtype(typeof(HtmlElement), nameof(HtmlElement))
                .RegisterSubtype(typeof(ButtonElement), nameof(ButtonElement))
                .RegisterSubtype(typeof(CheckElement), nameof(CheckElement))
                .RegisterSubtype(typeof(SelectElement), nameof(SelectElement))
                .RegisterSubtype(typeof(TextElement), nameof(TextElement))
                .SerializeDiscriminatorProperty() // ask to serialize the type property
                .Build());

            return settings;
        }

        public static JsonSerializerSettings AddValidatorConverter(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(Specification<IFieldViewModel>), "Type") // type property is only defined here
                .RegisterSubtype(typeof(CheckElement_IsChecked_Validator), nameof(CheckElement_IsChecked_Validator))
                .RegisterSubtype(typeof(CheckElement_IsNotChecked_Validator),
                    nameof(CheckElement_IsNotChecked_Validator))
                .RegisterSubtype(typeof(SelectElement_SelectionMade_Validator),
                    nameof(SelectElement_SelectionMade_Validator))
                .RegisterSubtype(typeof(TextElement_MaximunLength_Validator),
                    nameof(TextElement_MaximunLength_Validator))
                .RegisterSubtype(typeof(TextElement_MinimunLength_Validator),
                    nameof(TextElement_MinimunLength_Validator))
                .SerializeDiscriminatorProperty() // ask to serialize the type property
                .Build());

            return settings;
        }

        public static JsonSerializerSettings AddEventSpecificationConverter(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(Specification<FormElementEvent>), "Type") // type property is only defined here
                .RegisterSubtype(typeof(AndSpecification<FormElementEvent>), nameof(AndSpecification<FormElementEvent>))
                .RegisterSubtype(typeof(OrSpecification<FormElementEvent>), nameof(OrSpecification<FormElementEvent>))
                .RegisterSubtype(typeof(NotSpecification<FormElementEvent>), nameof(NotSpecification<FormElementEvent>))
                .RegisterSubtype(typeof(IdentitySpecification<FormElementEvent>),
                    nameof(IdentitySpecification<FormElementEvent>))
                .RegisterSubtype(typeof(EventElementNameSpecification), nameof(EventElementNameSpecification))
                .RegisterSubtype(typeof(EventTypeSpecification), nameof(EventTypeSpecification))
                .SerializeDiscriminatorProperty() // ask to serialize the type property
                .Build());
            return settings;
        }

        public static JsonSerializerSettings AddFormSpecificationConverter(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(Specification<FormViewModel>), "Type") // type property is only defined here
                .RegisterSubtype(typeof(AndSpecification<FormViewModel>), nameof(AndSpecification<FormViewModel>))
                .RegisterSubtype(typeof(OrSpecification<FormViewModel>), nameof(OrSpecification<FormViewModel>))
                .RegisterSubtype(typeof(NotSpecification<FormViewModel>), nameof(NotSpecification<FormViewModel>))
                .RegisterSubtype(typeof(IdentitySpecification<FormViewModel>),
                    nameof(IdentitySpecification<FormViewModel>))
                .RegisterSubtype(typeof(SelectElementSelectionCondition), nameof(SelectElementSelectionCondition))
                .SerializeDiscriminatorProperty() // ask to serialize the type property
                .Build());

            return settings;
        }

        public static JsonSerializerSettings AddEventConverter(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(FormElementEvent), "Type") // type property is only defined here
                .RegisterSubtype(typeof(ButtonElementEvent), nameof(ButtonElementEvent))
                .RegisterSubtype(typeof(ButtonElementClickedEvent), nameof(ButtonElementClickedEvent))
                .RegisterSubtype(typeof(CheckElementEvent), nameof(CheckElementEvent))
                .RegisterSubtype(typeof(CheckElementChangedEvent), nameof(CheckElementChangedEvent))
                .RegisterSubtype(typeof(SelectElementEvent), nameof(SelectElementEvent))
                .RegisterSubtype(typeof(SelectElementChangedEvent), nameof(SelectElementChangedEvent))
                .RegisterSubtype(typeof(TextElementEvent), nameof(TextElementEvent))
                .RegisterSubtype(typeof(TextElementChangedEvent), nameof(TextElementChangedEvent))

                .SerializeDiscriminatorProperty() // ask to serialize the type property
                .Build());

            return settings;
        }
    }
}