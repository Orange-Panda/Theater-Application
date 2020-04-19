using System;
using System.ComponentModel;
using System.Reflection;
using Movie_Theater;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Theater_Application
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MoviePreview : ContentPage
    {
        public MoviePreview()
        {
            InitializeComponent();
            Movie movie = Movies.SelectedMovie;
            PosterImage.Source = ImageSource.FromResource($"Theater-Application.Images.{movie.imageName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);
            ContentRating.Text = movie.contentRating.ToString();
            Score.Text = movie.rating.ToString();
            Genre.Text = movie.genre;
            Length.Text = ((int)Math.Round(movie.movieLength)).ToString() + "m";
            Description.Text = movie.description;
            Cast.Text = movie.cast;
            Directors.Text = movie.directors;
            Writers.Text = movie.writers;
            Title.Text = movie.title;
        }

        private async void WatchTrailer(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.youtube.com/watch?v=szby7ZHLnkA", BrowserLaunchMode.SystemPreferred);
        }
    }
}