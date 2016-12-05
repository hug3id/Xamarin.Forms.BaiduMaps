using System;

using Android.Widget;
using Xamarin.Forms.Platform.Android;

using Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    public partial class MapRenderer
    {
        void OnMapClick(object sender, BaiduMap.MapClickEventArgs e)
        {
            Map.SendBlankClicked(e.P0.ToUnity());
        }

        void OnMapPoiClick(object sender, BaiduMap.MapPoiClickEventArgs e)
        {
            Map.SendPoiClicked(new Poi {
                Coordinate = e.P0.Position.ToUnity(),
                Description = e.P0.Name
            });
        }

        void OnMapDoubleClick(object sender, BaiduMap.MapDoubleClickEventArgs e)
        {
            Map.SendDoubleClicked(e.P0.ToUnity());
        }

        void OnMapLongClick(object sender, BaiduMap.MapLongClickEventArgs e)
        {
            Map.SendLongClicked(e.P0.ToUnity());
        }

        void OnMarkerClick(object sender, BaiduMap.MarkerClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.P0.Title)) {
                TextView view = new TextView(Context);
                view.SetPadding(20, 20, 20, 20);
                view.SetBackgroundColor(Color.White.ToAndroid());
                view.Background.SetAlpha(100);
                view.Text = e.P0.Title;

                NativeMap.Map.ShowInfoWindow(
                    new InfoWindow(view, e.P0.Position, -e.P0.Icon.Bitmap.Height)
                );
            }

            Map.Pins.Find(e.P0)?.SendClicked();
        }

        void OnMarkerDragStart(object sender, BaiduMap.MarkerDragStartEventArgs e)
        {
            NativeMap.Map.HideInfoWindow();
            Map.Pins.Find(e.P0)?.SendDrag(AnnotationDragState.Starting);
        }

        void OnMarkerDrag(object sender, BaiduMap.MarkerDragEventArgs e)
        {
            Pin pin = Map.Pins.Find(e.P0);
            if (null != pin) {
                pinImpl.NotifyUpdate(pin);
                pin.SendDrag(AnnotationDragState.Dragging);
            }
        }

        void OnMarkerDragEnd(object sender, BaiduMap.MarkerDragEndEventArgs e)
        {
            Pin pin = Map.Pins.Find(e.P0);
            if (null != pin) {
                pinImpl.NotifyUpdate(pin);
                pin.SendDrag(AnnotationDragState.Ending);
            }
        }

        void MapStatusChangeFinish(object sender, BaiduMap.MapStatusChangeFinishEventArgs e)
        {
            Map.SetValueSilent(Map.CenterProperty, e.P0.Target.ToUnity());
            Map.SetValueSilent(Map.ZoomLevelProperty, e.P0.Zoom);
            Map.SendStatusChanged();
        }

        public void OnMapLoaded()
        {
            Map.Projection = new ProjectionImpl(NativeMap);
            NativeMap.OnResume();
            Map.SendLoaded();
        }
    }
}

