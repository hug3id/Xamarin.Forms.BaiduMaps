using System;
using System.Diagnostics;

using UIKit;
using Foundation;
using CoreGraphics;

using BMapMain;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public partial class MapRenderer : ViewRenderer<Map, BMKMapView>
    {
        private class LongPressGestureDelegate : UIGestureRecognizerDelegate
        {
            private MapRenderer Map { get; }
            public LongPressGestureDelegate(MapRenderer map)
            {
                Map = map;
            }

            public override bool ShouldBegin(UIGestureRecognizer recognizer)
            {
                /*Map.SendLongClicked(
                    Native.ConvertPoint(recognizer.LocationInView(recognizer.View), recognizer.View)
                          .ToUnity()
                );

                Debug.WriteLine(recognizer.State);
                return false;*/
                Map.isLongPressReady = true;
                return false;
            }
        }
    }
}