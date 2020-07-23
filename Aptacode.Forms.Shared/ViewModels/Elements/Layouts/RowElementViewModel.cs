﻿using Aptacode.Forms.Shared.Models.Elements.Layouts;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Layouts
{
    public class RowElementViewModel : CompositeElementViewModel
    {
        public RowElementViewModel(RowElement model) : base(model)
        {
            Model = model; }

        private RowElement _model;
        public new RowElement Model
        {
            get => _model;
            set
            {
                SetProperty(ref _model, value);
            }
        }



    }
}