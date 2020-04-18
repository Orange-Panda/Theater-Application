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
    public partial class Page5 : ContentPage
{
    public Page5()
    {
        
    }
        private async void WatchTrailer(Object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.youtube.com/watch?v=rBxcF-r9Ibs", BrowserLaunchMode.SystemPreferred);
        }

        /*private async void SelectSeating(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeatingPage1());
        }*/
    }
}