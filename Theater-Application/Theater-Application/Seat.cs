using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Theater_Application
{
	public struct Seat
	{
		public SeatStatus seatStatus;
	}

	public class SeatingChart
	{
		public const int Height = 10;
		public const int Width = 7;
		public string time = "0:00 PM";
		public Seat[,] seats = new Seat[Height, Width];

		public SeatingChart(double takenProbability)
		{
			Random random = new Random();
			int hour = random.Next(10, 26) % 24;
			int minute = random.Next(0, 12) * 5;
			string suffix = hour >= 12 ? "PM" : "AM";
			time = $"{hour % 12}:{minute:N2} {suffix}";

			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					seats[i, j].seatStatus = random.NextDouble() < takenProbability ? SeatStatus.Taken : SeatStatus.Available;
				}
			}
		}
	}

	public enum SeatStatus
	{
		Available, Reserved, Taken, Null
	}
}
