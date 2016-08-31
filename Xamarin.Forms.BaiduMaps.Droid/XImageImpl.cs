using Android.Graphics;
using Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal static class XImageImpl
    {
        internal static BitmapDescriptor ToNative(this XImage image)
        {
            switch (image.Source)
            {
                default:
                    return null;

                case ImageSource.File:
                    //return BitmapDescriptorFactory.FromFile(image.FileName);
                return BitmapDescriptorFactory.FromPath(image.FileName);

                case ImageSource.Bundle:
                    return BitmapDescriptorFactory.FromAsset(image.BundleName);

                //case ImageSource.Resource:
                //return BitmapDescriptorFactory.FromResource

                case ImageSource.Stream:
                    return BitmapDescriptorFactory.FromBitmap(BitmapFactory.DecodeStream(image.Stream));
            }
        }
    }
}

