using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
namespace Theater_Application
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class Seating : ContentPage
{
        private List<Seat> SeatsArrayList;

        public Seating()
        {
            InitializeComponent();
            SeatsArrayList = new List<Seat>();
            for (int i = 0; i < 50; i++)
            {
                //SeatsArrayList.Add(new Seat { Name = "" });
            }

            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.RowDefinitions.Add(new RowDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition());

            var seatIndex = 0;
            for (int rowIndex = 0; rowIndex <= 9; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex <= 5; columnIndex++)
                {
                    if (seatIndex >= SeatsArrayList.Count)
                    {
                        break;
                    }
                    var product = SeatsArrayList[seatIndex];
                    seatIndex += 1;
                    var Button = new Button
                    {
                        //Text = product.Name,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridLayout.Children.Add(Button, columnIndex, rowIndex);
                }
            }
        }
    }
}