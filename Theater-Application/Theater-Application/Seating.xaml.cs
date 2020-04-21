using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Theater_Application
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class Seating : ContentPage
	{
		private Button[,] buttons = new Button[SeatingChart.Height, SeatingChart.Width];
		private SeatingChart visibleChart;
		public static SeatingChart SelectedChart { get; private set; }
		public static SeatIndex SelectedSeat { get; private set; }

		public Seating()
		{
			InitializeComponent();

			//Load information
			SeatTitle.Text = $"{Movies.SelectedMovie.title} Availability";
			DateTime dateTime = DateTime.Today;
			dateTime = dateTime.AddDays(1);
			Date.Text = dateTime.ToString("D", DateTimeFormatInfo.InvariantInfo);
			PosterImageBG.Source = ImageSource.FromResource($"Theater-Application.Images.{Movies.SelectedMovie.backgroundName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);

			//Seating column header
			{
				StackLayout stack = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Spacing = 12
				};
				for (int i = 0; i <= SeatingChart.Width; i++)
				{
					Label label = new Label
					{
						Text = i != 0 ? ((char)('A' + i - 1)).ToString() : "",
						TextColor = Color.White,
						WidthRequest = i != 0 ? 40 : 16,
						HorizontalTextAlignment = TextAlignment.Center,
					};

					stack.Children.Add(label);
				}
				HStack.Children.Add(stack);
			}

			//Seating rows
			for (int i = 0; i < SeatingChart.Height; i++)
			{
				StackLayout stack = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Spacing = 12
				};
				HStack.Children.Add(stack);

				Label label = new Label
				{
					Text = (i + 1).ToString(),
					TextColor = Color.White,
					WidthRequest = 16,
					HorizontalTextAlignment = TextAlignment.Center,
					VerticalTextAlignment = TextAlignment.Center
				};
				stack.Children.Add(label);

				for (int j = 0; j < SeatingChart.Width; j++)
				{
					var button = new Button
					{
						HeightRequest = 24,
						WidthRequest = 40,
						CornerRadius = 8,
						BackgroundColor = Color.White
					};

					button.BindingContext = new SeatIndex(i, j);
					button.Clicked += Button_SeatSelect;
					buttons[i, j] = button;
					stack.Children.Add(button);
				}
			}

			//Time selection
			foreach (SeatingChart chart in Movies.seatingCharts[Movies.SelectedMovie])
			{
				Button button = new Button
				{
					Text = chart.time,
					BindingContext = chart,
					TextColor = Color.Firebrick,
					BorderColor = Color.Firebrick,
					BackgroundColor = Color.Black,
					BorderWidth = 2,
					CornerRadius = 10,
					HeightRequest = 40
				};

				button.Clicked += Button_TimeSelect;
				TimeSelect.Children.Add(button);
			}

			LoadChart(Movies.seatingCharts[Movies.SelectedMovie][0]);
		}

		private void Button_TimeSelect(object sender, EventArgs e)
		{
			SeatingChart chart = (SeatingChart)((Button)sender).BindingContext;
			if (visibleChart != chart)
			{
				LoadChart(chart);
			}
		}

		private async void Button_SeatSelect(object sender, EventArgs e)
		{
			SelectedChart = visibleChart;
			SelectedSeat = (SeatIndex)((Button)sender).BindingContext;
			await Navigation.PushAsync(new Checkout());
		}

		public void LoadChart(SeatingChart chart)
		{
			visibleChart = chart;

			for (int i = 0; i < SeatingChart.Height; i++)
			{
				for (int j = 0; j < SeatingChart.Width; j++)
				{
					Color color;
					switch (chart.seats[i, j].seatStatus)
					{
						case SeatStatus.Available: color = Color.White; break;
						case SeatStatus.Reserved: color = Color.Gray; break;
						case SeatStatus.Taken: color = new Color(.125, .125, .125); break;
						case SeatStatus.Null: color = new Color(0, 0, 0, 0); break;
						default: color = Color.White; break;
					}

					buttons[i, j].IsEnabled = chart.seats[i, j].seatStatus == SeatStatus.Available;
					buttons[i, j].BackgroundColor = color;
				}
			}
		}
	}
}