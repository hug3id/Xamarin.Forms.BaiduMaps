using System;
using System.Collections.Generic;

using BMapBinding;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    internal class OfflineMapImpl : BMKOfflineMapDelegate, IOfflineMap
    {
        private BMKOfflineMap native;
        public OfflineMapImpl()
        {
            native = new BMKOfflineMap();
            native.Delegate = this;
        }

        ~OfflineMapImpl()
        {
            native.Delegate = null;
        }

        public List<OfflinePackage> HotList
        {
            get {
                List<OfflinePackage> list = new List<OfflinePackage>();
                foreach (BMKOLSearchRecord record in native.HotCityList) {
                    list.Add(record.ToUnity());
                }

                return list;
            }
        }

        public List<OfflinePackage> AllList
        {
            get {
                List<OfflinePackage> list = new List<OfflinePackage>();
                foreach (BMKOLSearchRecord record in native.OfflineCityList) {
                    list.Add(record.ToUnity());
                }

                return list;
            }
        }

        public List<OfflinePackage> Search(string city)
        {
            List<OfflinePackage> list = new List<OfflinePackage>();
            foreach (BMKOLSearchRecord record in native.SearchCity(city)) {
                list.Add(record.ToUnity());
            }

            return list;
        }

        public List<OfflinePackageInfo> Current
        {
            get {
                List<OfflinePackageInfo> list = new List<OfflinePackageInfo>();

                var all = native.AllUpdateInfo;
                if (null == all) {
                    return list;
                }

                foreach (BMKOLUpdateElement el in all) {
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

        public override void OnGetOfflineMapState(BMKOfflineStatus type, int state)
        {
            switch (type) {
                default: break;
                case BMKOfflineStatus.Add:
                    Added?.Invoke(this, new OfflineMapAddedEventArgs(state));
                    break;

                case BMKOfflineStatus.Newver:
                    HasUpdate?.Invoke(this, new OfflineMapHasUpdateEventArgs(state));
                    break;

                case BMKOfflineStatus.Update:
                    Downloading?.Invoke(this, new OfflineMapDownloadingEventArgs(state));
                    break;
            }
        }
    }

    internal static class MKOLSearchRecordEx
    {
        public static OfflinePackage ToUnity(this BMKOLSearchRecord record)
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
                foreach (BMKOLSearchRecord subItem in record.ChildCities) {
                    package.Children.Add(subItem.ToUnity());
                }
            }

            return package;
        }
    }

    internal static class MKOLUpdateElementEx
    {
        public static OfflinePackageInfo ToUnity(this BMKOLUpdateElement el)
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
                Center = el.Pt.ToUnity(),
                Ration = el.Ratio,
                TotalSize = el.Serversize,
                CurrentSize = el.Size,
                Status = status[-1 == el.Status ? 0 : el.Status],
                IsUpdate = el.Update
            };

            return info;
        }
    }
}

