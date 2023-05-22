using _153502_Kirzner.Domain.Entities;
using _153502_Kirzner.UI.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace _153502_Kirzner.UI.Pages;

public partial class ManagingEmployeePosition : ContentPage
{
    private ManagingEmployeePositionViewModel _viewModel;
    public ManagingEmployeePosition(ManagingEmployeePositionViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    private void NameChanged(object sender, EventArgs e)
    {
        if (_viewModel.editingEmployeePosition == null)
        {
            _viewModel.editingEmployeePosition = new EmployeePosition();
            _viewModel.editingEmployeePosition.JobDuties = new List<JobDuty>();
        }
        _viewModel.editingEmployeePosition.Name = NameEntry.Text;
        
    }

    private void SalaryChanged(object sender, EventArgs e)
    {
        if (_viewModel.editingEmployeePosition == null)
        {
            _viewModel.editingEmployeePosition = new EmployeePosition();
            _viewModel.editingEmployeePosition.JobDuties = new List<JobDuty>();
        }
        _viewModel.editingEmployeePosition.Salary = Double.Parse(SalaryEntry.Text);

    }

}