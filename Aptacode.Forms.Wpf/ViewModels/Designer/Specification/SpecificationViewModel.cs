using System;
using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.CSharp.Common.Utilities.Mvvm;

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


        public abstract void LoadParameters(Specification<T> specification);

        public abstract Specification<T> BuildSpecification();

        #region Properties

        public string Type { get; set; }

        private string _parameters;

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