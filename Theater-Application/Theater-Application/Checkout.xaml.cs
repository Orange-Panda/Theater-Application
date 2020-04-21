using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Theater_Application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Checkout : ContentPage
	{
		public Checkout()
		{
			InitializeComponent();

			PosterImageBG.Source = ImageSource.FromResource($"Theater-Application.Images.{Movies.SelectedMovie.backgroundName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);
			PosterImage.Source = ImageSource.FromResource($"Theater-Application.Images.{Movies.SelectedMovie.imageName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);
			MovieSelect.Text = Movies.SelectedMovie.title;
			SeatSelect.Text = Seating.SelectedSeat.ToString();
			TimeSelect.Text = Seating.SelectedChart.time;
			TicketSelect.ItemsSource = new List<string>(Enum.GetNames(typeof(TicketType)));
			TicketSelect.SelectedIndexChanged += TicketSelect_SelectedIndexChanged;
			Total.Text = "--";
		}

		private void TicketSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			var picker = (Picker)sender;
			Total.Text = new Ticket((TicketType)picker.SelectedIndex).ticketPrice.ToString("C2");
		}

		private void Button_Clicked(object sender, EventArgs e)
		{

		}
	}
}