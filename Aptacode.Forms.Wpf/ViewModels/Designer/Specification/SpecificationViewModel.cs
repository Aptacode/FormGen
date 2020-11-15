using System;
using Aptacode.CSharp.Common.Utilities.Mvvm;
using Aptacode.Expressions.Bool;

namespace Aptacode.Forms.Wpf.ViewModels.Designer.Specification
{
    public abstract class SpecificationViewModel<T> : BindableBase
    {
        protected SpecificationViewModel(string type)
        {
            Type = type;
        }

        #region Events

        public event EventHandler OnSpecificationChanged;

        #endregion


        public abstract void LoadParameters(IBooleanExpression<T> specification);

        public abstract IBooleanExpression<T> BuildSpecification();

        #region Properties

        public string Type { get; set; }

        public string _parameters;

        public string Parameters
        {
            get => _parameters;
            set
            {
                SetProperty(ref _parameters, value);
                OnSpecificationChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}