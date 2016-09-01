using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class Pin : Annotation
    {
        // Animate
        public static readonly BindableProperty AnimateProperty = BindableProperty.Create(
            propertyName: nameof(Animate),
            returnType: typeof(bool),
            declaringType: typeof(Pin),
            defaultValue: default(bool)
        );

        public bool Animate
        {
            get { return (bool)GetValue(AnimateProperty); }
            set { SetValue(AnimateProperty, value); }
        }

        // Draggable
        public static readonly BindableProperty DraggableProperty = BindableProperty.Create(
            propertyName: nameof(Draggable),
            returnType: typeof(bool),
            declaringType: typeof(Pin),
            defaultValue: default(bool)
        );

        public bool Draggable
        {
            get { return (bool)GetValue(DraggableProperty); }
            set { SetValue(DraggableProperty, value); }
        }

        // Enabled3D
        public static readonly BindableProperty Enabled3DProperty = BindableProperty.Create(
            propertyName: nameof(Enabled3D),
            returnType: typeof(bool),
            declaringType: typeof(Pin),
            defaultValue: default(bool)
        );

        public bool Enabled3D
        {
            get { return (bool)GetValue(Enabled3DProperty); }
            set { SetValue(Enabled3DProperty, value); }
        }

        // Image
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            propertyName: nameof(Image),
            returnType: typeof(XImage),
            declaringType: typeof(Pin),
            defaultValue: default(XImage)
        );

        public XImage Image
        {
            get { return (XImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
}

