using CoreGraphics;

using BMapMain;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public class ProjectionImpl : IProjection
    {
        private BMKMapView NativeView { get; }
        public ProjectionImpl(BMKMapView mapView)
        {
            NativeView = mapView;
        }

        public Point ToScreen(Coordinate p)
        {
            CGPoint point = NativeView.ConvertCoordinate(p.ToNative(), NativeView);
            return new Point(point.X, point.Y);
        }

        public Coordinate ToCoordinate(Point p)
        {
            CGPoint point = new CGPoint(p.X, p.Y);
            return NativeView.ConvertPoint(point, NativeView).ToUnity();
        }
    }
}

