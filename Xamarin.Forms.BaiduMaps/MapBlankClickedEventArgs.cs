using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class MapBlankClickedEventArgs : EventArgs
    {
        public Coordinate Coordinate { get; }

        public MapBlankClickedEventArgs(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}

