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
        internal bool isLongPressReady = true;
        private readonly PinImpl pinImpl = new PinImpl();
        private readonly PolylineImpl polylineImpl = new PolylineImpl();
        private readonly PolygonImpl polygonImpl = new PolygonImpl();
        private readonly CircleImpl circleImpl = new CircleImpl();

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

                    UILongPressGestureRecognizer longPress = new UILongPressGestureRecognizer();
                    longPress.Delegate = new LongPressGestureDelegate(this);
                    longPress.CancelsTouchesInView = false;
                    longPress.DelaysTouchesEnded = false;

                    AddGestureRecognizer(longPress);
                }

                UpdateMapType();
                //UpdateUserTrackingMode();
                //UpdateShowUserLocation();

                //UpdateShowCompass();
                UpdateCompassPosition();

                UpdateZoomLevel();
                UpdateMinZoomLevel();
                UpdateMaxZoomLevel();

                UpdateCenter();
                UpdateShowScaleBar();

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

            /*if (Map.ShowCompassProperty.PropertyName == e.PropertyName)
            {
                UpdateShowCompass();
                return;
            }*/

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
                UpdateCenter();
                return;
            }

            if (Map.ShowScaleBarProperty.PropertyName == e.PropertyName)
            {
                UpdateShowScaleBar();
                return;
            }

            Debug.WriteLine("OnElementPropertyChanged: " + e.PropertyName);
            base.OnElementPropertyChanged(sender, e);
        }

        private void UpdateMapType()
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

        private void UpdateUserTrackingMode()
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

        private void UpdateShowUserLocation()
        {
            NativeMap.SetShowsUserLocation(Map.ShowUserLocation);
        }

        private void UpdateShowCompass()
        {
            
        }

        private void UpdateCompassPosition()
        {
            NativeMap.CompassPosition = new CGPoint(Map.CompassPosition.X, Map.CompassPosition.Y);
        }

        private void UpdateZoomLevel()
        {
            NativeMap.ZoomLevel = Map.ZoomLevel;
        }

        private void UpdateMinZoomLevel()
        {
            NativeMap.MinZoomLevel = Map.MinZoomLevel;
        }

        private void UpdateMaxZoomLevel()
        {
            NativeMap.MaxZoomLevel = Map.MaxZoomLevel;
        }

        private void UpdateCenter()
        {
            NativeMap.CenterCoordinate = Map.Center.ToNative();
        }

        private void UpdateShowScaleBar()
        {
            NativeMap.ShowMapScaleBar = Map.ShowScaleBar;
        }

        protected BMKMapView NativeMap => (BMKMapView)Control;
        protected Map Map => (Map)Element;
    }
}

