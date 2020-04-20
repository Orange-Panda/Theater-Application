using System;
using System.Collections.Generic;
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

        public Seating()
        {
            InitializeComponent();

            SeatTitle.Text = $"{Movies.SelectedMovie.title} Availability";
            Date.Text = DateTime.Today.ToString("D", DateTimeFormatInfo.InvariantInfo);
            PosterImageBG.Source = ImageSource.FromResource($"Theater-Application.Images.{Movies.SelectedMovie.backgroundName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);

            Random random = new Random();
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

                for (int j = 0; j < SeatingChart.Width; j++)
                {
                    Color color;
                    switch (Movies.seatingCharts[Movies.SelectedMovie][0].seats[i, j].seatStatus)
                    {
                        case SeatStatus.Available: color = Color.White; break;
                        case SeatStatus.Reserved: color = Color.Gray; break;
                        case SeatStatus.Taken: color = new Color(.125, .125, .125); break;
                        case SeatStatus.Null: color = new Color(0, 0, 0, 0); break;
                        default: color = Color.White; break;
                    }

                    var button = new Button
                    {
                        HeightRequest = 24,
                        WidthRequest = 40,
                        CornerRadius = 8,
                        BackgroundColor = color
                    };

                    buttons[i, j] = button;
                    stack.Children.Add(button);
                }
            }
        }
    }
}