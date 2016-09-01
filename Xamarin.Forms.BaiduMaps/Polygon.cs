using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class Polygon : Polyline
    {
        // FillColor
        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
            propertyName: nameof(FillColor),
            returnType: typeof(Color),
            declaringType: typeof(Polygon),
            defaultValue: default(Color)
        );

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
    }
}
