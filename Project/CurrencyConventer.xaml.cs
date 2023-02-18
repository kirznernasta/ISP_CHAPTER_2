using System.Text.Json;
using System;

namespace Project;

public partial class CurrencyConventer : ContentPage
{
	List<String> _currencies = new List<string>{ "Russian Ruble", "EURO", "US Dollar", "Swiss Franc", "Yuan China", "Pound Sterling" };
	List<int> ids = new List<int> { 141, 19, 145, 130, 28, 143 };

	

	public CurrencyConventer()
	{
		InitializeComponent();
	}


	void WhenLoaded(object sender, EventArgs e)
	{
        CurrencyPicker.ItemsSource= _currencies;

    }


	void OnGetCurrencyClicled(object sender, EventArgs e)
	{
		int index = CurrencyPicker.SelectedIndex;
		DateTime date = DatePicker.Date;

    }
}