using System;
using System.Runtime.InteropServices;
using CoreLocation;
using Foundation;

namespace BMapSearch
{
	/*static class CFunctions
	{
		// extern NSString * BMKGetMapApiSearchComponentVersion () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern NSString BMKGetMapApiSearchComponentVersion ();

		// extern BOOL BMKCheckSearchComponentIsLegal () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool BMKCheckSearchComponentIsLegal ();
	}*/

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
	}*/

	public enum BMKTransitStepType : uint
	{
		Busline = 0,
		Subway = 1,
		Wakling = 2
	}

	public enum BMKTransitPolicy : uint
	{
		TimeFirst = 3,
		TransferFirst = 4,
		WalkFirst = 5,
		NoSubway = 6
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
