using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Theater_Application
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			
		}
		private async void TapGestureRecognizer_Tapped_1(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page1());
		}

		private async void TapGestureRecognizer_Tapped_2(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page2());
		}
		private async void TapGestureRecognizer_Tapped_3(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page3());
		}
		private async void TapGestureRecognizer_Tapped_4(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page4());
		}
		private async void TapGestureRecognizer_Tapped_5(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page5());
		}
		private async void TapGestureRecognizer_Tapped_6(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page6());
		}
		private async void TapGestureRecognizer_Tapped_7(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page7());
		}
		private async void TapGestureRecognizer_Tapped_8(Object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page8());
		}

	}
}
