using System;
using System.ComponentModel;
using System.Diagnostics;

using AG = Android.Graphics;
using Xamarin.Forms.Platform.Android;
using BMap = Com.Baidu.Mapapi.Map;
using Android.Widget;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    public partial class MapRenderer : ViewRenderer<Map, BMap.MapView>, BMap.BaiduMap.IOnMapLoadedCallback
    {
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
                circleImpl.Unregister(Map);

                NativeMap.Map.Clear();
                NativeMap.OnDestroy();
                //NativeMap.Dispose();
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
                SetNativeControl(new BMap.MapView(Context));
            }

            if (null != e.OldElement) {
                var oldMap = (Map)e.OldElement;
                oldMap.Pins.Clear();

                var oldMapView = (BMap.MapView)Control;
                oldMapView.OnDestroy();
                oldMapView.Dispose();
            }

            if (null != e.NewElement)
            {
                Map.LocationService = new LocationServiceImpl(NativeMap.Map, Context);

                NativeMap.Map.MapClick += (_, ex) => {
                    Map.SendBlankClicked(ex.P0.ToUnity());
                };

                NativeMap.Map.MapPoiClick += (_, ex) => {
                    Poi poi = new Poi {
                        Coordinate = ex.P0.Position.ToUnity(),
                        Description = ex.P0.Name
                    };

                    Map.SendPoiClicked(poi);
                };

                NativeMap.Map.MapDoubleClick += (_, ex) => {
                    Map.SendDoubleClicked(ex.P0.ToUnity());
                };

                NativeMap.Map.MapLongClick += (_, ex) => {
                    Map.SendLongClicked(ex.P0.ToUnity());
                };

                NativeMap.Map.MarkerClick += (_, ex) => {
                    if (!string.IsNullOrEmpty(ex.P0.Title)) {
                        TextView view = new TextView(Context);
                        view.SetPadding(20, 20, 20, 20);
                        view.SetBackgroundColor(Color.White.ToAndroid());
                        view.Background.SetAlpha(100);
                        view.Text = ex.P0.Title;

                        NativeMap.Map.ShowInfoWindow(
                            new BMap.InfoWindow(view, ex.P0.Position, -60)
                        );
                    }

                    Map.Pins.Find(ex.P0)?.SendClicked();
                };

                NativeMap.Map.MarkerDragStart += (_, ex) => {
                    NativeMap.Map.HideInfoWindow();
                    Map.Pins.Find(ex.P0)?.SendDrag(AnnotationDragState.Starting);
                };

                NativeMap.Map.MarkerDragEnd += (_, ex) => {
                    Pin pin = Map.Pins.Find(ex.P0);
                    if (null != pin) {
                        pinImpl.NotifyUpdate(pin);
                        pin.SendDrag(AnnotationDragState.Ending);
                    }
                };

                NativeMap.Map.MarkerDrag += (_, ex) => {
                    Pin pin = Map.Pins.Find(ex.P0);
                    if (null != pin) {
                        pinImpl.NotifyUpdate(pin);
                        pin.SendDrag(AnnotationDragState.Dragging);
                    }
                };

                NativeMap.Map.MapStatusChange += MapStatusChanged;
                NativeMap.Map.SetOnMapLoadedCallback(this);

                NativeMap.ShowZoomControls(false);

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

        public void OnMapLoaded()
        {
            Map.Projection = new ProjectionImpl(NativeMap);
            NativeMap.OnResume();
            Map.SendLoaded();
        }

        private void MapStatusChanged(object sender, BMap.BaiduMap.MapStatusChangeEventArgs e)
        {
            bool changed = false;

            Coordinate center = e.P0.Target.ToUnity();
            if (Map.Center != center) {
                Map.SetValueSilent(Map.CenterProperty, center);
                changed = true;
            }

            float zoom = e.P0.Zoom;
            if (Math.Abs(Map.ZoomLevel - zoom) > 0.01) {
                Map.SetValueSilent(Map.ZoomLevelProperty, zoom);
                changed = true;
            }

            if (changed) {
                Map.SendStatusChanged();
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

            /*if (Map.ShowCompassProperty.PropertyName == e.PropertyName)
            {
                UpdateShowCompass();
                return;
            }*/

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
            }

            System.Diagnostics.Debug.WriteLine("OnElementPropertyChanged: " + e.PropertyName);
            base.OnElementPropertyChanged(sender, e);
        }

        private void UpdateMapType()
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

        private void UpdateUserTrackingMode()
        {
            BMap.MyLocationConfiguration.LocationMode mode;

            switch (Map.UserTrackingMode) {
                default:
                case UserTrackingMode.None:
                    mode = BMap.MyLocationConfiguration.LocationMode.Normal;
                    break;

                case UserTrackingMode.Follow:
                    mode = BMap.MyLocationConfiguration.LocationMode.Following;
                    break;

                case UserTrackingMode.FollowWithCompass:
                    mode = BMap.MyLocationConfiguration.LocationMode.Compass;
                    break;
            }

            NativeMap.Map.SetMyLocationConfigeration(
                new BMap.MyLocationConfiguration(mode, true, null)
            );

            if (UserTrackingMode.FollowWithCompass != Map.UserTrackingMode) {
                // 恢复俯视角
                BMap.MapStatusUpdate overlook = BMap.MapStatusUpdateFactory.NewMapStatus(
                    new BMap.MapStatus.Builder(NativeMap.Map.MapStatus).Rotate(0).Overlook(0).Build()
                );

                NativeMap.Map.AnimateMapStatus(overlook);
            }
        }

        private void UpdateShowUserLocation()
        {
            NativeMap.Map.MyLocationEnabled = Map.ShowUserLocation;
        }

        /*private void UpdateShowCompass()
        {
            NativeMap.Map.UiSettings.CompassEnabled = Map.ShowCompass;
        }*/

        private void UpdateCompassPosition()
        {
            NativeMap.Map.CompassPosition = new AG.Point {
                X = (int)Map.CompassPosition.X,
                Y = (int)Map.CompassPosition.Y
            };
        }

        private void UpdateZoomLevel()
        {
            NativeMap.Map.AnimateMapStatus(
                BMap.MapStatusUpdateFactory.ZoomTo(Map.ZoomLevel)
            );
        }

        private void UpdateMinZoomLevel()
        {
            NativeMap.Map.SetMaxAndMinZoomLevel(Map.MaxZoomLevel, Map.MinZoomLevel);
        }

        private void UpdateMaxZoomLevel()
        {
            NativeMap.Map.SetMaxAndMinZoomLevel(Map.MaxZoomLevel, Map.MinZoomLevel);
        }

        private void UpdateCenter()
        {
            NativeMap.Map.AnimateMapStatus(
                BMap.MapStatusUpdateFactory.NewLatLng(Map.Center.ToNative())
            );
        }

        private void UpdateShowScaleBar()
        {
            NativeMap.ShowScaleControl(Map.ShowScaleBar);
        }

        protected BMap.MapView NativeMap => (BMap.MapView)Control;
        protected Map Map => (Map)Element;
    }
}

