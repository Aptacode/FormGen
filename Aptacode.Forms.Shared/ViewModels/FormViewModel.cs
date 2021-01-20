using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Interfaces;
using Aptacode.Forms.Shared.Interfaces.Composite;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Factories;

namespace Aptacode.Forms.Shared.ViewModels
{
    public class FormViewModel : BindableBase
    {
        public ObservableCollection<FormElementEvent> EventLog = new();

        public FormViewModel(Form model)
        {
            Model = model;
            Name = Model.Name;
            Title = Model.Title;
            EventListeners.AddRange(Model.EventListeners);
            RootElement = FormElementViewModelFactory.CreateComposite(Model.RootElement);
            EventListeners.CollectionChanged += EventListenersOnCollectionChanged;
        }

        public ObservableCollection<EventListener> EventListeners { get; set; } =
            new();

        public event EventHandler<(EventListener, FormElementEvent)> OnTriggered;

        #region Elements

        public IEnumerable<IFormElementViewModel> Elements { get; private set; }
        private IEnumerable<IFieldViewModel> Fields => Elements.OfType<IFieldViewModel>();

        public IFieldViewModel this[string elementName] =>
            Elements.FirstOrDefault(e => e.Name == elementName) as IFieldViewModel;

        public ICompositeElementViewModel GetParent(IFormElementViewModel element)
        {
            return RootElement.GetDescendants().OfType<ICompositeElementViewModel>()
                .FirstOrDefault(compositeElement => compositeElement.Children.Contains(element));
        }

        #endregion

        #region Validation

        public bool IsValid => Fields.All(field => field.IsValid);

        public IEnumerable<(IFieldViewModel, IEnumerable<ValidationResult>)> ValidationResults =>
            Fields.Select(field => (field, field.Validate()));

        public string ValidationMessage =>
            string.Join("\n",
                Fields.SelectMany(field => field.Validate()).Where(result => result.HasMessage)
                    .Select(result => result.Message));

        #endregion

        #region Events

        private void SubscribeToFormEvents()
        {
            foreach (var element in Elements)
            {
                element.OnFormEvent -= OnFormEvent;
                element.OnFormEvent += OnFormEvent;
            }
        }

        private void OnFormEvent(object sender, FormElementEvent e)
        {
            Handle(e);
        }

        private void EventListenersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Model.EventListeners = EventListeners.ToList();
        }

        public void Handle(FormElementEvent formEvent)
        {
            EventLog.Add(formEvent);
            foreach (var eventListener in EventListeners)
            {
                if (eventListener.IsSatisfiedBy(this, formEvent))
                {
                    OnTriggered?.Invoke(this, (eventListener, formEvent));
                }
            }
        }

        #endregion

        #region Results

        private IEnumerable<FieldElementResult> FieldResults => Fields.Select(field => field.GetResult());

        public FormResult Results => new(FieldResults);

        #endregion

        #region Properties

        public Form Model { get; }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                Model.Name = _name;
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                Model.Title = _title;
            }
        }

        private ICompositeElementViewModel _rootElement;

        public ICompositeElementViewModel RootElement
        {
            get => _rootElement;
            set
            {
                SetProperty(ref _rootElement, value);
                Elements = RootElement.GetDescendants();
                SubscribeToFormEvents();

                Model.RootElement = _rootElement.Model;
            }
        }

        #endregion
    }
}