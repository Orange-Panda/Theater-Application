using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace Theater_Application
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Seating : ContentPage
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 7;
        private Seat[,] seats = new Seat[MaxHeight, MaxWidth];
        private Button[,] buttons = new Button[MaxHeight, MaxWidth];

        public Seating()
        {
            InitializeComponent();

            Date.Text = DateTime.Today.ToString("D", DateTimeFormatInfo.InvariantInfo);

            for (int i = 0; i < MaxHeight; i++)
            {
                StackLayout stack = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Spacing = 12
                };
                HStack.Children.Add(stack);

                for (int j = 0; j < MaxWidth; j++)
                {
                    var button = new Button
                    {
                        HeightRequest = 24,
                        WidthRequest = 40,
                        CornerRadius = 8
                    };

                    buttons[i, j] = button;
                    stack.Children.Add(button);
                }
            }
        }
    }
}