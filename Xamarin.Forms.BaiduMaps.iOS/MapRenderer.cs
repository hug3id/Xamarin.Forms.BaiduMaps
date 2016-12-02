using System.ComponentModel;
using System.Diagnostics;

using UIKit;
using CoreGraphics;

using BMapBase;
using BMapMain;

using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public partial class MapRenderer : ViewRenderer<Map, BMKMapView>
    {
        readonly PinImpl pinImpl = new PinImpl();
        readonly PolylineImpl polylineImpl = new PolylineImpl();
        readonly PolygonImpl polygonImpl = new PolygonImpl();
        readonly CircleImpl circleImpl = new CircleImpl();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (null != Element)
                {
                    //var map = (Map)Element;
                }

                pinImpl.Unregister(Map);
                polylineImpl.Unregister(Map);
                polygonImpl.Unregister(Map);
                circleImpl.Unregister(Map);

                Map.Pins.Clear();
                Map.Polylines.Clear();
                Map.Polygons.Clear();
                Map.Circles.Clear();

                NativeMap.Delegate = null;
            }

            base.Dispose(disposing);
        }

        public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest {
                Request = new Size {
                    Width = UIScreen.MainScreen.Bounds.Width,
                    Height = UIScreen.MainScreen.Bounds.Height
                }
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (null != e.OldElement)
            {
            }

            if (null != e.NewElement)
            {
                if (null == Control) {
                    SetNativeControl(new BMKMapView());

                    Map.LocationService = new LocationServiceImpl(NativeMap);
                    NativeMap.Delegate = new MapViewDelegate(this);
                }

                UpdateMapType();
                UpdateUserTrackingMode();
                UpdateShowUserLocation();

                UpdateShowCompass();
                UpdateCompassPosition();

                UpdateZoomLevel();
                UpdateMinZoomLevel();
                UpdateMaxZoomLevel();

                UpdateCenter();
                UpdateShowScaleBar();
                UpdateShowZoomControl();

                pinImpl.Unregister(e.OldElement);
                pinImpl.Register(Map, NativeMap);

                polylineImpl.Unregister(e.OldElement);
                polylineImpl.Register(Map, NativeMap);

                polygonImpl.Unregister(e.OldElement);
                polygonImpl.Register(Map, NativeMap);

                circleImpl.Unregister(e.OldElement);
                circleImpl.Register(Map, NativeMap);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ("Height" == e.PropertyName)
            {
                Debug.WriteLine("Height = " + Map.Height);
                return;
            }

            if ("Width" == e.PropertyName)
            {
                Debug.WriteLine("Width = " + Map.Width);
                return;
            }

            if (Map.MapTypeProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("MapType = " + Map.MapType);
                UpdateMapType();
                return;
            }

            if (Map.UserTrackingModeProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("UserTrackingMode = " + Map.UserTrackingMode);
                UpdateUserTrackingMode();
                return;
            }

            if (Map.ShowUserLocationProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("ShowUserLocation = " + Map.ShowUserLocation);
                UpdateShowUserLocation();
                return;
            }

            if (Map.ShowCompassProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("ShowCompass = " + Map.ShowCompass);
                UpdateShowCompass();
                return;
            }

            if (Map.CompassPositionProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("CompassPosition = " + Map.CompassPosition);
                UpdateCompassPosition();
                return;
            }

            if (Map.ZoomLevelProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("ZoomLevel = " + Map.ZoomLevel);
                UpdateZoomLevel();
                return;
            }

            if (Map.MinZoomLevelProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("MinZoomLevel = " + Map.MinZoomLevel);
                UpdateMinZoomLevel();
                return;
            }

            if (Map.MaxZoomLevelProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("MaxZoomLevel = " + Map.MaxZoomLevel);
                UpdateMaxZoomLevel();
                return;
            }

            if (Map.CenterProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("Center = " + Map.Center);
                UpdateCenter();
                return;
            }

            if (Map.ShowScaleBarProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("ShowScaleBar = " + Map.ShowScaleBar);
                UpdateShowScaleBar();
                return;
            }

            if (Map.ShowZoomControlProperty.PropertyName == e.PropertyName)
            {
                Debug.WriteLine("ShowZoomControl = " + Map.ShowZoomControl);
                UpdateShowZoomControl();
                return;
            }

            Debug.WriteLine("OnElementPropertyChanged: " + e.PropertyName);
            base.OnElementPropertyChanged(sender, e);
        }

        void UpdateMapType()
        {
            switch (Map.MapType) {
                case MapType.None:
                    NativeMap.MapType = BMKMapType.None;
                    break;

                case MapType.Standard:
                    NativeMap.MapType = BMKMapType.Standard;
                    break;

                case MapType.Satellite:
                    NativeMap.MapType = BMKMapType.Satellite;
                    break;
            }
        }

        void UpdateUserTrackingMode()
        {
            switch (Map.UserTrackingMode) {
                case UserTrackingMode.None:
                    NativeMap.SetUserTrackingMode(BMKUserTrackingMode.None);
                    break;

                case UserTrackingMode.Follow:
                    NativeMap.SetUserTrackingMode(BMKUserTrackingMode.Follow);
                    break;

                case UserTrackingMode.FollowWithCompass:
                    NativeMap.SetUserTrackingMode(BMKUserTrackingMode.FollowWithHeading);
                    break;
            }
        }

        void UpdateShowUserLocation()
        {
            NativeMap.SetShowsUserLocation(Map.ShowUserLocation);
        }

        void UpdateShowCompass()
        { 
        }

        void UpdateCompassPosition()
        {
            NativeMap.CompassPosition = new CGPoint(
                Map.CompassPosition.X, Map.CompassPosition.Y
            );
        }

        void UpdateZoomLevel()
        {
            NativeMap.ZoomLevel = Map.ZoomLevel;
        }

        void UpdateMinZoomLevel()
        {
            NativeMap.MinZoomLevel = Map.MinZoomLevel;
        }

        void UpdateMaxZoomLevel()
        {
            NativeMap.MaxZoomLevel = Map.MaxZoomLevel;
        }

        void UpdateCenter()
        {
            NativeMap.CenterCoordinate = Map.Center.ToNative();
        }

        void UpdateShowScaleBar()
        {
            NativeMap.ShowMapScaleBar = Map.ShowScaleBar;
        }

        void UpdateShowZoomControl()
        {
        }

        protected BMKMapView NativeMap => (BMKMapView)Control;
        protected Map Map => (Map)Element;
    }
}

