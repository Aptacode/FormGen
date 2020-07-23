using System;
using System.Collections.Generic;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;
using Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications;
using Aptacode.Forms.Shared.ViewModels;
using Aptacode.Forms.Wpf.ViewModels.Designer.Specification;
using Aptacode.Forms.Wpf.ViewModels.Designer.Specification.Conditions;
using Aptacode.Forms.Wpf.ViewModels.Designer.Specification.Events;

namespace Aptacode.Forms.Wpf.ViewModels.Designer
{
    public class EventListenerEditorViewModel : BindableBase
    {
        public EventListenerEditorViewModel()
        {
            EventTriggerSpecificationBuilder = new SpecificationBuilderViewModel<FormElementEvent>(
                new List<(string, Type)>
                {
                    (nameof(ElementNameEventSpecification), typeof(ElementNameEventSpecificationViewModel)),
                    (nameof(IdentitySpecification<FormElementEvent>),
                        typeof(IdentitySpecificationViewModel<FormElementEvent>)),
                    (nameof(PropertyValueEventSpecification), typeof(PropertyValueEventSpecificationViewModel)),
                    (nameof(TypeNameEventSpecification), typeof(TypeNameEventSpecificationViewModel))
                });

            FormConditionSpecificationBuilder = new SpecificationBuilderViewModel<FormViewModel>(
                new List<(string, Type)>
                {
                    (nameof(IdentitySpecification<FormViewModel>),
                        typeof(IdentitySpecificationViewModel<FormViewModel>)),
                    (nameof(ElementPropertyFormSpecification), typeof(ElementPropertyFormSpecificationViewModel))
                });

            EventTriggerSpecificationBuilder.OnSpecificationChanged += SpecificationBuilderChanged;
            FormConditionSpecificationBuilder.OnSpecificationChanged += SpecificationBuilderChanged;
        }

        private void SpecificationBuilderChanged(object sender, EventArgs e)
        {
            SelectedEventListener.EventTrigger = EventTriggerSpecificationBuilder.BuildSpecification();
            SelectedEventListener.FormCondition = FormConditionSpecificationBuilder.BuildSpecification();
        }


        #region Properties

        private FormViewModel _formViewModel;

        public FormViewModel FormViewModel
        {
            get => _formViewModel;
            set => SetProperty(ref _formViewModel, value);
        }

        private EventListener _selectedEventListener;

        public EventListener SelectedEventListener
        {
            get => _selectedEventListener;
            set
            {
                SetProperty(ref _selectedEventListener, value);

                EventTriggerSpecificationBuilder.Load(SelectedEventListener.EventTrigger);
                FormConditionSpecificationBuilder.Load(SelectedEventListener.FormCondition);
            }
        }


        private SpecificationBuilderViewModel<FormElementEvent> _eventTriggerSpecificationBuilder;

        public SpecificationBuilderViewModel<FormElementEvent> EventTriggerSpecificationBuilder
        {
            get => _eventTriggerSpecificationBuilder;
            set => SetProperty(ref _eventTriggerSpecificationBuilder, value);
        }

        private SpecificationBuilderViewModel<FormViewModel> _formConditionSpecificationBuilder;

        public SpecificationBuilderViewModel<FormViewModel> FormConditionSpecificationBuilder
        {
            get => _formConditionSpecificationBuilder;
            set => SetProperty(ref _formConditionSpecificationBuilder, value);
        }

        #endregion

        #region Commands

        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(_ =>
            {
                FormViewModel.EventListeners.Add(new EventListener("New Event Listener",
                    new IdentitySpecification<FormElementEvent>(), new IdentitySpecification<FormViewModel>()));
            });

        private DelegateCommand<EventListener> _removeCommand;

        public DelegateCommand<EventListener> RemoveCommand =>
            _removeCommand ??= new DelegateCommand<EventListener>(parameter =>
            {
                FormViewModel.EventListeners.Remove(parameter);
            });

        #endregion
    }
}