﻿using System;
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
    public partial class Page4 : ContentPage
{
    public Page4()
    {
        
    }

        private async void WatchTrailer(Object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://www.youtube.com/watch?v=hej47fWFLQs", BrowserLaunchMode.SystemPreferred);
        }

        /*private async void SelectSeating(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeatingPage());
        }*/
    }
}