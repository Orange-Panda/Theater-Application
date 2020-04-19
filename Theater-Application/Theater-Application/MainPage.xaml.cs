using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Movie_Theater;
using Xamarin.Forms;

namespace Theater_Application
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
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
					HeightRequest = 350
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
