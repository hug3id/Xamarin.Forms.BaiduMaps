using System;
using System.ComponentModel;

using AG = Android.Graphics;
using Xamarin.Forms.Platform.Android;

using Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    public partial class MapRenderer : ViewRenderer<Map, MapView>, BaiduMap.IOnMapLoadedCallback
    {
        protected MapView NativeMap => Control;
        protected Map Map => Element;

        readonly PinImpl pinImpl = new PinImpl();
        readonly PolylineImpl polylineImpl = new PolylineImpl();
        readonly PolygonImpl polygonImpl = new PolygonImpl();
        readonly CircleImpl circleImpl = new CircleImpl();

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (null != Element) {
                    Map.Pins.Clear();
                    ((LocationServiceImpl)Map.LocationService).Unregister();
                }

                pinImpl.Unregister(Map);
                polylineImpl.Unregister(Map);
                polygonImpl.Unregister(Map);
                circleImpl.Unregister(Map);

                NativeMap.Map.Clear();
                NativeMap.Map.MapClick -= OnMapClick;
                NativeMap.Map.MapPoiClick -= OnMapPoiClick;
                NativeMap.Map.MapDoubleClick -= OnMapDoubleClick;
                NativeMap.Map.MapLongClick -= OnMapLongClick;
                NativeMap.Map.MarkerClick -= OnMarkerClick;
                NativeMap.Map.MarkerDragStart -= OnMarkerDragStart;
                NativeMap.Map.MarkerDrag -= OnMarkerDrag;
                NativeMap.Map.MarkerDragEnd -= OnMarkerDragEnd;
                NativeMap.Map.MapStatusChangeFinish -= MapStatusChangeFinish;
                NativeMap.Map.SetOnMapLoadedCallback(null);

                NativeMap.OnDestroy();
            }

            System.Diagnostics.Debug.WriteLine("Disposing: " + disposing);
            base.Dispose(disposing);
        }

        public override SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            return new SizeRequest(new Size(Context.ToPixels(0), Context.ToPixels(0)));
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (null == Control) {
                SetNativeControl(new MapView(Context));
            }

            if (null != e.OldElement) {
                var oldMap = e.OldElement;
                oldMap.Pins.Clear();
                ((LocationServiceImpl)Map.LocationService).Unregister();

                MapView oldMapView = Control;
                oldMapView.Map.Clear();
                oldMapView.Map.MapClick -= OnMapClick;
                oldMapView.Map.MapPoiClick -= OnMapPoiClick;
                oldMapView.Map.MapDoubleClick -= OnMapDoubleClick;
                oldMapView.Map.MapLongClick -= OnMapLongClick;
                oldMapView.Map.MarkerClick -= OnMarkerClick;
                oldMapView.Map.MarkerDragStart -= OnMarkerDragStart;
                oldMapView.Map.MarkerDrag -= OnMarkerDrag;
                oldMapView.Map.MarkerDragEnd -= OnMarkerDragEnd;
                oldMapView.Map.MapStatusChangeFinish -= MapStatusChangeFinish;
                oldMapView.Map.SetOnMapLoadedCallback(null);

                oldMapView.OnDestroy();
            }

            if (null != e.NewElement)
            {
                Map.LocationService = new LocationServiceImpl(NativeMap, Context);

                NativeMap.Map.MapClick += OnMapClick;
                NativeMap.Map.MapPoiClick += OnMapPoiClick;
                NativeMap.Map.MapDoubleClick += OnMapDoubleClick;
                NativeMap.Map.MapLongClick += OnMapLongClick;
                NativeMap.Map.MarkerClick += OnMarkerClick;
                NativeMap.Map.MarkerDragStart += OnMarkerDragStart;
                NativeMap.Map.MarkerDrag += OnMarkerDrag;
                NativeMap.Map.MarkerDragEnd += OnMarkerDragEnd;
                NativeMap.Map.MapStatusChangeFinish += MapStatusChangeFinish;
                NativeMap.Map.SetOnMapLoadedCallback(this);

                NativeMap.ShowZoomControls(false);

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
                System.Diagnostics.Debug.WriteLine("Height = " + Map.Height);
                return;
            }

            if ("Width" == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("Width = " + Map.Width);
                return;
            }

            if (Map.MapTypeProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("MapType = " + Map.MapType);
                UpdateMapType();
                return;
            }

            if (Map.UserTrackingModeProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("UserTrackingMode = " + Map.UserTrackingMode);
                UpdateUserTrackingMode();
                return;
            }

            if (Map.ShowUserLocationProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("ShowUserLocation = " + Map.ShowUserLocation);
                UpdateShowUserLocation();
                return;
            }

            if (Map.ShowCompassProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("ShowCompass = " + Map.ShowCompass);
                UpdateShowCompass();
                return;
            }

            if (Map.CompassPositionProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("CompassPosition = " + Map.CompassPosition);
                UpdateCompassPosition();
                return;
            }

            if (Map.ZoomLevelProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("ZoomLevel = " + Map.ZoomLevel);
                UpdateZoomLevel();
                return;
            }

            if (Map.MinZoomLevelProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("MinZoomLevel = " + Map.MinZoomLevel);
                UpdateMinZoomLevel();
                return;
            }

            if (Map.MaxZoomLevelProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("MaxZoomLevel = " + Map.MaxZoomLevel);
                UpdateMaxZoomLevel();
                return;
            }

            if (Map.CenterProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("Center = " + Map.Center);
                UpdateCenter();
                return;
            }

            if (Map.ShowScaleBarProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("ShowScaleBar = " + Map.ShowScaleBar);
                UpdateShowScaleBar();
                return;
            }

            if (Map.ShowZoomControlProperty.PropertyName == e.PropertyName)
            {
                System.Diagnostics.Debug.WriteLine("ShowZoomControl = " + Map.ShowZoomControl);
                UpdateShowZoomControl();
                return;
            }

            System.Diagnostics.Debug.WriteLine("OnElementPropertyChanged: " + e.PropertyName);
            base.OnElementPropertyChanged(sender, e);
        }

        void UpdateMapType()
        {
            switch (Map.MapType) {
                case MapType.None:
                    NativeMap.Map.MapType = 0;
                    break;

                case MapType.Standard:
                    NativeMap.Map.MapType = 1;
                    break;

                case MapType.Satellite:
                    NativeMap.Map.MapType = 2;
                    break;
            }
        }

        void UpdateUserTrackingMode()
        {
            MyLocationConfiguration.LocationMode mode;

            switch (Map.UserTrackingMode) {
                default:
                case UserTrackingMode.None:
                    mode = MyLocationConfiguration.LocationMode.Normal;
                    break;

                case UserTrackingMode.Follow:
                    mode = MyLocationConfiguration.LocationMode.Following;
                    break;

                case UserTrackingMode.FollowWithCompass:
                    mode = MyLocationConfiguration.LocationMode.Compass;
                    break;
            }

            NativeMap.Map.SetMyLocationConfigeration(
                new MyLocationConfiguration(mode, true, null)
            );

            if (UserTrackingMode.FollowWithCompass != Map.UserTrackingMode) {
                // 恢复俯视角
                MapStatusUpdate overlook = MapStatusUpdateFactory.NewMapStatus(
                    new MapStatus.Builder(NativeMap.Map.MapStatus).Rotate(0).Overlook(0).Build()
                );

                NativeMap.Map.AnimateMapStatus(overlook);
            }
        }

        void UpdateShowUserLocation()
        {
            NativeMap.Map.MyLocationEnabled = Map.ShowUserLocation;
        }

        void UpdateShowCompass()
        {
            NativeMap.Map.UiSettings.CompassEnabled = Map.ShowCompass;
        }

        void UpdateCompassPosition()
        {
            NativeMap.Map.CompassPosition = new AG.Point {
                X = (int)Map.CompassPosition.X,
                Y = (int)Map.CompassPosition.Y
            };
        }

        void UpdateZoomLevel()
        {
            NativeMap.Map.AnimateMapStatus(
                MapStatusUpdateFactory.ZoomTo(Map.ZoomLevel)
            );
        }

        void UpdateMinZoomLevel()
        {
            NativeMap.Map.SetMaxAndMinZoomLevel(Map.MaxZoomLevel, Map.MinZoomLevel);
        }

        void UpdateMaxZoomLevel()
        {
            NativeMap.Map.SetMaxAndMinZoomLevel(Map.MaxZoomLevel, Map.MinZoomLevel);
        }

        void UpdateCenter()
        {
            NativeMap.Map.AnimateMapStatus(
                MapStatusUpdateFactory.NewLatLng(Map.Center.ToNative())
            );
        }

        void UpdateShowScaleBar()
        {
            NativeMap.ShowScaleControl(Map.ShowScaleBar);
        }

        void UpdateShowZoomControl()
        {
            NativeMap.ShowZoomControls(Map.ShowZoomControl);
        }
    }
}

