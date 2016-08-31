using System;
using System.Collections.Generic;

namespace Xamarin.Forms.BaiduMaps
{
    public class BaseItem : BindableObject
    {
        internal object NativeObject { get; set; }
        public object Tag { get; set; }

        public event EventHandler<EventArgs> Clicked;
        internal void SendClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    internal static class BaseItemHelper
    {
        public static T Find<T>(this IList<T> list, object native)
            where T : BaseItem
        {
            foreach (T item in list)
            {
                if (item.NativeObject == native)
                {
                    return item;
                }
            }

            return null;
        }
    }
}

