using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

using CoreLocation;
using Foundation;

using BMapBinding;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal class PolygonImpl : BaseItemImpl<Polygon, BMKMapView, BMKPolygon>
    {
        protected override IList<Polygon> GetItems(Map map) => map.Polygons;

        protected override BMKPolygon CreateNativeItem(Polygon item)
        {
            CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[item.Points.Count];
            for (int i = 0; i < coords.Length; i++) {
                coords[i] = item.Points[i].ToNative();
            }

            BMKPolygon polygon = BMKPolygon.PolygonWithCoordinates(ref coords[0], (nuint)coords.Length);
            item.NativeObject = polygon;
            NativeMap.AddOverlay(polygon);

            ((INotifyCollectionChanged)(IList)item.Points).CollectionChanged += (sender, e) => {
                OnItemPropertyChanged(item, new PropertyChangedEventArgs(Polyline.PointsProperty.PropertyName));
            };

            return polygon;
        }

        protected override void UpdateNativeItem(Polygon item)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveNativeItem(Polygon item)
        {
            NativeMap.RemoveOverlay((NSObject)item.NativeObject);
            item.NativeObject = null;
        }

        protected override void RemoveNativeItems(IList<Polygon> items)
        {
            NSObject[] list = new NSObject[items.Count];
            for (int i = 0; i < items.Count; i++) {
                list[i] = (NSObject)items[i].NativeObject;
                items[i].NativeObject = null;
            }

            NativeMap.RemoveOverlays(list);
        }

        internal override void OnMapPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Polygon item = (Polygon)sender;
            BMKPolygon native = (BMKPolygon)item?.NativeObject;
            if (null == native) {
                return;
            }

            if (Annotation.TitleProperty.PropertyName == e.PropertyName) {
                native.Title = item.Title;
                return;
            }

            if (Polyline.PointsProperty.PropertyName == e.PropertyName) {
                CLLocationCoordinate2D[] points = new CLLocationCoordinate2D[item.Points.Count];
                for (int i = 0; i < points.Length; i++) {
                    points[i] = item.Points[i].ToNative();
                }

                native.SetPolygonWithCoordinates(ref points[0], points.Length);
                return;
            }

            if (Polyline.WidthProperty.PropertyName == e.PropertyName) {
                BMKPolygonView view = NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.LineWidth = item.Width;
                }

                return;
            }

            if (Polyline.ColorProperty.PropertyName == e.PropertyName) {
                BMKPolygonView view = NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.StrokeColor = item.Color.ToUIColor();
                }

                return;
            }

            if (Polygon.FillColorProperty.PropertyName == e.PropertyName) {
                BMKPolygonView view = NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.FillColor = item.Color.ToUIColor();
                }

                return;
            }
        }
    }
}

