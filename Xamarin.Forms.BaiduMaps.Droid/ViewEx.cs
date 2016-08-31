using Android.Views;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal static class ViewEx
    {
        internal static ViewGroup ToNative(this View view, Rectangle size)
        {
            var renderer = Platform.Android.Platform.GetRenderer(view);
            if (null == renderer) {
                Platform.Android.Platform.SetRenderer(view,
                    Platform.Android.Platform.CreateRenderer(view)
                );
                renderer = Platform.Android.Platform.GetRenderer(view);
            }

            renderer.Tracker.UpdateLayout();
            var layoutParams = new ViewGroup.LayoutParams((int)size.Width, (int)size.Height);
            var viewGroup = renderer.ViewGroup;
            viewGroup.LayoutParameters = layoutParams;
            view.Layout(size);
            viewGroup.Layout(0, 0, (int)view.WidthRequest, (int)view.HeightRequest);

            return viewGroup;
        }
    }
}

