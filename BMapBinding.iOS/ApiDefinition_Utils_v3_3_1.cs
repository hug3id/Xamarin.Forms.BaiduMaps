using System;

using Foundation;
using ObjCRuntime;
using CoreLocation;

namespace BMapBinding
{
    // @interface BMKNaviPara : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKNaviPara
    {
        // @property (nonatomic, strong) BMKPlanNode * startPoint;
        [Export("startPoint", ArgumentSemantic.Strong)]
        BMKPlanNode StartPoint { get; set; }

        // @property (nonatomic, strong) BMKPlanNode * endPoint;
        [Export("endPoint", ArgumentSemantic.Strong)]
        BMKPlanNode EndPoint { get; set; }

        // @property (assign, nonatomic) BMK_NAVI_TYPE naviType __attribute__((deprecated("自2.8.0开始废弃")));
        //[Export("naviType", ArgumentSemantic.Assign)]
        //BMK_NAVI_TYPE NaviType { get; set; }

        // @property (nonatomic, strong) NSString * appScheme;
        [Export("appScheme", ArgumentSemantic.Strong)]
        string AppScheme { get; set; }

        // @property (nonatomic, strong) NSString * appName;
        [Export("appName", ArgumentSemantic.Strong)]
        string AppName { get; set; }

        // @property (assign, nonatomic) BOOL isSupportWeb;
        [Export("isSupportWeb")]
        bool IsSupportWeb { get; set; }
    }

    // @interface BMKNavigation : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKNavigation
    {
        // +(BMKErrorCode)openBaiduMapNavigation:(BMKNaviPara *)para;
        [Static]
        [Export("openBaiduMapNavigation:")]
        BMKErrorCode OpenBaiduMapNavigation(BMKNaviPara para);

        // +(id)openBaiduMapWalkNavigation:(BMKNaviPara *)para;
        [Static]
        [Export("openBaiduMapWalkNavigation:")]
        BMKErrorCode OpenBaiduMapWalkNavigation(BMKNaviPara para);

        // +(BMKErrorCode)openBaiduMapRideNavigation:(BMKNaviPara *)para;
        [Static]
        [Export("openBaiduMapRideNavigation:")]
        BMKErrorCode OpenBaiduMapRideNavigation(BMKNaviPara para);

        // +(BMKOpenErrorCode)openBaiduMapwalkARNavigation:(BMKNaviPara*)para;
        [Static]
        [Export("openBaiduMapwalkARNavigation:")]
        BMKErrorCode OpenBaiduMapWalkARNavigation(BMKNaviPara para);
    }

    // @interface BMKOpenOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKOpenOption
    {
        // @property (nonatomic, strong) NSString * appScheme;
        [Export("appScheme", ArgumentSemantic.Strong)]
        string AppScheme { get; set; }

        // @property (assign, nonatomic) BOOL isSupportWeb;
        [Export("isSupportWeb")]
        bool IsSupportWeb { get; set; }
    }

    // @interface BMKOpenPoiDetailOption : BMKOpenOption
    [BaseType(typeof(BMKOpenOption))]
    interface BMKOpenPoiDetailOption
    {
        // @property (nonatomic, strong) NSString * poiUid;
        [Export("poiUid", ArgumentSemantic.Strong)]
        string PoiUid { get; set; }
    }

    // @interface BMKOpenPoiNearbyOption : BMKOpenOption
    [BaseType(typeof(BMKOpenOption))]
    interface BMKOpenPoiNearbyOption
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D location;
        [Export("location", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Location { get; set; }

        // @property (assign, nonatomic) NSUInteger radius;
        [Export("radius")]
        nuint Radius { get; set; }

        // @property (nonatomic, strong) NSString * keyword;
        [Export("keyword", ArgumentSemantic.Strong)]
        string Keyword { get; set; }
    }

    // @interface BMKOpenPoi : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKOpenPoi
    {
        // +(id)openBaiduMapPoiDetailPage:(BMKOpenPoiDetailOption *)option;
        [Static]
        [Export("openBaiduMapPoiDetailPage:")]
        NSObject OpenBaiduMapPoiDetailPage(BMKOpenPoiDetailOption option);

        // +(id)openBaiduMapPoiNearbySearch:(BMKOpenPoiNearbyOption *)option;
        [Static]
        [Export("openBaiduMapPoiNearbySearch:")]
        NSObject OpenBaiduMapPoiNearbySearch(BMKOpenPoiNearbyOption option);
    }

    // @interface BMKOpenRouteOption : BMKOpenOption
    [BaseType(typeof(BMKOpenOption))]
    interface BMKOpenRouteOption
    {
        // @property (nonatomic, strong) BMKPlanNode * startPoint;
        [Export("startPoint", ArgumentSemantic.Strong)]
        BMKPlanNode StartPoint { get; set; }

        // @property (nonatomic, strong) BMKPlanNode * endPoint;
        [Export("endPoint", ArgumentSemantic.Strong)]
        BMKPlanNode EndPoint { get; set; }
    }

    // @interface BMKOpenWalkingRouteOption : BMKOpenRouteOption
    [BaseType(typeof(BMKOpenRouteOption))]
    interface BMKOpenWalkingRouteOption
    {
    }

    // @interface BMKOpenDrivingRouteOption : BMKOpenRouteOption
    [BaseType(typeof(BMKOpenRouteOption))]
    interface BMKOpenDrivingRouteOption
    {
    }

    // @interface BMKOpenTransitRouteOption : BMKOpenRouteOption
    [BaseType(typeof(BMKOpenRouteOption))]
    interface BMKOpenTransitRouteOption
    {
        // @property (assign, nonatomic) BMKOpenTransitPolicy openTransitPolicy;
        [Export("openTransitPolicy", ArgumentSemantic.Assign)]
        BMKOpenTransitPolicy OpenTransitPolicy { get; set; }
    }

    // @interface BMKOpenRoute : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKOpenRoute
    {
        // +(id)openBaiduMapWalkingRoute:(BMKOpenWalkingRouteOption *)option;
        [Static]
        [Export("openBaiduMapWalkingRoute:")]
        NSObject OpenBaiduMapWalkingRoute(BMKOpenWalkingRouteOption option);

        // +(id)openBaiduMapTransitRoute:(BMKOpenTransitRouteOption *)option;
        [Static]
        [Export("openBaiduMapTransitRoute:")]
        NSObject OpenBaiduMapTransitRoute(BMKOpenTransitRouteOption option);

        // +(id)openBaiduMapDrivingRoute:(BMKOpenDrivingRouteOption *)option;
        [Static]
        [Export("openBaiduMapDrivingRoute:")]
        NSObject OpenBaiduMapDrivingRoute(BMKOpenDrivingRouteOption option);
    }

    // @interface BMKFavPoiInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKFavPoiInfo
    {
        // @property (nonatomic, strong) NSString * favId;
        [Export("favId", ArgumentSemantic.Strong)]
        string FavId { get; set; }

        // @property (nonatomic, strong) NSString * poiName;
        [Export("poiName", ArgumentSemantic.Strong)]
        string PoiName { get; set; }

        // @property (nonatomic, strong) NSString * poiUid;
        [Export("poiUid", ArgumentSemantic.Strong)]
        string PoiUid { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) NSString * cityName;
        [Export("cityName", ArgumentSemantic.Strong)]
        string CityName { get; set; }

        // @property (assign, nonatomic) NSUInteger timeStamp;
        [Export("timeStamp")]
        nuint TimeStamp { get; set; }
    }

    // @interface BMKFavPoiManager : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKFavPoiManager
    {
        // -(NSInteger)addFavPoi:(BMKFavPoiInfo *)favPoiInfo;
        [Export("addFavPoi:")]
        nint AddFavPoi(BMKFavPoiInfo favPoiInfo);

        // -(BMKFavPoiInfo *)getFavPoi:(NSString *)favId;
        [Export("getFavPoi:")]
        BMKFavPoiInfo GetFavPoi(string favId);

        // -(NSArray *)getAllFavPois;
        [Export("getAllFavPois")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] AllFavPois { get; }

        // -(BOOL)updateFavPoi:(NSString *)favId favPoiInfo:(BMKFavPoiInfo *)favPoiInfo;
        [Export("updateFavPoi:favPoiInfo:")]
        bool UpdateFavPoi(string favId, BMKFavPoiInfo favPoiInfo);

        // -(BOOL)deleteFavPoi:(NSString *)favId;
        [Export("deleteFavPoi:")]
        bool DeleteFavPoi(string favId);

        // -(BOOL)clearAllFavPois;
        [Export("clearAllFavPois")]
        bool ClearAllFavPois();
    }

    // @interface BMKOpenPanoramaOption : BMKOpenOption
    [BaseType(typeof(BMKOpenOption))]
    interface BMKOpenPanoramaOption
    {
        // @property (nonatomic, strong) NSString * poiUid;
        [Export("poiUid", ArgumentSemantic.Strong)]
        string PoiUid { get; set; }
    }

    // @interface BMKOpenPanorama : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKOpenPanorama
    {
        [Wrap("WeakDelegate")]
        BMKOpenPanoramaDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKOpenPanoramaDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)openBaiduMapPanorama:(BMKOpenPanoramaOption *)option;
        [Export("openBaiduMapPanorama:")]
        void OpenBaiduMapPanorama(BMKOpenPanoramaOption option);
    }

    // @protocol BMKOpenPanoramaDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKOpenPanoramaDelegate
    {
        // @required -(void)onGetOpenPanoramaStatus:(id)ecode;
        [Abstract]
        [Export("onGetOpenPanoramaStatus:")]
        void OnGetOpenPanoramaStatus(NSObject ecode);
    }
}
