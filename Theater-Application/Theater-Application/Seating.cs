using System;
using System.Globalization;

namespace Theater_Application
{
	public struct Seat
	{
		public SeatStatus seatStatus;
	}

	public class SeatingChart
	{
		public const int Height = 9;
		public const int Width = 7;
		public int hour, minute;
		public string time = "0:00 PM";
		public Seat[,] seats = new Seat[Height, Width];

		public SeatingChart(double takenProbability)
		{
			Random random = new Random();
			hour = random.Next(10, 26) % 24;
			minute = random.Next(0, 12) * 5;
			DateTime dateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, hour, minute, 0);
			time = dateTime.ToString("t", CultureInfo.CreateSpecificCulture("en-US"));

			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					seats[i, j].seatStatus = random.NextDouble() < takenProbability ? SeatStatus.Taken : SeatStatus.Available;
				}
			}
		}
	}

	public struct SeatIndex
	{
		public int i;
		public int j;

		public SeatIndex(int i, int j)
		{
			this.i = i;
			this.j = j;
		}

		public override string ToString()
		{
			return $"{i+1}{(char)('A' + j)}";
		}
	}


	public enum SeatStatus
	{
		Available, Reserved, Taken, Null
	}
}
