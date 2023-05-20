using _153502_Kirzner.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.UI.ViewModels
{
    public partial class JobDutyDetailsViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        JobDuty currentJobDuty;
       
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
           CurrentJobDuty = query["JobDuty"] as JobDuty;
        }
    }
}
