using System;
using System.Runtime.InteropServices;
using CoreLocation;
using Foundation;

namespace BMapMain
{
	public enum BMKLogoPosition : uint
	{
		LeftBottom = 0,
		LeftTop,
		CenterBottom,
		CenterTop,
		RightBottom,
		RightTop
	}

	public enum BMKSwitchIndoorFloorError : uint
	{
		Success = 0,
		Failed,
		NotFocused,
		NotExist
	}

	public enum BMKUserTrackingMode : uint
	{
		None = 0,
		Follow,
		FollowWithHeading
	}

    //[Verify (InferredFromMemberPrefix)]
    public enum BMKAnnotationViewDragState : uint
    {
        None = 0,
        Starting,
        Dragging,
        Canceling,
        Ending
    }

	/*static class CFunctions
	{
		// extern NSString * BMKGetMapApiMapComponentVersion () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern NSString BMKGetMapApiMapComponentVersion ();

		// extern BOOL BMKCheckMapComponentIsLegal () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		//[Verify (PlatformInvoke)]
		static extern bool BMKCheckMapComponentIsLegal ();
	}

	public enum EnPermissionStatus
	{
		Ok = 0,
		ServerError = -200,
		NetworkError = -300
	}

	public enum BMKMapModule : uint
	{
		BMKMapModuleTile = 0
	}

	public enum BmkCoordType : uint
	{
		Gps = 0,
		Common
	}

	//[Verify (InferredFromMemberPrefix)]
	public enum BMKMapType : uint
	{
		None = 0,
		Standard = 1,
		Satellite = 2
	}

	public enum BMKErrorCode : uint
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
		FloorError
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
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKCoordinateSpan
	{
		public double latitudeDelta;

		public double longitudeDelta;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKCoordinateBounds
	{
		public CLLocationCoordinate2D northEast;

		public CLLocationCoordinate2D southWest;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKCoordinateRegion
	{
		public CLLocationCoordinate2D center;

		public BMKCoordinateSpan span;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKGeoPoint
	{
		public int latitudeE6;

		public int longitudeE6;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKMapPoint
	{
		public double x;

		public double y;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKMapSize
	{
		public double width;

		public double height;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct BMKMapRect
	{
		public BMKMapPoint origin;

		public BMKMapSize size;
	}

	[Verify (匿名结构)]
	[StructLayout (LayoutKind.Sequential)]
	public struct _flag
	{
		public uint keepAlive;

		public uint levelCrossFade;

		public uint drawingDisabled;

		public uint usesTiledLayer;
	}

	public enum BMKUserTrackingMode : uint
	{
		None = 0,
		Follow,
		FollowWithHeading
	}

	public enum BMKLogoPosition : uint
	{
		LeftBottom = 0,
		LeftTop,
		CenterBottom,
		CenterTop,
		RightBottom,
		RightTop
	}

	public enum BMKSwitchIndoorFloorError : uint
	{
		Success = 0,
		Failed,
		NotFocused,
		NotExist
	}*/

	//[Verify (InferredFromMemberPrefix)]
	public enum BMKOfflineStatus : uint
	{
		Update = 0,
		Zipcnt = 1,
		Unzip = 2,
		Errzip = 3,
		Newver = 4,
		Unzipfinish = 5,
		Add = 6
	}

	//[Verify (InferredFromMemberPrefix)]
	public enum BMKPinAnnotationColor : uint
	{
		Red = 0,
		Green,
		Purple
	}
}
