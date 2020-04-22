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
		private static CardType cardType;

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

			Email.Text = string.Empty;
			CardName.Text = string.Empty;
			CardNum.Text = string.Empty;
			CVV.Text = string.Empty;
			Expire.Text = string.Empty;
		}

		private void TicketSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			var picker = (Picker)sender;
			Total.Text = new Ticket((TicketType)picker.SelectedIndex).ticketPrice.ToString("C2");
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			//Validate input
			if (TicketSelect.SelectedIndex == -1)
			{
				await DisplayAlert("No Ticket Selected", "Please select a ticket type.", "OK");
			}
			else if (!VerifyEmail() || CardName.Text == string.Empty)
			{
				await DisplayAlert("Invalid Name or Email", "Please enter a valid email and cardholder name.", "OK");
			}
			else if (!VerifyCardNumber())
			{
				await DisplayAlert("Invalid Card Number", "Please verify input card information.", "OK");
			}
			else if (!VerifyCVV())
			{
				await DisplayAlert("Invalid CVV", "Please verify input CVV.", "OK");
			}
			else if (!VerifyExpiration())
			{
				await DisplayAlert("Invalid Expiration Date", "Please verify the card expiration date.", "OK");
			}
			else
			{
				SeatIndex seat = Seating.SelectedSeat;
				Seating.SelectedChart.seats[seat.i, seat.j].seatStatus = SeatStatus.Reserved;
				Random random = new Random();
				int number = (int)((random.NextDouble() * 0.9 + 0.1) * 100000000);
				string movie = Movies.SelectedMovie.title;
				string time = Seating.SelectedChart.time;
				string seatName = seat.ToString();
				await DisplayAlert("Purchase Successful!", $"{movie}\n{time} - {seatName}\n\"#{number}\"", "Continue Browsing");
				await Navigation.PopToRootAsync();
			}
		}

		/// <summary>
		/// Verify the length of the CVV. Make sure this check is performed AFTER a card number check.
		/// </summary>
		private bool VerifyCVV()
		{
			if (cardType != CardType.American_Express && CVV.Text.Length == 3 && int.TryParse(CVV.Text, out int cvv)) return true;
			else if (cardType == CardType.American_Express && CVV.Text.Length == 4 && int.TryParse(CVV.Text, out cvv)) return true;
			else return false;
		}

		private bool VerifyCardNumber()
		{
			CardNum.Text = CardNum.Text.Replace(" ", "");

			//Verify it is a number
			if (!long.TryParse(CardNum.Text, out long number)) return false;

			//Verify card number length
			if (CardNum.Text.Length < 13 || CardNum.Text.Length > 16) return false;

			//Verify starting character
			bool validStart = false;
			string firstChar = CardNum.Text.Substring(0, 1);
			switch (firstChar)
			{
				case "4": cardType = CardType.Visa; validStart = true; break;
				case "5": cardType = CardType.Mastercard; validStart = true; break;
				case "6": cardType = CardType.Discover; validStart = true; break;
			}
			if (!validStart && CardNum.Text.Substring(0, 2) == "37")
			{
				cardType = CardType.Visa;
				validStart = true;
			}
			if (!validStart) return false;

			//Luhn algorithm
			//https://www.geeksforgeeks.org/luhn-algorithm/
			int sum = 0;
			bool second = false;
			for (int i = CardNum.Text.Length - 1; i >= 0; i--)
			{
				int num = CardNum.Text[i] - '0';
				if (second) num *= 2;

				sum += num / 10;
				sum += num % 10;
				second = !second;
			}
			if (sum % 10 != 0) return false;

			//If all checks passed return true.
			return true;
		}

		private bool VerifyExpiration()
		{
			string[] entry = Expire.Text.Split('/');
			int month, year;

			//Verify numbers
			if (!int.TryParse(entry[0], out month))
			{
				return false;
			}
			else if (!int.TryParse(entry[1], out year))
			{
				return false;
			}

			//Verify range
			if (month < 1 || month > 12 || year < 100) return false;

			//Verify date
			DateTime dateTime = new DateTime(year, month, 1);
			dateTime = dateTime.AddMonths(1);
			if (DateTime.Compare(DateTime.Now, dateTime) > 0) return false;

			return true;
		}

		private bool VerifyEmail()
		{
			if (Email.Text == string.Empty || !Email.Text.Contains("@")) return false;
			else return true;
		}
	}
}