using CoreGraphics;
using UIKit;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal static class ViewEx
    {
        internal static UIView ToNative(this View view, Rectangle size)
        {
            var renderer = Platform.iOS.Platform.GetRenderer(view);
            if (null == renderer) {
                Platform.iOS.Platform.SetRenderer(view,
                    Platform.iOS.Platform.CreateRenderer(view)
                );
                renderer = Platform.iOS.Platform.GetRenderer(view);
            }

            renderer.NativeView.Frame = new CGRect(size.X, size.Y, size.Width, size.Height);

            renderer.NativeView.AutoresizingMask = UIViewAutoresizing.All;
            renderer.NativeView.ContentMode = UIViewContentMode.ScaleToFill;
            renderer.Element.Layout(size);
            renderer.NativeView.SetNeedsLayout();
            return renderer.NativeView;
        }
    }
}

