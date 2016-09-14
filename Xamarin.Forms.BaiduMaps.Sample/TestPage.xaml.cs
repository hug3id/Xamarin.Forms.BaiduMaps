using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xamarin.Forms.BaiduMaps.Sample
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();

            back.Clicked += (sender, e) => {
                Navigation.PopAsync();
            };
        }
    }
}

