using System;

using Foundation;
using ObjCRuntime;
using CoreLocation;

namespace BMapBinding
{
    // @protocol BMKGeneralDelegate <NSObject>
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
        // +(BOOL)setCoordinateTypeUsedInBaiduMapSDK:(BMK_COORD_TYPE) coorType;
        [Static]
        [Export("setCoordinateTypeUsedInBaiduMapSDK:")]
        bool SetCoordinateTypeUsedInBaiduMapSDK(BMKCoordType coorType);

        // +(BMK_COORD_TYPE)getCoordinateTypeUsedInBaiduMapSDK;
        [Static]
        [Export("getCoordinateTypeUsedInBaiduMapSDK")]
        BMKCoordType CoordinateTypeUsedInBaiduMapSDK { get; }

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

    /*[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const BMKMapSize BMKMapSizeWorld __attribute__((visibility("default")));
        [Field("BMKMapSizeWorld", "__Internal")]
        BMKMapSize BMKMapSizeWorld { get; }

        // extern const BMKMapRect BMKMapRectWorld __attribute__((visibility("default")));
        [Field("BMKMapRectWorld", "__Internal")]
        BMKMapRect BMKMapRectWorld { get; }

        // extern const BMKMapRect BMKMapRectNull __attribute__((visibility("default")));
        [Field("BMKMapRectNull", "__Internal")]
        BMKMapRect BMKMapRectNull { get; }
    }*/

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

    // @interface BMKIndoorPlanNode : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKIndoorPlanNode
    {
        // @property (retain, nonatomic) NSString * floor;
        [Export("floor", ArgumentSemantic.Retain)]
        string Floor { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }
    }

    // @interface BMKAddressComponent : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKAddressComponent
    {
        // @property (nonatomic, strong) NSString * streetNumber;
        [Export("streetNumber", ArgumentSemantic.Strong)]
        string StreetNumber { get; set; }

        // @property (nonatomic, strong) NSString * streetName;
        [Export("streetName", ArgumentSemantic.Strong)]
        string StreetName { get; set; }

        // @property (nonatomic, strong) NSString * district;
        [Export("district", ArgumentSemantic.Strong)]
        string District { get; set; }

        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic, strong) NSString * province;
        [Export("province", ArgumentSemantic.Strong)]
        string Province { get; set; }

        // @property (nonatomic, strong) NSString * country;
        [Export("country", ArgumentSemantic.Strong)]
        string Country { get; set; }

        // @property (nonatomic, strong) NSString * countryCode;
        [Export("countryCode", ArgumentSemantic.Strong)]
        string CountryCode { get; set; }

        // @property (nonatomic, strong) NSString * adCode;
        [Export("adCode", ArgumentSemantic.Strong)]
        string AdCode { get; set; }
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

