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
        public ObservableCollection<EventListener> EventListeners = new ObservableCollection<EventListener>();
        public ObservableCollection<FormElementEvent> EventLog = new ObservableCollection<FormElementEvent>();

        public FormViewModel(Form model)
        {
            Model = model;
            EventListeners.CollectionChanged += EventListenersOnCollectionChanged;
        }

        public event EventHandler<(EventListener, FormElementEvent)> OnTriggered;

        #region Elements
        public IEnumerable<FormElementViewModel> Elements { get; private set; }
        private IEnumerable<FieldElementViewModel> Fields => Elements.OfType<FieldElementViewModel>();

        public TFieldViewModel GetElement<TFieldViewModel>(string elementName)
            where TFieldViewModel : FormElementViewModel =>
            this[elementName] as TFieldViewModel;

        public FormElementViewModel this[string elementName] => Elements.FirstOrDefault(e => e.Name == elementName);

        #endregion

        #region Validation

        public bool IsValid => Fields.All(field => field.IsValid);

        public IEnumerable<(FieldElementViewModel, IEnumerable<ValidationResult>)> ValidationResults =>
            Fields.Select(field => (field, field.Validate()));

        public string ValidationMessage =>
            string.Join("\n",
                ValidationResults.Select(m =>
                    $"{m.Item1.Name} \n {string.Join("\n", m.Item2.Where(result => result.HasMessage).Select(result => result.Message))}"));

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

        #endregion

        #region Results

        private IEnumerable<FieldElementResult> FieldResults => Fields.Select(field => field.GetResult());

        public FormResult Results => new FormResult(FieldResults);

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
                Elements = RootElement.GetDescendants();
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