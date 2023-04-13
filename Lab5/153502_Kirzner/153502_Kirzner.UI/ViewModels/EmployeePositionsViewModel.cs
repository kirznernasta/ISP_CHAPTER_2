using _153502_Kirzner.ApplicationServices.Abstractions;
using _153502_Kirzner.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153502_Kirzner.UI.ViewModels
{
    public partial class EmployeePositionsViewModel : ObservableObject
    {
        private readonly IEmployeePositionService _employeePositionService;
        private readonly IJobDutyService _jobDutyService;
        public EmployeePositionsViewModel(IEmployeePositionService employeePositionService, IJobDutyService
        jobDutyService)
        {
            _employeePositionService = employeePositionService;
            _jobDutyService = jobDutyService;
        }

        public ObservableCollection<EmployeePosition> EmployeePositions { get; set; } = new();
        public ObservableCollection<JobDuty> JobDuties { get; set; } = new();

        [ObservableProperty]
        EmployeePosition selectedEmployeePosition;

        [RelayCommand]
        public async void UpdateGroupList() => await GetEmployeePositions();

        [RelayCommand]
        public async void UpdateMembersList() => await GetJobDuties();
        public async Task GetEmployeePositions()
        {
            var positions = await _employeePositionService.GetAllAsync();
            
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                EmployeePositions.Clear();
                foreach (var position in positions)
                {
                    EmployeePositions.Add(position);
                }
            });
        }

        public async Task GetJobDuties()
        {
            var duties = await _jobDutyService.GetAllByImployeePositionIdAsync(SelectedEmployeePosition.Id);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                JobDuties.Clear();
                foreach (var duty in duties)
                {
                    JobDuties.Add(duty);
                }
            });
        }
    }
}
