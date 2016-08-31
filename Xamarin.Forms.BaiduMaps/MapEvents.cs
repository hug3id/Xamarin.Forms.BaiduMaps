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

    public class MapDoubleClickedEventArgs : EventArgs
    {
        public Coordinate Coordinate { get; }
        public MapDoubleClickedEventArgs(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }

    public class MapLongClickedEventArgs : EventArgs
    {
        public Coordinate Coordinate { get; }
        public MapLongClickedEventArgs(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }

    public class Poi
    {
        public Coordinate Coordinate { get; set; }
        public string Description { get; set; }
    }

    public class MapPoiClickedEventArgs : EventArgs
    {
        public Poi Poi { get; }
        public MapPoiClickedEventArgs(Poi poi)
        {
            Poi = Poi;
        }
    }
}

