using _153502_Kirzner.UI.ViewModels;

namespace _153502_Kirzner.UI.Pages;

public partial class JobDutyDetails : ContentPage
{
	private JobDutyDetailsViewModel _viewModel;
	public JobDutyDetails(JobDutyDetailsViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
}