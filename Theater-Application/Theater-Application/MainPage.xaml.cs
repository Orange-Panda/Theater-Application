using System;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Theater_Application
{
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			bool alt = false;
			foreach (Movie movie in Movies.GetMovieList())
			{
				Image image = new Image
				{
					Aspect = Aspect.AspectFit,
					Source = ImageSource.FromResource($"Theater-Application.Images.{movie.imageName}", typeof(EmbeddedImages).GetTypeInfo().Assembly),
					HeightRequest = 256
				};

				image.BindingContext = movie;

				TapGestureRecognizer gesture = new TapGestureRecognizer();
				gesture.Tapped += GoToPreview;
				image.GestureRecognizers.Add(gesture);

				if (alt)
				{
					Stack2.Children.Add(image);
				}
				else
				{
					Stack1.Children.Add(image);
				}
				alt = !alt;
			}
		}

		private async void GoToPreview(object sender, EventArgs e)
		{
			Movies.SetMovie((Movie)((BindableObject)sender).BindingContext);
			await Navigation.PushAsync(new MoviePreview());
		}
	}
}
