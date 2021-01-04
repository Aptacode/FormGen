using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Expressions;
using Aptacode.Expressions.Bool;
using Aptacode.Expressions.Bool.LogicalOperators;
using Aptacode.Expressions.Bool.LogicalOperators.Extensions;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification
{
    public static class SpecificationExtensions
    {
        public static IEnumerable<IExpression<bool,T>> ToList<T>(this IExpression<bool,T> specification)
        {
            var specificationList = new List<IExpression<bool,T>> {specification};

            switch (specification)
            {
                case And<T> andSpecification:
                    specificationList.AddRange(andSpecification.Lhs.ToList());
                    specificationList.AddRange(andSpecification.Rhs.ToList());
                    break;
                case Or<T> orSpecification:
                    specificationList.AddRange(orSpecification.Lhs.ToList());
                    specificationList.AddRange(orSpecification.Rhs.ToList());
                    break;
                case Not<T> notSpecification:
                    specificationList.AddRange(notSpecification.Expression.ToList());
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
            SelectedOperation = "Any";
        }

        #region Events

        public event EventHandler OnSpecificationChanged;

        #endregion

        #region Methods

        public IExpression<bool,T> BuildSpecification()
        {
            if (!Specifications.Any())
            {
                return new ConstantBool<T>(false);
            }


            IExpression<bool,T> outputSpecification = null;
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

        public void Clear()
        {
            Specifications.Clear();
        }

        public void Load(IExpression<bool,T> specification)
        {
            Specifications.Clear();

            var childSpecifications = specification.ToList();

            SelectedOperation = childSpecifications.OfType<And<T>>().Any() ? "All" : "Any";

            foreach (var childSpecification in childSpecifications)
            {
                if (childSpecification is And<T> || childSpecification is Or<T> ||
                    childSpecification is Not<T>)
                {
                    continue;
                }

                var specificationTypeName = GetNameWithoutGenericArity(childSpecification.GetType());
                if (_specificationViewModelTypes.TryGetValue(specificationTypeName,
                    out var specificationViewModelType))
                {
                    if (Activator.CreateInstance(specificationViewModelType) is SpecificationViewModel<T>
                        specificationViewModel)
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
            var name = t.Name;
            var index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

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
            _removeCommand ??= new DelegateCommand<SpecificationViewModel<T>>(specification =>
            {
                Specifications.Remove(specification);
                OnSpecificationChanged?.Invoke(this, EventArgs.Empty);
            });


        private DelegateCommand _createCommand;

        public DelegateCommand CreateCommand =>
            _createCommand ??= new DelegateCommand(_ =>
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