using Com.Baidu.Mapapi.Utils;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    public class CalculateUtilsImpl : ICalculateUtils
    {
        public double CalculateDistance(Coordinate p1, Coordinate p2)
        {
            return DistanceUtil.GetDistance(p1.ToNative(), p2.ToNative());
        }
    }
}

