using System;

using Foundation;
using ObjCRuntime;
using CoreLocation;

using BMapBase;
using CoreGraphics;
using System.Runtime.InteropServices;

namespace BMapBase
{
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface BMKGeneralDelegate
	{
		// @optional -(void)onGetNetworkState:(int)iError;
		[Export("onGetNetworkState:")]
		void OnGetNetworkState(int iError);

		// @optional -(void)onGetPermissionState:(int)iError;
		[Export("onGetPermissionState:")]
		void OnGetPermissionState(int iError);
	}

	// @interface BMKMapManager : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKMapManager
	{
		// +(void)logEnable:(BOOL)enable module:(BMKMapModule)mapModule;
		[Static]
		[Export("logEnable:module:")]
		void LogEnable(bool enable, BMKMapModule mapModule);

		// -(BOOL)start:(NSString *)key generalDelegate:(id<BMKGeneralDelegate>)delegate;
		[Export("start:generalDelegate:")]
		bool Start(string key, BMKGeneralDelegate @delegate);

		// -(int)getTotalSendFlaxLength;
		[Export("getTotalSendFlaxLength")]
		//[Verify(MethodToProperty)]
		int TotalSendFlaxLength { get; }

		// -(int)getTotalRecvFlaxLength;
		[Export("getTotalRecvFlaxLength")]
		//[Verify(MethodToProperty)]
		int TotalRecvFlaxLength { get; }

		// -(BOOL)stop;
		[Export("stop")]
		bool Stop();
	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const BMKMapSize BMKMapSizeWorld __attribute__((visibility("default")));
		[Field("BMKMapSizeWorld", "__Internal")]
        //BMKMapSize BMKMapSizeWorld { get; }
        IntPtr BMKMapSizeWorld { get; }

		// extern const BMKMapRect BMKMapRectWorld __attribute__((visibility("default")));
		[Field("BMKMapRectWorld", "__Internal")]
		//BMKMapRect BMKMapRectWorld { get; }
        IntPtr BMKMapRectWorld { get; }

		// extern const BMKMapRect BMKMapRectNull __attribute__((visibility("default")));
		[Field("BMKMapRectNull", "__Internal")]
		//BMKMapRect BMKMapRectNull { get; }
        IntPtr BMKMapRectNull { get; }
	}

	// @interface BMKPlanNode : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKPlanNode
	{
		// @property (nonatomic, strong) NSString * cityName;
		[Export("cityName", ArgumentSemantic.Strong)]
		string CityName { get; set; }

		// @property (assign, nonatomic) NSInteger cityID;
		[Export("cityID")]
		nint CityID { get; set; }

		// @property (nonatomic, strong) NSString * name;
		[Export("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic) CLLocationCoordinate2D pt;
		[Export("pt", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Pt { get; set; }
	}

	// @interface BMKUserLocation : NSObject
	[BaseType(typeof(NSObject))]
	interface BMKUserLocation
	{
		// @property (readonly, getter = isUpdating, nonatomic) BOOL updating;
		[Export("updating")]
		bool Updating { [Bind("isUpdating")] get; }

		// @property (readonly, nonatomic, strong) CLLocation * location;
		[Export("location", ArgumentSemantic.Strong)]
		CLLocation Location { get; }

		// @property (readonly, nonatomic, strong) CLHeading * heading;
		[Export("heading", ArgumentSemantic.Strong)]
		CLHeading Heading { get; }

		// @property (nonatomic, strong) NSString * title;
		[Export("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * subtitle;
		[Export("subtitle", ArgumentSemantic.Strong)]
		string Subtitle { get; set; }
	}

}

