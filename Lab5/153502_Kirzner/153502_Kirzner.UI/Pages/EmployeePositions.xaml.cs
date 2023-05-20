using _153502_Kirzner.UI.ViewModels;

namespace _153502_Kirzner.UI.Pages;

public partial class EmployeePositions : ContentPage
{
    private EmployeePositionsViewModel _viewModel;
    public EmployeePositions(EmployeePositionsViewModel viewModel)
	{
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}