using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms.Platform.Android;
using Com.Baidu.Mapapi.Map;
using BMap = Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class CircleImpl : BaseItemImpl<Circle, BMap.MapView, BMap.Circle>
    {
        protected override IList<Circle> GetItems(Map map) => map.Circles;

        protected override BMap.Circle CreateNativeItem(Circle item)
        {
            CircleOptions options = new CircleOptions()
                .InvokeCenter(item.Coordinate.ToNative())
                .InvokeRadius((int)item.Radius)
                .InvokeStroke(new Stroke(item.Width, item.Color.ToAndroid()))
                .InvokeFillColor(item.FillColor.ToAndroid());

            BMap.Circle circle = (BMap.Circle)NativeMap.Map.AddOverlay(options);
            item.NativeObject = circle;

            return circle;
        }

        protected override void UpdateNativeItem(Circle item)
        {
            throw new NotImplementedException();
        }

        protected override void RemoveNativeItem(Circle item)
        {
            ((BMap.Circle)item.NativeObject).Remove();
        }

        protected override void RemoveNativeItems(IList<Circle> items)
        {
            foreach (Circle item in items) {
                ((BMap.Circle)item.NativeObject).Remove();
            }
        }

        internal override void OnMapPropertyChanged(PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Circle item = (Circle)sender;
            BMap.Circle native = (BMap.Circle)item?.NativeObject;
            if (null == native) {
                return;
            }

            if (Circle.CoordinateProperty.PropertyName == e.PropertyName) {
                native.Center = item.Coordinate.ToNative();
                return;
            }

            if (Circle.RadiusProperty.PropertyName == e.PropertyName) {
                native.Radius = (int)item.Radius;
                return;
            }
        }
    }
}

