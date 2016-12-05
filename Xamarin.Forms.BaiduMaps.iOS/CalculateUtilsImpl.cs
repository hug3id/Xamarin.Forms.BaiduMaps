using BMapBinding;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public class CalculateUtilsImpl : ICalculateUtils
    {
        public double CalculateDistance(Coordinate p1, Coordinate p2)
        {
            return CFunctions.BMKMetersBetweenMapPoints(
                CFunctions.BMKMapPointForCoordinate(p1.ToNative()),
                CFunctions.BMKMapPointForCoordinate(p2.ToNative())
            );
        }
    }
}

