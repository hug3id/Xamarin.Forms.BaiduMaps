using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

using CoreLocation;
using Foundation;

using BMapBinding;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal class PolylineImpl : BaseItemImpl<Polyline, BMKMapView, BMKPolyline>
    {
        protected override IList<Polyline> GetItems(Map map) => map.Polylines;

        protected override BMKPolyline CreateNativeItem(Polyline item)
        {
            CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[item.Points.Count];
            for (int i = 0; i < coords.Length; i++) {
                coords[i] = item.Points[i].ToNative();
            }

            BMKPolyline polyline = BMKPolyline.PolylineWithCoordinates(ref coords[0], (nuint)coords.Length);
            item.NativeObject = polyline;
            NativeMap.AddOverlay(polyline);

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
            NativeMap.RemoveOverlay((NSObject)item.NativeObject);
            item.NativeObject = null;
        }

        protected override void RemoveNativeItems(IList<Polyline> items)
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
            Polyline item = (Polyline)sender;
            BMKPolyline native = (BMKPolyline)item?.NativeObject;
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

                native.SetPolylineWithCoordinates(ref points[0], points.Length);
                return;
            }

            if (Polyline.WidthProperty.PropertyName == e.PropertyName) {
                BMKPolylineView view = NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.LineWidth = item.Width;
                }

                return;
            }

            if (Polyline.ColorProperty.PropertyName == e.PropertyName) {
                BMKPolylineView view = NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.StrokeColor = item.Color.ToUIColor();
                }

                return;
            }
        }
    }
}

