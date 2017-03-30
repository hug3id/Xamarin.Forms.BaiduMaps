using System;
using Foundation;

using BMapBinding;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal class LocationServiceImpl : BMKLocationServiceDelegate, ILocationService
    {
        BMKLocationService native;
        BMKMapView mapView;
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

        void ILocationService.Start()
        {
            native.StartUserLocationService();
        }

        void ILocationService.Stop()
        {
            native.StopUserLocationService();
        }

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

            if (userLocation.Location == null) {
                return;
            }

            LocationUpdated?.Invoke(this, new LocationUpdatedEventArgs {
                Coordinate = userLocation.Location.Coordinate.ToUnity(),
                Direction = userLocation.Heading?.TrueHeading ?? double.NaN,
                Altitude = userLocation.Location.Altitude,
                Accuracy = Math.Max(userLocation.Location.HorizontalAccuracy,
                                    userLocation.Location.VerticalAccuracy),
                Satellites = -1
            });
        }

        public override void DidUpdateUserHeading(BMKUserLocation userLocation)
        {
            DidUpdateBMKUserLocation(userLocation);
        }
    }
}

