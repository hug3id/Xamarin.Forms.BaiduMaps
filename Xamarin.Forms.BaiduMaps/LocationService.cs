using System;

namespace Xamarin.Forms.BaiduMaps
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        public Coordinate Coordinate { get; internal set; }
        public double Direction { get; internal set; }
        public double Altitude { get; internal set; }
        public double Accuracy { get; internal set; }
    }

    public class LocationFailedEventArgs : EventArgs
    {
        public string Message { get; }
        public LocationFailedEventArgs(string message)
        {
            Message = message;
        }
    }

    public interface LocationService
    {
        void Start();
        void Stop();

        //event EventHandler<EventArgs> Starting;
        //event EventHandler<EventArgs> Stopped;
        event EventHandler<LocationUpdatedEventArgs> LocationUpdated;
        event EventHandler<LocationFailedEventArgs> Failed;
    }
}

