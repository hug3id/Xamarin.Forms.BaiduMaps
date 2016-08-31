using System.Diagnostics;

using BMapBase;
using BMapMain;
using BMapLocation;

using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public partial class MapRenderer : ViewRenderer<Map, BMKMapView>
    {
        private class LocationServiceDelegate : BMKLocationServiceDelegate
        {
            public BMKMapView MapView { get; }

            public LocationServiceDelegate(BMKMapView mapView)
            {
                MapView = mapView;
            }

            public override void WillStartLocatingUser()
            {
                Debug.WriteLine("WillStartLocatingUser");
            }

            public override void DidFailToLocateUserWithError(Foundation.NSError error)
            {
                Debug.WriteLine("DidFailToLocateUserWithError: " + error);
            }

            public override void DidUpdateUserHeading(BMKUserLocation userLocation)
            {
                Debug.WriteLine("方向变更: " + userLocation.Heading);
            }

            public override void DidUpdateBMKUserLocation(BMKUserLocation userLocation)
            {
                Debug.WriteLine("坐标变更 " + userLocation.Location.Coordinate.ToUnity());
                MapView.UpdateLocationData(userLocation);
            }
        }
    }
}

