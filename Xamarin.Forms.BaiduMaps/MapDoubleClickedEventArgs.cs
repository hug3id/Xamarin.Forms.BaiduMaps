using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class MapDoubleClickedEventArgs : EventArgs
    {
        public Coordinate Coordinate { get; }

        public MapDoubleClickedEventArgs(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}

