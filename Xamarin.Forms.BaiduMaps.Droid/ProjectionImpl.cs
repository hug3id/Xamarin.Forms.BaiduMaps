using AG = Android.Graphics;
using BMap = Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    public class ProjectionImpl : IProjection
    {
        private BMap.MapView NativeView { get; }
        public ProjectionImpl(BMap.MapView mapView)
        {
            NativeView = mapView;
        }

        public Point ToScreen(Coordinate p)
        {
            AG.Point point = NativeView.Map.Projection.ToScreenLocation(p.ToNative());
            return new Point(point.X, point.Y);
        }

        public Coordinate ToCoordinate(Point p)
        {
            AG.Point point = new AG.Point((int)p.X, (int)p.Y);
            return NativeView.Map.Projection.FromScreenLocation(point).ToUnity();
        }
    }
}

