using System;

using Foundation;
using ObjCRuntime;
using CoreLocation;

namespace BMapBinding
{
    // @interface BMKRadarUploadInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRadarUploadInfo
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }

        // @property (nonatomic, strong) NSString * extInfo;
        [Export("extInfo", ArgumentSemantic.Strong)]
        string ExtInfo { get; set; }
    }

    // @interface BMKDateRange : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKDateRange
    {
        // @property (nonatomic, strong) NSDate * startDate;
        [Export("startDate", ArgumentSemantic.Strong)]
        NSDate StartDate { get; set; }

        // @property (nonatomic, strong) NSDate * endDate;
        [Export("endDate", ArgumentSemantic.Strong)]
        NSDate EndDate { get; set; }
    }

    // @interface BMKRadarNearbySearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRadarNearbySearchOption
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D centerPt;
        [Export("centerPt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D CenterPt { get; set; }

        // @property (assign, nonatomic) NSUInteger radius;
        [Export("radius")]
        nuint Radius { get; set; }

        // @property (assign, nonatomic) NSInteger pageIndex;
        [Export("pageIndex")]
        nint PageIndex { get; set; }

        // @property (assign, nonatomic) NSInteger pageCapacity;
        [Export("pageCapacity")]
        nint PageCapacity { get; set; }

        // @property (assign, nonatomic) BMKRadarSortType sortType;
        [Export("sortType", ArgumentSemantic.Assign)]
        BMKRadarSortType SortType { get; set; }

        // @property (nonatomic, strong) BMKDateRange * dateRange;
        [Export("dateRange", ArgumentSemantic.Strong)]
        BMKDateRange DateRange { get; set; }
    }

    // @interface BMKRadarNearbyInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRadarNearbyInfo
    {
        // @property (nonatomic, strong) NSString * userId;
        [Export("userId", ArgumentSemantic.Strong)]
        string UserId { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }

        // @property (assign, nonatomic) NSUInteger distance;
        [Export("distance")]
        nuint Distance { get; set; }

        // @property (nonatomic, strong) NSString * extInfo;
        [Export("extInfo", ArgumentSemantic.Strong)]
        string ExtInfo { get; set; }

        // @property (nonatomic, strong) NSString * mobileType;
        [Export("mobileType", ArgumentSemantic.Strong)]
        string MobileType { get; set; }

        // @property (nonatomic, strong) NSString * osType;
        [Export("osType", ArgumentSemantic.Strong)]
        string OsType { get; set; }

        // @property (assign, nonatomic) NSTimeInterval timeStamp;
        [Export("timeStamp")]
        double TimeStamp { get; set; }
    }

    // @interface BMKRadarNearbyResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRadarNearbyResult
    {
        // @property (assign, nonatomic) NSInteger totalNum;
        [Export("totalNum")]
        nint TotalNum { get; set; }

        // @property (assign, nonatomic) NSInteger pageNum;
        [Export("pageNum")]
        nint PageNum { get; set; }

        // @property (assign, nonatomic) NSInteger currNum;
        [Export("currNum")]
        nint CurrNum { get; set; }

        // @property (assign, nonatomic) NSInteger pageIndex;
        [Export("pageIndex")]
        nint PageIndex { get; set; }

        // @property (nonatomic, strong) NSArray * infoList;
        [Export("infoList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKRadarNearbyInfo[] InfoList { get; set; }
    }

    // @protocol BMKRadarManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKRadarManagerDelegate
    {
        // @optional -(BMKRadarUploadInfo *)getRadarAutoUploadInfo;
        [Export("getRadarAutoUploadInfo")]
        //[Verify(MethodToProperty)]
        BMKRadarUploadInfo RadarAutoUploadInfo { get; }

        // @optional -(void)onGetRadarUploadResult:(BMKRadarErrorCode)error;
        [Export("onGetRadarUploadResult:")]
        void OnGetRadarUploadResult(BMKRadarErrorCode error);

        // @optional -(void)onGetRadarClearMyInfoResult:(BMKRadarErrorCode)error;
        [Export("onGetRadarClearMyInfoResult:")]
        void OnGetRadarClearMyInfoResult(BMKRadarErrorCode error);

        // @optional -(void)onGetRadarNearbySearchResult:(BMKRadarNearbyResult *)result error:(BMKRadarErrorCode)error;
        [Export("onGetRadarNearbySearchResult:error:")]
        void OnGetRadarNearbySearchResult(BMKRadarNearbyResult result, BMKRadarErrorCode error);
    }

    // @interface BMKRadarManager : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRadarManager
    {
        // @property (nonatomic, strong) NSString * userId;
        [Export("userId", ArgumentSemantic.Strong)]
        string UserId { get; set; }

        // +(BMKRadarManager *)getRadarManagerInstance;
        [Static]
        [Export("getRadarManagerInstance")]
        //[Verify(MethodToProperty)]
        BMKRadarManager Instance { get; }

        // +(void)releaseRadarManagerInstance;
        [Static]
        [Export("releaseRadarManagerInstance")]
        void ReleaseInstance();

        // -(void)addRadarManagerDelegate:(id<BMKRadarManagerDelegate>)delegate;
        [Export("addRadarManagerDelegate:")]
        void AddDelegate(BMKRadarManagerDelegate @delegate);

        // -(void)removeRadarManagerDelegate:(id<BMKRadarManagerDelegate>)delegate;
        [Export("removeRadarManagerDelegate:")]
        void RemoveDelegate(BMKRadarManagerDelegate @delegate);

        // -(void)startAutoUpload:(NSTimeInterval)interval;
        [Export("startAutoUpload:")]
        void StartAutoUpload(double interval);

        // -(void)stopAutoUpload;
        [Export("stopAutoUpload")]
        void StopAutoUpload();

        // -(BOOL)uploadInfoRequest:(BMKRadarUploadInfo *)info;
        [Export("uploadInfoRequest:")]
        bool UploadInfoRequest(BMKRadarUploadInfo info);

        // -(BOOL)clearMyInfoRequest;
        [Export("clearMyInfoRequest")]
        //[Verify(MethodToProperty)]
        bool ClearMyInfoRequest();

        // -(BOOL)getRadarNearbySearchRequest:(BMKRadarNearbySearchOption *)option;
        [Export("getRadarNearbySearchRequest:")]
        bool GetRadarNearbySearchRequest(BMKRadarNearbySearchOption option);
    }

}
