using Foundation;
using UIKit;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal static class XImageImpl
    {
        internal static UIImage ToNative(this XImage image)
        {
            switch (image.Source)
            {
                default:
                    return null;

                case ImageSource.File:
                    return UIImage.FromFile(image.FileName);

                case ImageSource.Bundle:
                    return UIImage.FromBundle(image.BundleName);

                //case ImageSource.Resource:
                //    throw new NotImplementedException();

                case ImageSource.Stream:
                    return UIImage.LoadFromData(NSData.FromStream(image.Stream));
            }
        }
    }
}

