using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms.Platform.Android;
using Com.Baidu.Mapapi.Map;
using Com.Baidu.Mapapi.Model;
using BMap = Com.Baidu.Mapapi.Map;
using System.Collections.Specialized;
using System.Collections;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class PolylineImpl : BaseItemImpl<Polyline, BMap.MapView, BMap.Polyline>
    {
        protected override IList<Polyline> GetItems(Map map) => map.Polylines;

        protected override BMap.Polyline CreateNativeItem(Polyline item)
        {
            PolylineOptions options = new PolylineOptions();

            List<LatLng> points = new List<LatLng>();
            foreach (var point in item.Points) {
                points.Add(point.ToNative());
            }
            options.InvokePoints(points);

            options.InvokeWidth(item.Width);
            options.InvokeColor(item.Color.ToAndroid());

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

            if (Annotation.TitleProperty.PropertyName == e.PropertyName)
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

