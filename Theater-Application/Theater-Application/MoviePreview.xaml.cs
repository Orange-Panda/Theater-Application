using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Theater_Application
{
	[DesignTimeVisible(false)]
	public partial class MoviePreview : ContentPage
	{
		private readonly string trailer;

		public MoviePreview()
		{
			InitializeComponent();

			Movie movie = Movies.SelectedMovie;
			PosterImage.Source = ImageSource.FromResource($"Theater-Application.Images.{movie.imageName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);
			PosterImageBG.Source = ImageSource.FromResource($"Theater-Application.Images.{movie.backgroundName}", typeof(EmbeddedImages).GetTypeInfo().Assembly);
			ContentRating.Text = movie.contentRating.ToString();
			Score.Text = movie.rating.ToString();
			Genre.Text = movie.genre;
			Length.Text = ((int)Math.Round(movie.movieLength)).ToString() + "m";
			Description.Text = movie.description;
			Cast.Text = movie.cast;
			Directors.Text = movie.directors;
			Writers.Text = movie.writers;
			Title.Text = movie.title.ToUpper();
			trailer = movie.videoUrl;
		}

		public async void WatchTrailer(object sender, EventArgs e)
		{
			Console.WriteLine("Trailer");
			await Browser.OpenAsync(trailer, BrowserLaunchMode.SystemPreferred);
		}

		public async void Seating(object sender, EventArgs e)
		{
			Console.WriteLine("Seating");
			await Navigation.PushAsync(new Seating());
		}
	}
}