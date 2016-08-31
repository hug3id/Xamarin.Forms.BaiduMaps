using System;
using System.Runtime.InteropServices;
using Foundation;

namespace BMapRadar
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

	/*static class CFunctions
	{
		// extern NSString * BMKGetMapApiRadarComponentVersion () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern NSString BMKGetMapApiRadarComponentVersion ();

		// extern BOOL BMKCheckRadarComponentIsLegal () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool BMKCheckRadarComponentIsLegal ();
	}*/
}
