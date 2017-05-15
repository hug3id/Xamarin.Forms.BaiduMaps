using System;

namespace BMapBinding
{
    public enum BMKRadarSortType : uint
    {
        DistanceFromNearToFar = 0,
        DistanceFromFarToNear,
        TimeFromPastToRecent,
        TimeFromRecentToPast
    }

    public enum BMKRadarErrorCode : uint
    {
        NoError = 0,
        NoResult,
        AkNotBind,
        NetwokrError,
        NetwokrTimeout,
        PermissionUnfinished,
        AkError,
        UseridNotExist,
        ForbidByUser,
        ForbidByAdmin
    }
}
