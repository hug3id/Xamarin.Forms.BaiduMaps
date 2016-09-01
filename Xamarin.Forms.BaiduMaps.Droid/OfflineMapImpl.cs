using System;
using System.Collections.Generic;

using Com.Baidu.Mapapi.Map.Offline;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    internal class OfflineMapImpl : Java.Lang.Object, IOfflineMap, IMKOfflineMapListener
    {
        private MKOfflineMap native;
        public OfflineMapImpl()
        {
            native = new MKOfflineMap();
            native.Init(this);
        }

        public List<OfflinePackage> HotList
        {
            get {
                List<OfflinePackage> list = new List<OfflinePackage>();
                foreach (MKOLSearchRecord record in native.HotCityList) {
                    list.Add(record.ToUnity());
                }

                return list;
            }
        }

        public List<OfflinePackage> AllList
        {
            get {
                List<OfflinePackage> list = new List<OfflinePackage>();
                foreach (MKOLSearchRecord record in native.OfflineCityList) {
                    list.Add(record.ToUnity());
                }

                return list;
            }
        }

        public List<OfflinePackage> Search(string city)
        {
            List<OfflinePackage> list = new List<OfflinePackage>();
            foreach (MKOLSearchRecord record in native.SearchCity(city)) {
                list.Add(record.ToUnity());
            }

            return list;
        }

        public List<OfflinePackageInfo> Current
        {
            get {
                List<OfflinePackageInfo> list = new List<OfflinePackageInfo>();

                var all = native.AllUpdateInfo;
                if (null == all)
                {
                    return list;
                }

                foreach (MKOLUpdateElement el in all) {
                    list.Add(el.ToUnity());
                }

                return list;
            }
        }

        public bool Start(int id)
        {
            return native.Start(id);
        }

        public bool Pause(int id)
        {
            return native.Pause(id);
        }

        public bool Update(int id)
        {
            return native.Update(id);
        }

        public bool Remove(int id)
        {
            return native.Remove(id);
        }

        public event EventHandler<OfflineMapAddedEventArgs> Added;
        public event EventHandler<OfflineMapDownloadingEventArgs> Downloading;
        public event EventHandler<OfflineMapHasUpdateEventArgs> HasUpdate;

        public void OnGetOfflineMapState(int type, int state)
        {
            switch (type) {
                default: break;
                case MKOfflineMap.TypeNewOffline:
                    Added?.Invoke(this, new OfflineMapAddedEventArgs(state));
                    break;

                case MKOfflineMap.TypeVerUpdate:
                    HasUpdate?.Invoke(this, new OfflineMapHasUpdateEventArgs(state));
                    break;

                case MKOfflineMap.TypeDownloadUpdate:
                    Downloading?.Invoke(this, new OfflineMapDownloadingEventArgs(state));
                    break;
            }
        }
    }

    internal static class MKOLSearchRecordEx
    {
        public static OfflinePackage ToUnity(this MKOLSearchRecord record)
        {
            OfflinePackage package = new OfflinePackage {
                ID = record.CityID,
                Name = record.CityName,
                Size = record.Size,
                Children = new List<OfflinePackage>(),
                Type = (0 == record.CityType) ? OfflinePackageType.China
                     : (1 == record.CityType ? OfflinePackageType.Province
                     : OfflinePackageType.City)
            };

            if (null != record.ChildCities) {
                foreach (MKOLSearchRecord subItem in record.ChildCities) {
                    package.Children.Add(subItem.ToUnity());
                }
            }

            return package;
        }
    }

    internal static class MKOLUpdateElementEx
    {
        public static OfflinePackageInfo ToUnity(this MKOLUpdateElement el)
        {
            OfflinePackageStatus[] status = {
                OfflinePackageStatus.Undefined,
                OfflinePackageStatus.Downloading,
                OfflinePackageStatus.Waiting,
                OfflinePackageStatus.Suspended,
                OfflinePackageStatus.Finish,
                OfflinePackageStatus.MD5Error,
                OfflinePackageStatus.NetError,
                OfflinePackageStatus.IOError,
                OfflinePackageStatus.WifiError,
                OfflinePackageStatus.FormatError,
                OfflinePackageStatus.Installing
            };

            OfflinePackageInfo info = new OfflinePackageInfo {
                ID = el.CityID,
                Name = el.CityName,
                Center = el.GeoPt.ToUnity(),
                Ration = el.Ratio,
                TotalSize = el.Serversize,
                CurrentSize = el.Size,
                Status = status[el.Status],
                IsUpdate = el.Update
            };

            return info;
        }
    }
}

