using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class Circle : Annotation
    {
        // Color
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            propertyName: nameof(Color),
            returnType: typeof(Color),
            declaringType: typeof(Circle),
            defaultValue: default(Color)
        );

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Width
        public static readonly BindableProperty WidthProperty = BindableProperty.Create(
            propertyName: nameof(Width),
            returnType: typeof(int),
            declaringType: typeof(Circle),
            defaultValue: default(int)
        );

        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Radius
        public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
            propertyName: nameof(Radius),
            returnType: typeof(double),
            declaringType: typeof(Circle),
            defaultValue: default(double)
        );

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        // FillColor
        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
            propertyName: nameof(FillColor),
            returnType: typeof(Color),
            declaringType: typeof(Circle),
            defaultValue: default(Color)
        );

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
    }
}

