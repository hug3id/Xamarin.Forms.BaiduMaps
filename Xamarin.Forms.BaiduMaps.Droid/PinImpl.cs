using System;
using System.Collections.Generic;
using System.ComponentModel;

using Com.Baidu.Mapapi.Map;
using BMap = Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class PinImpl : BaseItemImpl<Pin, BMap.MapView, Marker>
    {
        protected override IList<Pin> GetItems(Map map) => map.Pins;

        protected override Marker CreateNativeItem(Pin item)
        {
            MarkerOptions options = new MarkerOptions()
                .InvokePosition(item.Coordinate.ToNative())
                .InvokeTitle(item.Title);

            if (item.Animate) {
                options.InvokeAnimateType(MarkerOptions.MarkerAnimateType.Grow);
            }

            options.Draggable(item.Draggable);
            options.Flat(!item.Enabled3D);

            BitmapDescriptor bitmap = item.Image?.ToNative();
            if (null == bitmap) {
                throw new Exception("必须提供一个图标");
            }
            options.InvokeIcon(bitmap);

            Marker marker = (Marker)NativeMap.Map.AddOverlay(options);
            item.NativeObject = marker;
  
            return marker;
        }

        protected override void UpdateNativeItem(Pin item)
        {
            Marker native = (Marker)item?.NativeObject;
            if (null == native) {
                return;
            }

            item.SetValueSilent(Pin.CoordinateProperty, native.Position.ToUnity());
        }

        protected override void RemoveNativeItem(Pin item)
        {
            NativeMap.Map.HideInfoWindow();
            ((Marker)item.NativeObject).Icon.Recycle();
            ((Marker)item.NativeObject).Remove();
        }

        protected override void RemoveNativeItems(IList<Pin> items)
        {
            foreach (Pin item in items) {
                RemoveNativeItem(item);
            }
        }

        internal override void OnMapPropertyChanged(PropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected override void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Pin item = (Pin)sender;
            Marker native = (Marker)item?.NativeObject;
            if (null == native) {
                return;
            }

            if (Pin.CoordinateProperty.PropertyName == e.PropertyName) {
                native.Position = item.Coordinate.ToNative();
                return;
            }

            if (Pin.TitleProperty.PropertyName == e.PropertyName) {
                native.Title = item.Title;
                return;
            }
        }
    }
}

