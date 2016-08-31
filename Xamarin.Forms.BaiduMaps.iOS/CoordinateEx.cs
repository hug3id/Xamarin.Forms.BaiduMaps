using CoreLocation;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal static class CoordinateEx
    {
        internal static CLLocationCoordinate2D ToNative(this Coordinate coor)
        {
            return new CLLocationCoordinate2D(coor.Latitude, coor.Longitude);
        }
    }
}

