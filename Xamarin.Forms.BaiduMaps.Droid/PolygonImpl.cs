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
    internal class PolygonImpl : BaseItemImpl<Polygon, BMap.MapView, BMap.Polygon>
    {
        protected override IList<Polygon> GetItems(Map map) => map.Polygons;

        protected override BMap.Polygon CreateNativeItem(Polygon item)
        {
            List<LatLng> points = new List<LatLng>();
            foreach (var point in item.Points) {
                points.Add(point.ToNative());
            }

            PolygonOptions options = new PolygonOptions()
                .InvokePoints(points)
                .InvokeStroke(new Stroke(item.Width, item.Color.ToAndroid()))
                .InvokeFillColor(item.FillColor.ToAndroid());

            BMap.Polygon polygon = (BMap.Polygon)NativeMap.Map.AddOverlay(options);
            item.NativeObject = polygon;

            ((INotifyCollectionChanged)(IList)item.Points).CollectionChanged += (sender, e) => {
                OnItemPropertyChanged(item, new PropertyChangedEventArgs(Polygon.PointsProperty.PropertyName));
            };

            return polygon;
        }

        protected override void UpdateNativeItem(Polygon item)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveNativeItem(Polygon item)
        {
            ((BMap.Polygon)item.NativeObject).Remove();
        }

        protected override void RemoveNativeItems(IList<Polygon> items)
        {
            foreach (Polygon item in items) {
                ((BMap.Polygon)item.NativeObject).Remove();
            }
        }

        internal override void OnMapPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Polygon item = (Polygon)sender;
            BMap.Polygon native = (BMap.Polygon)item?.NativeObject;
            if (null == native) {
                return;
            }

            if (Polygon.TitleProperty.PropertyName == e.PropertyName) {
                return;
            }

            if (Polygon.PointsProperty.PropertyName == e.PropertyName) {
                List<LatLng> points = new List<LatLng>();
                foreach (Coordinate point in item.Points) {
                    points.Add(point.ToNative());
                }

                native.Points = points;
            }
        }
    }
}

