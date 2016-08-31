using UIKit;

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
                // Notify the map a long press is beginning...
                Map.isLongPressReady = true;
                return false; // end the gesture
            }
        }
    }
}