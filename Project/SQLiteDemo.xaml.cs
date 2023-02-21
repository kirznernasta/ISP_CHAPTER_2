using Project.Entities;
using Project.Services;

namespace Project;

public partial class SQLiteDemo : ContentPage
{

	IDbService service;

	public SQLiteDemo(IDbService s)
	{
		InitializeComponent();
		service = s;
		BindingContext = this;
	}

	void WhenLoaded(object sender, EventArgs e)
	{
        service.Init();
		JobTitlePicker.ItemsSource = service.GetAllJobTitles().
			Select(j => j.ToString()).ToList();

    }


	void OnIndexChanged(object sender, EventArgs e)
	{
        var picker = sender as Picker;
		int selectedIndex = picker.SelectedIndex + 1;


		OfficialDuties
			.ItemsSource = service.GetJobDuties(selectedIndex).
			Select(d => d.ToString());
	}


}
