using CoreGraphics;

using BMapBinding;

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
            CGPoint point = NativeView.ConvertCoordinateToPointToView(p.ToNative(), NativeView);
            return new Point(point.X, point.Y);
        }

        public Coordinate ToCoordinate(Point p)
        {
            CGPoint point = new CGPoint(p.X, p.Y);
            return NativeView.ConvertPointToCoordinateFromView(point, NativeView).ToUnity();
        }
    }
}

