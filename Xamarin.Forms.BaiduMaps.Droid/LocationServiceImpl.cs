using System;
using System.Diagnostics;

using Android.Content;
using Com.Baidu.Location;
using BMap = Com.Baidu.Mapapi.Map;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class LocationServiceImpl : Java.Lang.Object, IBDLocationListener, LocationService
    {
        private LocationClient native;
        private BMap.BaiduMap map;

        public LocationServiceImpl(BMap.BaiduMap map, Context context)
        {
            this.map = map;

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

        ~LocationServiceImpl()
        {
            native.UnRegisterLocationListener(this);
        }

        public void Start()
        {
            native.Start();
        }

        public void Stop()
        {
            native.Stop();
        }

        public void OnReceiveLocation(BDLocation location)
        {
            switch (location.LocType) {
                default:break;
                    
                case BDLocation.TypeServerError:
                case BDLocation.TypeNetWorkException:
                case BDLocation.TypeCriteriaException:
                    Failed?.Invoke(this, new LocationFailedEventArgs("定位失败"));
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
                    map.SetMyLocationData(loc);

                    LocationUpdated?.Invoke(this, new LocationUpdatedEventArgs {
                        Coordinate = new Coordinate(loc.Latitude, loc.Longitude),
                        Direction = loc.Direction,
                        Altitude = location.Altitude,
                        Accuracy = loc.Accuracy
                    });
                    break;
            }
        }

        public event EventHandler<LocationFailedEventArgs> Failed;
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;
    }
}

