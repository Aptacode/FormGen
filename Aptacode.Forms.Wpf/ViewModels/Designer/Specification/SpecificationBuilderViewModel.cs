using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.CSharp.Common.Utilities.Extensions;
using Aptacode.CSharp.Common.Utilities.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification
{

    public static class SpecificationExtensions
    {
        public static IEnumerable<Specification<T>> ToList<T>(this Specification<T> specification)
        {
            var specificationList = new List<Specification<T>> {specification};

            switch (specification)
            {
                case AndSpecification<T> andSpecification:
                    specificationList.AddRange(andSpecification.Left.ToList());
                    specificationList.AddRange(andSpecification.Right.ToList());
                    break;
                case OrSpecification<T> orSpecification:
                    specificationList.AddRange(orSpecification.Left.ToList());
                    specificationList.AddRange(orSpecification.Right.ToList());
                    break;
                case NotSpecification<T> notSpecification:
                    specificationList.AddRange(notSpecification.Specification.ToList());
                    break;
            }

            return specificationList;
        }
    }

    public class SpecificationBuilderViewModel<T> : BindableBase
    {

        public SpecificationBuilderViewModel(IEnumerable<(string, Type)> specificationViewModelTypes)
        {
            Specifications = new ObservableCollection<SpecificationViewModel<T>>();
            foreach (var specificationViewModelType in specificationViewModelTypes)
            {
                _specificationViewModelTypes.Add(specificationViewModelType.Item1, specificationViewModelType.Item2);
            }

            AllSpecificationTypes = new ObservableCollection<string>(_specificationViewModelTypes.Keys);
            SelectedOperation = "All";
        }

        #region Methods

        public Specification<T> BuildSpecification()
        {
            if (!Specifications.Any())
                return new NullSpecification<T>();


            Specification<T> outputSpecification = null;
            foreach (var specification in Specifications.Select(vm => vm.BuildSpecification()))
            {
                if (outputSpecification == null)
                {
                    outputSpecification = specification;
                }
                else if (SelectedOperation == "All")
                {
                    outputSpecification = outputSpecification.And(specification);
                }
                else
                {
                    outputSpecification = outputSpecification.Or(specification);
                }
            }

            return outputSpecification;
        }
        public void Load(Specification<T> specification)
        {
            Specifications.Clear();

            var childSpecifications = specification.ToList();

            SelectedOperation = childSpecifications.OfType<AndSpecification<T>>().Any() ? "All" : "Any";

            foreach (var childSpecification in childSpecifications)
            {
                if (childSpecification is AndSpecification<T> || childSpecification is OrSpecification<T> ||
                    childSpecification is NotSpecification<T>)
                {
                    continue;
                }

                var specificationTypeName = GetNameWithoutGenericArity(childSpecification.GetType());
                if (_specificationViewModelTypes.TryGetValue(specificationTypeName,
                    out var specificationViewModelType))
                {
                    if (Activator.CreateInstance(specificationViewModelType) is SpecificationViewModel<T> specificationViewModel)
                    {
                        specificationViewModel.LoadParameters(childSpecification);
                        specificationViewModel.OnSpecificationChanged += SpecificationViewModel_OnSpecificationChanged;
                        Specifications.Add(specificationViewModel);
                    }
                }
            }
        }

        private void SpecificationViewModel_OnSpecificationChanged(object sender, EventArgs e)
        {
            OnSpecificationChanged?.Invoke(this, EventArgs.Empty);
        }

        public string GetNameWithoutGenericArity(Type t)
        {
            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        #endregion

        #region Events

        public event EventHandler OnSpecificationChanged;

        #endregion

        #region Properties
        public ObservableCollection<SpecificationViewModel<T>> Specifications { get; set; }
        public ObservableCollection<string> AllSpecificationTypes { get; set; }

        private readonly Dictionary<string, Type> _specificationViewModelTypes = new Dictionary<string, Type>();
        public string SelectedOperation { get; set; }
        public string SelectedSpecificationType { get; set; } = string.Empty;

        #endregion

        #region Commands

        private DelegateCommand<SpecificationViewModel<T>> _removeCommand;

        public DelegateCommand<SpecificationViewModel<T>> RemoveCommand =>
            _removeCommand ??= new DelegateCommand<SpecificationViewModel<T>>((specification) =>
            {
                Specifications.Remove(specification);
                OnSpecificationChanged?.Invoke(this, EventArgs.Empty);
            });


        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand((_) =>
            {
                if (!_specificationViewModelTypes.TryGetValue(SelectedSpecificationType,
                    out var specificationViewModelType))
                {
                    return;
                }

                if (!(Activator.CreateInstance(specificationViewModelType) is SpecificationViewModel<T>
                    specificationViewModel))
                {
                    return;
                }

                specificationViewModel.OnSpecificationChanged += SpecificationViewModel_OnSpecificationChanged;
                Specifications.Add(specificationViewModel);
                OnSpecificationChanged?.Invoke(this, EventArgs.Empty);


            });

        #endregion

    }
}
