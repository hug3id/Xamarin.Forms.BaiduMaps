using System;
using System.Diagnostics;
using Android.Content;
using Com.Baidu.Location;
using BMap = Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class LocationServiceImpl : Java.Lang.Object, IBDLocationListener, ILocationService
    {
        private BMap.MapView mapView;
        private LocationClient native;

        public LocationServiceImpl(BMap.MapView mapView, Context context)
        {
            this.mapView = mapView;

            LocationClientOption option = new LocationClientOption();
            option.SetLocationMode(LocationClientOption.LocationMode.HightAccuracy);
            option.CoorType = "bd09ll"; // gcj02 by default
            option.ScanSpan = 1000; // 0 by default(just once)
            option.SetIsNeedAddress(false); // false by default
            option.OpenGps = true; // false by default
            option.LocationNotify = true; // false by default
            option.SetIsNeedLocationDescribe(false); // 通过 getLocationDescribe 获取语义化结果
            option.SetIsNeedLocationPoiList(false); // 通过 getPoiList 获取
            option.IsIgnoreKillProcess = false;
            option.IsIgnoreCacheException = false;
            option.SetEnableSimulateGps(false);

            native = new LocationClient(context);
            native.LocOption = option;
            native.RegisterLocationListener(this);
        }

        internal void Unregister()
        {
            native.UnRegisterLocationListener(this);
        }

        public void Start()
        {
            native.Start();
            stopped = false;
        }

        public void Stop()
        {
            stopped = true;
            native.Stop();
        }

        bool stopped = true;
        public void OnReceiveLocation(BDLocation location)
        {
            if (stopped) {
                return;
            }

            //Debug.WriteLine("LocType: " + location.LocType);
            switch (location.LocType) {
                default:break;
                    
                case BDLocation.TypeServerError:
                case BDLocation.TypeNetWorkException:
                case BDLocation.TypeCriteriaException:
                    break;

                case BDLocation.TypeGpsLocation:
                case BDLocation.TypeNetWorkLocation:
                case BDLocation.TypeOffLineLocation:
                    BMap.MyLocationData loc = new BMap.MyLocationData.Builder()
                        .Accuracy(location.Radius)
                        .Direction(location.Direction)
                        .Latitude(location.Latitude)
                        .Longitude(location.Longitude)
                        .Build();
                    mapView.Map.SetMyLocationData(loc);

                    LocationUpdated?.Invoke(this, new LocationUpdatedEventArgs {
                        Coordinate = new Coordinate(loc.Latitude, loc.Longitude),
                        Direction = location.Direction,
                        Accuracy = location.HasRadius ? location.Radius : double.NaN,
                        Altitude = location.HasAltitude ? location.Altitude : double.NaN,
                        Satellites = location.SatelliteNumber,
                        Type = location.LocTypeDescription
                    });
                    return;
            }

            Failed?.Invoke(this, new LocationFailedEventArgs(location.LocType.ToString()));
        }

        public void OnConnectHotSpotMessage(string p0, int p1)
        {
            //throw new NotImplementedException();
        }

        public event EventHandler<LocationFailedEventArgs> Failed;
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;
    }
}

