using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Com.Baidu.Platform.Comjni.Tools;
using Com.Baidu.Mapapi;

namespace test
{
    [Activity(Label = "test", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        double[] BaiduToGcj02(double lat, double lng)
        {
            double xpi = 3.1415926535897932384626 * 3000 / 180;
            double x = lng - 0.0065, y = lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * xpi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * xpi);

            return new double[] { z * Math.Sin(theta), z * Math.Cos(theta) };
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SDKInitializer.Initialize(Application.Context);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };

            double[] latlng;

            latlng = JNITools.BaiduToGcj(39.820971,116.582044);
            System.Diagnostics.Debug.WriteLine(latlng[0] + "," + latlng[1]);

            latlng = BaiduToGcj02(39.820971,116.582044);
            System.Diagnostics.Debug.WriteLine(latlng[0] + "," + latlng[1]);

            latlng = JNITools.GcjToBaidu(39.8153174971415,116.575446079989);
            System.Diagnostics.Debug.WriteLine(latlng[0] + "," + latlng[1]);

            System.Diagnostics.Debug.WriteLine("");

            latlng = JNITools.BaiduToGcj(39.784844,116.443383);
            System.Diagnostics.Debug.WriteLine(latlng[0] + "," + latlng[1]);

            latlng = BaiduToGcj02(39.784844,116.443383);
            System.Diagnostics.Debug.WriteLine(latlng[0] + "," + latlng[1]);

            latlng = JNITools.GcjToBaidu(39.7789667904777,116.436839772002);
            System.Diagnostics.Debug.WriteLine(latlng[0] + "," + latlng[1]);
        }
    }
}

