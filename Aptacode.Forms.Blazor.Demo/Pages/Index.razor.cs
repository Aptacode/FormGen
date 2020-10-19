using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptacode.Forms.Blazor.Demo.Data;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Aptacode.Forms.Blazor.Demo.Pages
{
    public class IndexBase : ComponentBase
    {
        public FormViewModel FormModel { get; set; }
        public List<FormElementEvent> FormEventLog { get; set; }

        public IEnumerable<FormElementEvent> GetRecentEvents() => FormEventLog.TakeLast(10).Reverse();

        protected override Task OnInitializedAsync()
        {
            FormEventLog = new List<FormElementEvent>();
            FormModel = DemoForm.CreateForm();
            FormModel.OnTriggered += FormModelOnOnTriggered;
            return Task.CompletedTask;
        }

        private void FormModelOnOnTriggered(object? sender, (EventListener, FormElementEvent) e)
        {
            FormEventLog.Add(e.Item2);
            InvokeAsync(StateHasChanged);
        }
   
    }
}
