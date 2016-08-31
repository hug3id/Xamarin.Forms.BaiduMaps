using Com.Baidu.Mapapi.Model;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal static class CoordinateEx
    {
        public static LatLng ToNative(this Coordinate coor)
        {
            return new LatLng(coor.Latitude, coor.Longitude);
        }
    }
}

