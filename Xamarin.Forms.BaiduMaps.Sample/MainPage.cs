using System;

using Xamarin.Forms;

namespace Xamarin.Forms.BaiduMaps.Sample
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

