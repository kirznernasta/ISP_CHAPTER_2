using _153502_Kirzner.UI.Pages;

namespace _153502_Kirzner.UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(JobDutyDetails), typeof(JobDutyDetails));
    }
}
