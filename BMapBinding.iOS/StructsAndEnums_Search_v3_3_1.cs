using System;
using System.Runtime.InteropServices;
using CoreLocation;
using Foundation;

namespace BMapBinding
{
    //[Verify (InferredFromMemberPrefix)]
    public enum BMK
    {
        InvalidCoordinate = -1,
        CarTrafficFIRST = 60,
        CarTimeFirst = 0,
        CarDisFirst,
        CarFeeFirst,
        BusTimeFirst,
        BusTransferFirst,
        BusWalkFirst,
        BusNoSubway,
        TypeCityList = 7,
        TypePoiList = 11,
        TypeAreaPoiList = 21,
        TypeAreaMultiPoiList = 45
    }

    /*public enum BMKErrorCode : uint
    {
        Ok = 0,
        Connect = 2,
        Data = 3,
        RouteAddr = 4,
        ResultNotFound = 100,
        LocationFailed = 200,
        PermissionCheckFailure = 300,
        Parse = 310
    }

    public enum BMKPermissionCheckResultCode
    {
        ConnectError = -300,
        DataError = -200,
        Ok = 0,
        KeyError = 101,
        McodeError = 102,
        UidKeyError = 200,
        KeyForbiden = 201
    }

    public enum BMKSearchErrorCode : uint
    {
        NoError = 0,
        AmbiguousKeyword,
        AmbiguousRoureAddr,
        NotSupportBus,
        NotSupportBus2city,
        ResultNotFound,
        StEnTooNear,
        KeyError,
        NetwokrError,
        NetwokrTimeout,
        PermissionUnfinished,
        IndoorIdError,
        FloorError,
        IndoorRouteNoInBuilding,
        IndoorRouteNoInSameBuilding,
        ParameterError
    }

    public enum BMKOpenErrorCode : uint
    {
        NoError = 0,
        WebMap,
        OptionNull,
        NotSupport,
        PoiDetailUidNull,
        PoiNearbyKeywordNull,
        RouteStartError,
        RouteEndError,
        PanoramaUidError,
        PanoramaAbsent,
        PermissionUnfinished,
        KeyError,
        NetwokrError
    }*/

    public enum BMKTransitStepType : uint
    {
        Busline = 0,
        Subway = 1,
        Wakling = 2
    }

    public enum BMKMassTransitType : uint
    {
        Subway = 0,
        Train = 1,
        Plane = 2,
        Busline = 3,
        Driving = 4,
        Wakling = 5,
        Coach = 6
    }

    public enum BMKIndoorStepNodeType : uint
    {
        Elevator = 1,
        Escalator = 2,
        Stair = 3,
        SecurityCheck = 4
    }

    public enum BMKTransitPolicy : uint
    {
        TimeFirst = 3,
        TransferFirst = 4,
        WalkFirst = 5,
        NoSubway = 6
    }

    public enum BMKMassTransitIncityPolicy : uint
    {
        Recommend = 0,
        TransferFirst = 1,
        WalkFirst = 2,
        NoSubway = 3,
        TimeFirst = 4,
        SubwayFirst = 5
    }

    public enum BMKMassTransitIntercityPolicy : uint
    {
        TimeFirst = 0,
        StartEarly = 1,
        PriceFirst = 2
    }

    public enum BMKMassTransitIntercityTransPolicy : uint
    {
        TrainFirst = 0,
        PlaneFirst = 1,
        BusFirst = 2
    }

    public enum BMKDrivingPolicy
    {
        BlkFirst = -1,
        TimeFirst = 0,
        DisFirst = 1,
        FeeFirst
    }

    public enum BMKDrivingRequestTrafficType : uint
    {
        None = 0,
        PathAndTraffice = 1
    }

    public enum BMKPoiSortType : uint
    {
        Composite = 0,
        Distance
    }

    public enum BMKRoutePlanShareURLType : uint
    {
        Drive = 0,
        Walk = 1,
        Ride = 2,
        Transit = 3
    }
}
