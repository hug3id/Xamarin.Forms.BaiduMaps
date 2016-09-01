using System;
using System.Collections.Generic;

namespace Xamarin.Forms.BaiduMaps
{
    public enum OfflinePackageType
    {
        China,
        Province,
        City
    }

    public class OfflinePackage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OfflinePackageType Type { get; set; }
        public int Size { get; set; }
        public List<OfflinePackage> Children { get; set; }
    }

    public enum OfflinePackageStatus
    {
        Undefined = 0,
        Downloading,
        Waiting,
        Suspended,
        Finish,
        MD5Error,
        NetError,
        IOError,
        WifiError,
        FormatError,
        Installing
    }

    public class OfflinePackageInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TotalSize { get; set; }
        public int CurrentSize { get; set; }
        public Coordinate Center { get; set; }
        public int Ration { get; set; }
        public OfflinePackageStatus Status { get; set; }
        public bool IsUpdate { get; set; }
    }

    public class OfflineMapAddedEventArgs : EventArgs
    {
        public int AddedNumber { get; }
        public OfflineMapAddedEventArgs(int addedNumber)
        {
            AddedNumber = addedNumber;
        }
    }

    public class OfflineMapDownloadingEventArgs : EventArgs
    {
        public int CityID { get; }
        public OfflineMapDownloadingEventArgs(int cityID)
        {
            CityID = cityID;
        }
    }

    public class OfflineMapHasUpdateEventArgs : EventArgs
    {
        public int CityID { get; }
        public OfflineMapHasUpdateEventArgs(int cityID)
        {
            CityID = cityID;
        }
    }

    public interface IOfflineMap
    {
        List<OfflinePackage> HotList { get; }
        List<OfflinePackage> AllList { get; }
        List<OfflinePackageInfo> Current { get; }
        List<OfflinePackage> Search(string city);

        bool Start(int id);
        bool Pause(int id);
        bool Update(int id);
        bool Remove(int id);

        event EventHandler<OfflineMapAddedEventArgs> Added;
        event EventHandler<OfflineMapDownloadingEventArgs> Downloading;
        event EventHandler<OfflineMapHasUpdateEventArgs> HasUpdate;
    }
}

