using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

using Xamarin.Forms.Platform.Android;
using Com.Baidu.Mapapi.Map;
using Com.Baidu.Mapapi.Model;
using BMap = Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class PolylineImpl : BaseItemImpl<Polyline, BMap.MapView, BMap.Polyline>
    {
        protected override IList<Polyline> GetItems(Map map) => map.Polylines;

        protected override BMap.Polyline CreateNativeItem(Polyline item)
        {
            List<LatLng> points = new List<LatLng>();
            foreach (var point in item.Points) {
                points.Add(point.ToNative());
            }

            PolylineOptions options = new PolylineOptions()
                .InvokePoints(points)
                .InvokeWidth(item.Width)
                .InvokeColor(item.Color.ToAndroid());

            BMap.Polyline polyline = (BMap.Polyline)NativeMap.Map.AddOverlay(options);
            item.NativeObject = polyline;

            ((INotifyCollectionChanged)(IList)item.Points).CollectionChanged += (sender, e) => {
                OnItemPropertyChanged(item, new PropertyChangedEventArgs(Polyline.PointsProperty.PropertyName));
            };

            return polyline;
        }

        protected override void UpdateNativeItem(Polyline item)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveNativeItem(Polyline item)
        {
            ((BMap.Polyline)item.NativeObject).Remove();
        }

        protected override void RemoveNativeItems(IList<Polyline> items)
        {
            foreach (Polyline item in items) {
                ((BMap.Polyline)item.NativeObject).Remove();
            }
        }

        internal override void OnMapPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Polyline item = (Polyline)sender;
            BMap.Polyline native = (BMap.Polyline)item?.NativeObject;
            if (null == native) {
                return;
            }

            if (Polyline.TitleProperty.PropertyName == e.PropertyName)
            {
                return;
            }

            if (Polyline.PointsProperty.PropertyName == e.PropertyName)
            {
                List<LatLng> points = new List<LatLng>();
                foreach (Coordinate point in item.Points) {
                    points.Add(point.ToNative());
                }

                native.Points = points;
            }
        }
    }
}

