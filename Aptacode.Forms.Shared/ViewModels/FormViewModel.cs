using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields;
using Aptacode.Forms.Shared.ViewModels.Elements.Layouts;
using Aptacode.Forms.Shared.ViewModels.Factories;

namespace Aptacode.Forms.Shared.ViewModels
{
    public class FormViewModel : BindableBase
    {
        public ObservableCollection<FormElementEvent> EventLog = new ObservableCollection<FormElementEvent>();
        public ObservableCollection<EventListener> EventListeners = new ObservableCollection<EventListener>();

        public event EventHandler<(EventListener, FormElementEvent)> OnTriggered;

        public FormViewModel(Form model)
        {
            Model = model;
            EventListeners.CollectionChanged += EventListenersOnCollectionChanged;
        }

        private void EventListenersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_model != null)
            {
                _model.EventListeners = EventListeners.ToList();
            }
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


        public bool IsValid => Fields().All(field => field.IsValid);

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            return Fields().Select(field => field.Validate())
                .SelectMany(list => list);
        }

        public IEnumerable<FormElementViewModel> GetDescendants(FormElementViewModel element)
        {
            var elements = new List<FormElementViewModel> {element};

            if (element is CompositeElementViewModel compositeElement)
            {
                elements.AddRange(compositeElement.Children.SelectMany(GetDescendants));
            }

            return elements;
        }

        public IEnumerable<FormElementViewModel> Elements() => GetDescendants(RootElement);

        private IEnumerable<FieldElementViewModel> Fields()
        {
            return Elements()
                .Select(element => element as FieldElementViewModel)
                .Where(field => field != null);
        }

        public string GetValidationMessage() => string.Join("\n", GetValidationResults());

        #region Events

        private void SubscribeToFormEvents()
        {
            foreach (var element in Elements())
            {
                element.OnFormEvent -= OnFormEvent;
                element.OnFormEvent += OnFormEvent;
            }
        }

        private void OnFormEvent(object sender, FormElementEvent e)
        {
            Handle(e);
        }

        #endregion

        #region Results

        private IEnumerable<FieldElementResult> GetResults()
        {
            return Fields().Select(field => field.GetResult());
        }

        public FormResult GetResult() => new FormResult(Model, GetResults());

        #endregion

        #region Properties

        private Form _model;

        public Form Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);

                Name = _model?.Name;
                Title = _model?.Title;
                EventListeners.Clear();

                if (_model != null)
                {
                    EventListeners.AddRange(_model?.EventListeners);
                    RootElement = FormElementViewModelFactory.CreateComposite(_model.RootElement);
                }
            }
        }

        public TFieldViewModel GetElement<TFieldViewModel>(string elementName)
            where TFieldViewModel : FormElementViewModel
        {
            return Elements().FirstOrDefault(e => e.Name.Equals(elementName)) as TFieldViewModel;
        }

        public FormElementViewModel GetElement(string elementName)
        {
            return Elements().FirstOrDefault(e => e.Name.Equals(elementName));
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                if (_model != null)
                {
                    _model.Name = _name;
                }
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                if (_model != null)
                {
                    _model.Title = _title;
                }
            }
        }

        private CompositeElementViewModel _rootElement;

        public CompositeElementViewModel RootElement
        {
            get => _rootElement;
            set
            {
                SetProperty(ref _rootElement, value);
                SubscribeToFormEvents();

                if (_model != null)
                {
                    _model.RootElement = _rootElement.Model;
                }
            }
        }

        #endregion
    }
}