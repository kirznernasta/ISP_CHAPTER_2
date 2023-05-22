using _153502_Kirzner.UI.ViewModels;

namespace _153502_Kirzner.UI.Pages;

public partial class ManagingDuty : ContentPage
{
    private ManagingDutyViewModel _viewModel;
    public ManagingDuty(ManagingDutyViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}