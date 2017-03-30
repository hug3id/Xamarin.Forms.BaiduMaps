using System;

using System.Runtime.InteropServices;
using Foundation;

namespace BMapBinding
{
    public enum BMKCloudSearchType : uint
    {
        NoneSearch = 0,
        CloudLocalSearch = 1,
        CloudNearbySearch = 2,
        CloudBoundSearch = 3,
        CloudDetailSearch = 4,
        CloudRgcSearch = 5
    }

    public enum BMKCloudErrorCode
    {
        PermissionUnfinished = -4,
        NetwokrError = -3,
        NetwokrTimeout = -2,
        ResultNotFound = -1,
        NoError = 0,
        ServerError = 1,
        ParamError = 2
    }
}
