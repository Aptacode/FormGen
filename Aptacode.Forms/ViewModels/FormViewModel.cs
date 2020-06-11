using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements.Fields.Results;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Layout;
using Aptacode.Forms.Shared.ViewModels.Elements;
using Aptacode.Forms.Shared.ViewModels.Elements.Fields;
using Aptacode.Forms.Shared.ViewModels.Events;
using Aptacode.Forms.Shared.ViewModels.Layout;

namespace Aptacode.Forms.Shared.ViewModels
{
    public class FormViewModel : BindableBase
    {
        public FormViewModel(string name, string title, params FormGroupModel[] groups) : this(new FormModel(name,
            title, new List<FormGroupModel>(groups))) { }

        public FormViewModel(FormModel model)
        {
            Model = model;
            Groups.CollectionChanged += CollectionChanged;
        }

        public bool IsValid => Fields().All(field => field.IsValid);

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_model != null && !_swappingModel)
            {
                _model.Groups = Groups.Select(e => e.Model);
            }
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            return Fields().Select(field => field.Validate())
                .SelectMany(list => list);
        }

        private IEnumerable<FormElementViewModel> Elements()
        {
            return Groups
                .Select(group => group.Rows).SelectMany(list => list)
                .Select(row => row.Columns).SelectMany(list => list)
                .Select(column => column.FormElementViewModel);
        }

        private IEnumerable<FormFieldViewModel> Fields()
        {
            return Elements()
                .Select(element => element as FormFieldViewModel)
                .Where(field => field != null);
        }

        public string GetValidationMessage() => string.Join("\n", GetValidationResults());

        #region Events

        private void SubscribeToElementEvents()
        {
            foreach (var formField in Elements())
            {
                formField.OnFormEvent += FormField_OnFormEvent;
            }
        }

        public event EventHandler<FormEventArgs> OnFormEvent;

        private void FormField_OnFormEvent(object sender, FormElementEventArgs e)
        {
            OnFormEvent?.Invoke(this, e);
        }

        #endregion

        #region Results

        private IEnumerable<FieldResult> GetResults()
        {
            return Fields().Select(field => field.GetResult());
        }

        public FormResult GetResult() => new FormResult(Model, GetResults());

        #endregion

        #region Properties

        private bool _swappingModel;

        private FormModel _model;

        public FormModel Model
        {
            get => _model;
            set
            {
                _swappingModel = true;
                SetProperty(ref _model, value);

                Name = _model?.Name;
                Title = _model?.Title;

                Groups.Clear();
                if (_model != null)
                {
                    foreach (var group in _model?.Groups.Select(g => new FormGroupViewModel(g)))
                    {
                        Groups.Add(group);
                    }

                    SubscribeToElementEvents();
                }

                _swappingModel = false;
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

        public ObservableCollection<FormGroupViewModel> Groups { get; } =
            new ObservableCollection<FormGroupViewModel>();

        #endregion
    }
}