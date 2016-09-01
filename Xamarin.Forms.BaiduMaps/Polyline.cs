using System.Collections.ObjectModel;

namespace Xamarin.Forms.BaiduMaps
{
    public class Polyline : Annotation
    {
        // Color
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            propertyName: nameof(Color),
            returnType: typeof(Color),
            declaringType: typeof(Polyline),
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
            declaringType: typeof(Polyline),
            defaultValue: default(int)
        );

        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Points
        public static readonly BindableProperty PointsProperty = BindableProperty.Create(
            propertyName: nameof(Points),
            returnType: typeof(ObservableCollection<Coordinate>),
            declaringType: typeof(Polyline),
            defaultValue: default(ObservableCollection<Coordinate>)
        );

        public ObservableCollection<Coordinate> Points
        {
            get { return (ObservableCollection<Coordinate>)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
    }
}

