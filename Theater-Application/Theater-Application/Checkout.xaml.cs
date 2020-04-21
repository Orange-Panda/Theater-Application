using System;
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
            MovieSelect.Text = Movies.SelectedMovie.title;
            SeatSelect.Text = Seating.SelectedSeat.ToString();
            TimeSelect.Text = Seating.SelectedChart.time;
            TicketType.Text = "TBA";
            Total.Text = "$111";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}