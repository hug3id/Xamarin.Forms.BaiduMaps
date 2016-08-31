using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class MapPoiClickedEventArgs : EventArgs
    {
        public Poi Poi { get; }

        public MapPoiClickedEventArgs(Poi poi)
        {
            Poi = Poi;
        }
    }

    public class Poi
    {
        public Coordinate Coordinate { get; set; }
        public string Description { get; set; }
    }
}

