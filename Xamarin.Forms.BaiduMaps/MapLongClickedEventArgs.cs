using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class MapLongClickedEventArgs : EventArgs
    {
        public Coordinate Coordinate { get; }

        public MapLongClickedEventArgs(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}

