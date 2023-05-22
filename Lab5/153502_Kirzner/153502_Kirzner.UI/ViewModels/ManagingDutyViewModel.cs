using _153502_Kirzner.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.UI.ViewModels
{
    public partial class ManagingDutyViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        string title;

        [ObservableProperty]
        JobDuty editingJobDuty;
        public void ApplyQueryAttributes(IDictionary<string, object>? query)
        {
            if (query.ContainsKey("editingJobDuty"))
            {
                EditingJobDuty = query["editingJobDuty"] as JobDuty;
                Title = "Editing " + EditingJobDuty.Name;
               
            } else
            {
                EditingJobDuty = null;
                Title = "Creation";

            }
            
        }
    }
}
