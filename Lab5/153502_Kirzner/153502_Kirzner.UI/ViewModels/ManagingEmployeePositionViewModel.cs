using _153502_Kirzner.ApplicationServices.Abstractions;
using _153502_Kirzner.Domain.Abstractions;
using _153502_Kirzner.Domain.Entities;
using _153502_Kirzner.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.UI.ViewModels
{
    public partial class ManagingEmployeePositionViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IEmployeePositionService _employeePositionService;
        private readonly IUnitOfWork _unit;
        public ManagingEmployeePositionViewModel(IEmployeePositionService employeePositionService, IUnitOfWork unit)
        {
            _employeePositionService = employeePositionService;
            _unit = unit;
        }

        [ObservableProperty]
        string title;


        [ObservableProperty]
        string success = "";

        [ObservableProperty]
        public EmployeePosition editingEmployeePosition;
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("editingJobDuty"))
            {
                editingEmployeePosition = query["editingEmployeePosition"] as EmployeePosition;
                Title = "Editing " + editingEmployeePosition.Name;

            }
            else
            {
                editingEmployeePosition = new EmployeePosition();
                editingEmployeePosition.Name = "";
                editingEmployeePosition.Salary = 0;
                editingEmployeePosition.JobDuties = new List<JobDuty>();
                Title = "Creation of Employee Position";

            }
        }

        [RelayCommand]
        public async Task ApplyPressedAsync() => await SaveEmpoyeePositionAsync();
        
        private async Task SaveEmpoyeePositionAsync()
        {
            if (title == "Creation of Employee Position")
            {
                await _employeePositionService.AddAsync(editingEmployeePosition);
            } else
            {
                await _employeePositionService.UpdateAsync(editingEmployeePosition);
            }
            await _unit.SaveAllAsync();

            success = "Completed successfully!";
            //await Shell.Current.GoToAsync("..");
        }

        
        
    }
}
