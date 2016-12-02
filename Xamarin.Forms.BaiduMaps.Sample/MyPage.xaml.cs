using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xamarin.Forms.BaiduMaps.Sample
{
    public partial class MyPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SamplePage());
        }

        public MyPage()
        {
            InitializeComponent();
        }
    }
}
