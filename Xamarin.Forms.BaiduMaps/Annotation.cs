using System;

namespace Xamarin.Forms.BaiduMaps
{
    public abstract class Annotation : BaseItem
    {
        // Coordinate
        public static readonly BindableProperty CoordinateProperty = BindableProperty.Create(
            propertyName: nameof(Coordinate),
            returnType: typeof(Coordinate),
            declaringType: typeof(Annotation),
            defaultValue: default(Coordinate)
        );

        public Coordinate Coordinate
        {
            get { return (Coordinate)GetValue(CoordinateProperty); }
            set { SetValue(CoordinateProperty, value); }
        }

        // Title
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(Annotation),
            defaultValue: default(string)
        );

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /*// Subtitle
        public static readonly BindableProperty SubtitleProperty = BindableProperty.Create(
            propertyName: "Subtitle",
            returnType: typeof(string),
            declaringType: typeof(Annotation),
            defaultValue: default(string)
        );

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set { SetValue(SubtitleProperty, value); }
        }*/

        /*public event EventHandler<EventArgs> Selected;
        internal void SendSelected()
        {
            Selected?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> Deselected;
        internal void SendDeselected()
        {
            Deselected?.Invoke(this, EventArgs.Empty);
        }*/

        public event EventHandler<AnnotationDragEventArgs> Drag;
        internal void SendDrag(AnnotationDragState state)
        {
            Drag?.Invoke(this, new AnnotationDragEventArgs(state));
        }
    }
}

