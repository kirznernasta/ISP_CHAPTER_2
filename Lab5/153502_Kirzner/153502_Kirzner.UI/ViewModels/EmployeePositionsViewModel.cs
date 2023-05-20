using _153502_Kirzner.ApplicationServices.Abstractions;
using _153502_Kirzner.Domain.Entities;
using _153502_Kirzner.UI.Pages;
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

        [RelayCommand]
        async void ShowDetails(JobDuty jobDuty) => await GotoDetailsPage(jobDuty);
        private async Task GetEmployeePositions()
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

        private async Task GetJobDuties()
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

        private async Task GotoDetailsPage(JobDuty jobDuty)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"JobDuty", jobDuty }
            };
            await Shell.Current.GoToAsync(nameof(JobDutyDetails), parameters);
        }
    }
}
