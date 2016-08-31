using CoreLocation;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal static class CLLocationCoordinate2DEx
    {
        public static Coordinate ToUnity(this CLLocationCoordinate2D coor)
        {
            return new Coordinate(coor.Latitude, coor.Longitude);
        }
    }
}

