using Com.Baidu.Mapapi.Model;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal static class LatLngEx
    {
        public static Coordinate ToUnity(this LatLng coor)
        {
            return new Coordinate(coor.Latitude, coor.Longitude);
        }
    }
}

