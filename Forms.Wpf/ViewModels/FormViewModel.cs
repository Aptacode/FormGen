using System.Collections.ObjectModel;
using Aptacode.Forms.Elements.Fields.Results;
using Aptacode.Forms.Layout;
using Aptacode.Forms.Wpf.ViewModels.Layout;
using Prism.Mvvm;

namespace Aptacode.Forms.Wpf.ViewModels
{
    public class FormViewModel : BindableBase
    {
        public FormViewModel(Form form)
        {
            Groups = new ObservableCollection<FormGroupViewModel>();
            Form = form ?? Form.EmptyForm;
            Load();
        }

        public bool IsValid => Form.IsValid;

        public void Load()
        {
            if (Form == null)
            {
                Clear();
                return;
            }

            Name = Form.Name;
            Title = Form.Title;
            LoadGroups();
        }

        public void Clear()
        {
            _form = null;
            Name = string.Empty;
            Title = string.Empty;
            Groups.Clear();
        }

        private void LoadGroups()
        {
            Groups.Clear();
            if (Form == null)
            {
                return;
            }

            foreach (var formRow in Form.Groups)
            {
                Groups.Add(new FormGroupViewModel(formRow));
            }
        }

        public FormResult GetResult()
        {
            return Form.GetResult();
        }

        #region Methods

        public void Add(FormGroup group)
        {
            if (group == null || Form.Groups.Contains(group))
            {
                return;
            }

            Form.Groups.Add(group);
            LoadGroups();
        }

        public void Remove(FormGroup group)
        {
            Form.Groups.Remove(group);
            LoadGroups();
        }

        #endregion

        #region Properties

        private Form _form;

        public Form Form
        {
            get => _form;
            set
            {
                SetProperty(ref _form, value);
                Load();
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                if (Form != null)
                {
                    Form.Name = _name;
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
                if (Form != null)
                {
                    Form.Title = _title;
                }
            }
        }

        public ObservableCollection<FormGroupViewModel> Groups { get; set; }

        #endregion
    }
}