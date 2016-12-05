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
    internal class CircleImpl : BaseItemImpl<Circle, BMKMapView, BMKCircle>
    {
        protected override IList<Circle> GetItems(Map map) => map.Circles;

        protected override BMKCircle CreateNativeItem(Circle item)
        {
            BMKCircle circle = BMKCircle.CircleWithCenterCoordinate(
                item.Coordinate.ToNative(), item.Radius
            );

            item.NativeObject = circle;
            NativeMap.AddOverlay(circle);

            return circle;
        }

        protected override void UpdateNativeItem(Circle item)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveNativeItem(Circle item)
        {
            NativeMap.RemoveOverlay((NSObject)item.NativeObject);
        }

        protected override void RemoveNativeItems(IList<Circle> items)
        {
            NSObject[] list = new NSObject[items.Count];
            for (int i = 0; i < items.Count; i++) {
                list[i] = (NSObject)items[i].NativeObject;
            }

            NativeMap.RemoveOverlays(list);
        }

        internal override void OnMapPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Circle item = (Circle)sender;
            BMKCircle native = (BMKCircle)item?.NativeObject;
            if (null == native) {
                return;
            }

            if (Annotation.TitleProperty.PropertyName == e.PropertyName)
            {
                native.Title = item.Title;
                return;
            }

            if (Annotation.CoordinateProperty.PropertyName == e.PropertyName) {
                native.Coordinate = item.Coordinate.ToNative();
                return;
            }

            if (Circle.RadiusProperty.PropertyName == e.PropertyName) {
                native.Radius = item.Radius;
                return;
            }

            if (Circle.WidthProperty.PropertyName == e.PropertyName) {
                BMKCircleView view = (BMKCircleView)NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.LineWidth = item.Width;
                }
                return;
            }

            if (Circle.ColorProperty.PropertyName == e.PropertyName) {
                BMKCircleView view = (BMKCircleView)NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.StrokeColor = item.Color.ToUIColor();
                }
                return;
            }

            if (Circle.FillColorProperty.PropertyName == e.PropertyName) {
                BMKCircleView view = (BMKCircleView)NativeMap.ViewForAnnotation(native);
                if (view != null) {
                    view.FillColor = item.Color.ToUIColor();
                }
                return;
            }
        }
    }
}

