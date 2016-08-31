using System;
using Foundation;

using BMapBase;
using BMapMain;
using BMapLocation;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal class LocationServiceImpl : BMKLocationServiceDelegate, LocationService
    {
        private BMKLocationService native;
        private BMKMapView mapView;

        public LocationServiceImpl(BMKMapView mapView)
        {
            this.mapView = mapView;

            native = new BMKLocationService();
            native.Delegate = this;
        }

        ~LocationServiceImpl()
        {
            native.Delegate = null;
        }

        void LocationService.Start()
        {
            native.StartUserLocationService();
        }

        void LocationService.Stop()
        {
            native.StopUserLocationService();
        }

        //public event EventHandler<EventArgs> Starting;
        //public event EventHandler<EventArgs> Stopped;
        public event EventHandler<LocationFailedEventArgs> Failed;
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;

        public override void WillStartLocatingUser()
        {
            //Starting?.Invoke(this, EventArgs.Empty);
        }

        public override void DidStopLocatingUser()
        {
            //Stopped?.Invoke(this, EventArgs.Empty);
        }

        public override void DidFailToLocateUserWithError(NSError error)
        {
            Failed?.Invoke(this, new LocationFailedEventArgs(error.ToString()));
        }

        public override void DidUpdateBMKUserLocation(BMKUserLocation userLocation)
        {
            mapView.UpdateLocationData(userLocation);

            LocationUpdated?.Invoke(this, new LocationUpdatedEventArgs {
                Coordinate = userLocation.Location.Coordinate.ToUnity(),
                Direction = userLocation.Heading?.TrueHeading ?? double.NaN,
                Altitude = userLocation.Location.Altitude,
                Accuracy = Math.Max(userLocation.Location.HorizontalAccuracy,
                                    userLocation.Location.VerticalAccuracy)
            });
        }

        public override void DidUpdateUserHeading(BMKUserLocation userLocation)
        {
            DidUpdateBMKUserLocation(userLocation);
        }
    }
}

