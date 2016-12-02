using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Xamarin.Forms.BaiduMaps.Sample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsBaiduMaps.Init("B3iCnaZ9pv6UDbenWBEHdfY36dsVLUnM");

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

