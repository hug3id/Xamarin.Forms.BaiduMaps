using System;

using Foundation;
using ObjCRuntime;
using CoreLocation;

namespace BMapBinding
{
    // @interface BMKCityListInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKCityListInfo
    {
        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic) int num;
        [Export("num")]
        int Num { get; set; }
    }

    // @interface BMKPoiInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiInfo
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic, strong) NSString * phone;
        [Export("phone", ArgumentSemantic.Strong)]
        string Phone { get; set; }

        // @property (nonatomic, strong) NSString * postcode;
        [Export("postcode", ArgumentSemantic.Strong)]
        string Postcode { get; set; }

        // @property (nonatomic) int epoitype;
        [Export("epoitype")]
        int Epoitype { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }

        // @property (assign, nonatomic) BOOL panoFlag;
        [Export("panoFlag")]
        bool PanoFlag { get; set; }
    }

    // @interface BMKPoiAddressInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiAddressInfo
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }
    }

    // @interface BMKPoiResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiResult
    {
        // @property (nonatomic) int totalPoiNum;
        [Export("totalPoiNum")]
        int TotalPoiNum { get; set; }

        // @property (nonatomic) int currPoiNum;
        [Export("currPoiNum")]
        int CurrPoiNum { get; set; }

        // @property (nonatomic) int pageNum;
        [Export("pageNum")]
        int PageNum { get; set; }

        // @property (nonatomic) int pageIndex;
        [Export("pageIndex")]
        int PageIndex { get; set; }

        // @property (nonatomic, strong) NSArray * poiInfoList;
        [Export("poiInfoList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKPoiInfo[] PoiInfoList { get; set; }

        // @property (nonatomic, strong) NSArray * cityList;
        [Export("cityList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKCityListInfo[] CityList { get; set; }

        // @property (assign, nonatomic) BOOL isHavePoiAddressInfoList;
        [Export("isHavePoiAddressInfoList")]
        bool IsHavePoiAddressInfoList { get; set; }

        // @property (nonatomic, strong) NSArray * poiAddressInfoList;
        [Export("poiAddressInfoList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] PoiAddressInfoList { get; set; }
    }

    // @interface BMKPoiDetailResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiDetailResult
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) NSString * phone;
        [Export("phone", ArgumentSemantic.Strong)]
        string Phone { get; set; }

        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }

        // @property (nonatomic, strong) NSString * tag;
        [Export("tag", ArgumentSemantic.Strong)]
        string Tag { get; set; }

        // @property (nonatomic, strong) NSString * detailUrl;
        [Export("detailUrl", ArgumentSemantic.Strong)]
        string DetailUrl { get; set; }

        // @property (nonatomic, strong) NSString * type;
        [Export("type", ArgumentSemantic.Strong)]
        string Type { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }

        // @property (nonatomic) double price;
        [Export("price")]
        double Price { get; set; }

        // @property (nonatomic) double overallRating;
        [Export("overallRating")]
        double OverallRating { get; set; }

        // @property (nonatomic) double tasteRating;
        [Export("tasteRating")]
        double TasteRating { get; set; }

        // @property (nonatomic) double serviceRating;
        [Export("serviceRating")]
        double ServiceRating { get; set; }

        // @property (nonatomic) double environmentRating;
        [Export("environmentRating")]
        double EnvironmentRating { get; set; }

        // @property (nonatomic) double facilityRating;
        [Export("facilityRating")]
        double FacilityRating { get; set; }

        // @property (nonatomic) double hygieneRating;
        [Export("hygieneRating")]
        double HygieneRating { get; set; }

        // @property (nonatomic) double technologyRating;
        [Export("technologyRating")]
        double TechnologyRating { get; set; }

        // @property (nonatomic) int imageNum;
        [Export("imageNum")]
        int ImageNum { get; set; }

        // @property (nonatomic) int grouponNum;
        [Export("grouponNum")]
        int GrouponNum { get; set; }

        // @property (nonatomic) int commentNum;
        [Export("commentNum")]
        int CommentNum { get; set; }

        // @property (nonatomic) int favoriteNum;
        [Export("favoriteNum")]
        int FavoriteNum { get; set; }

        // @property (nonatomic) int checkInNum;
        [Export("checkInNum")]
        int CheckInNum { get; set; }

        // @property (nonatomic, strong) NSString * shopHours;
        [Export("shopHours", ArgumentSemantic.Strong)]
        string ShopHours { get; set; }
    }

    // @interface BMKPoiIndoorInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiIndoorInfo
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }

        // @property (nonatomic, strong) NSString * indoorId;
        [Export("indoorId", ArgumentSemantic.Strong)]
        string IndoorId { get; set; }

        // @property (nonatomic, strong) NSString * floor;
        [Export("floor", ArgumentSemantic.Strong)]
        string Floor { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic, strong) NSString * phone;
        [Export("phone", ArgumentSemantic.Strong)]
        string Phone { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D pt;
        [Export("pt", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Pt { get; set; }

        // @property (nonatomic, strong) NSString * tag;
        [Export("tag", ArgumentSemantic.Strong)]
        string Tag { get; set; }

        // @property (assign, nonatomic) double price;
        [Export("price")]
        double Price { get; set; }

        // @property (assign, nonatomic) NSInteger starLevel;
        [Export("starLevel")]
        nint StarLevel { get; set; }

        // @property (assign, nonatomic) BOOL grouponFlag;
        [Export("grouponFlag")]
        bool GrouponFlag { get; set; }

        // @property (assign, nonatomic) BOOL takeoutFlag;
        [Export("takeoutFlag")]
        bool TakeoutFlag { get; set; }

        // @property (assign, nonatomic) BOOL waitedFlag;
        [Export("waitedFlag")]
        bool WaitedFlag { get; set; }

        // @property (assign, nonatomic) NSInteger grouponNum;
        [Export("grouponNum")]
        nint GrouponNum { get; set; }
    }

    // @interface BMKPoiIndoorResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiIndoorResult
    {
        // @property (assign, nonatomic) NSInteger totalPoiNum;
        [Export("totalPoiNum")]
        nint TotalPoiNum { get; set; }

        // @property (assign, nonatomic) NSInteger currPoiNum;
        [Export("currPoiNum")]
        nint CurrPoiNum { get; set; }

        // @property (assign, nonatomic) NSInteger pageNum;
        [Export("pageNum")]
        nint PageNum { get; set; }

        // @property (nonatomic) int pageIndex;
        [Export("pageIndex")]
        int PageIndex { get; set; }

        // @property (nonatomic, strong) NSArray * poiIndoorInfoList;
        [Export("poiIndoorInfoList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKPoiIndoorInfo[] PoiIndoorInfoList { get; set; }
    }

    // @interface BMKReverseGeoCodeResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKReverseGeoCodeResult
    {
        // @property (nonatomic, strong) BMKAddressComponent * addressDetail;
        [Export("addressDetail", ArgumentSemantic.Strong)]
        BMKAddressComponent AddressDetail { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) NSString * businessCircle;
        [Export("businessCircle", ArgumentSemantic.Strong)]
        string BusinessCircle { get; set; }

        // @property (nonatomic, strong) NSString * sematicDescription;
        [Export("sematicDescription", ArgumentSemantic.Strong)]
        string SematicDescription { get; set; }

        // @property (nonatomic, strong) NSString * cityCode;
        [Export("cityCode", ArgumentSemantic.Strong)]
        string CityCode { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D location;
        [Export("location", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Location { get; set; }

        // @property (nonatomic, strong) NSArray * poiList;
        [Export("poiList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKPoiInfo[] PoiList { get; set; }
    }

    // @interface BMKGeoCodeResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKGeoCodeResult
    {
        // @property (nonatomic) CLLocationCoordinate2D location;
        [Export("location", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Location { get; set; }

        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }
    }

    // @interface BMKTaxiInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKTaxiInfo
    {
        // @property (nonatomic, strong) NSString * desc;
        [Export("desc", ArgumentSemantic.Strong)]
        string Desc { get; set; }

        // @property (nonatomic) int distance;
        [Export("distance")]
        int Distance { get; set; }

        // @property (nonatomic) int duration;
        [Export("duration")]
        int Duration { get; set; }

        // @property (nonatomic) CGFloat perKMPrice;
        [Export("perKMPrice")]
        nfloat PerKMPrice { get; set; }

        // @property (nonatomic) CGFloat startPrice;
        [Export("startPrice")]
        nfloat StartPrice { get; set; }

        // @property (nonatomic) int totalPrice;
        [Export("totalPrice")]
        int TotalPrice { get; set; }
    }

    // @interface BMKVehicleInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKVehicleInfo
    {
        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }

        // @property (nonatomic, strong) NSString * title;
        [Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (nonatomic) int passStationNum;
        [Export("passStationNum")]
        int PassStationNum { get; set; }

        // @property (nonatomic) int totalPrice;
        [Export("totalPrice")]
        int TotalPrice { get; set; }

        // @property (nonatomic) int zonePrice;
        [Export("zonePrice")]
        int ZonePrice { get; set; }
    }

    // @interface BMKTime : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKTime
    {
        // @property (nonatomic) int dates;
        [Export("dates")]
        int Dates { get; set; }

        // @property (nonatomic) int hours;
        [Export("hours")]
        int Hours { get; set; }

        // @property (nonatomic) int minutes;
        [Export("minutes")]
        int Minutes { get; set; }

        // @property (nonatomic) int seconds;
        [Export("seconds")]
        int Seconds { get; set; }
    }

    // @interface BMKRouteNode : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRouteNode
    {
        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }

        // @property (nonatomic, strong) NSString * title;
        [Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (nonatomic) CLLocationCoordinate2D location;
        [Export("location", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Location { get; set; }
    }

    // @interface BMKBusStation : BMKRouteNode
    [BaseType(typeof(BMKRouteNode))]
    interface BMKBusStation
    {
    }

    // @interface BMKRouteStep : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRouteStep
    {
        // @property (nonatomic) int distance;
        [Export("distance")]
        int Distance { get; set; }

        // @property (nonatomic) int duration;
        [Export("duration")]
        int Duration { get; set; }

        // @property (nonatomic) BMKMapPoint * points;
        [Export("points", ArgumentSemantic.Assign)]
        unsafe NSObject[] Points { get; set; }

        // @property (nonatomic) int pointsCount;
        [Export("pointsCount")]
        int PointsCount { get; set; }
    }

    // @interface BMKBusStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKBusStep
    {
    }

    // @interface BMKTransitStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKTransitStep
    {
        // @property (nonatomic, strong) BMKRouteNode * entrace;
        [Export("entrace", ArgumentSemantic.Strong)]
        BMKRouteNode Entrace { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * exit;
        [Export("exit", ArgumentSemantic.Strong)]
        BMKRouteNode Exit { get; set; }

        // @property (nonatomic, strong) NSString * instruction;
        [Export("instruction", ArgumentSemantic.Strong)]
        string Instruction { get; set; }

        // @property (nonatomic) BMKTransitStepType stepType;
        [Export("stepType", ArgumentSemantic.Assign)]
        BMKTransitStepType StepType { get; set; }

        // @property (nonatomic, strong) BMKVehicleInfo * vehicleInfo;
        [Export("vehicleInfo", ArgumentSemantic.Strong)]
        BMKVehicleInfo VehicleInfo { get; set; }
    }

    // @interface BMKBaseVehicleInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKBaseVehicleInfo
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * departureStation;
        [Export("departureStation", ArgumentSemantic.Strong)]
        string DepartureStation { get; set; }

        // @property (nonatomic, strong) NSString * arriveStation;
        [Export("arriveStation", ArgumentSemantic.Strong)]
        string ArriveStation { get; set; }

        // @property (nonatomic, strong) NSString * departureTime;
        [Export("departureTime", ArgumentSemantic.Strong)]
        string DepartureTime { get; set; }

        // @property (nonatomic, strong) NSString * arriveTime;
        [Export("arriveTime", ArgumentSemantic.Strong)]
        string ArriveTime { get; set; }
    }

    // @interface BMKBusVehicleInfo : BMKBaseVehicleInfo
    [BaseType(typeof(BMKBaseVehicleInfo))]
    interface BMKBusVehicleInfo
    {
        // @property (assign, nonatomic) NSInteger passStationNum;
        [Export("passStationNum")]
        nint PassStationNum { get; set; }

        // @property (nonatomic, strong) NSString * firstTime;
        [Export("firstTime", ArgumentSemantic.Strong)]
        string FirstTime { get; set; }

        // @property (nonatomic, strong) NSString * lastTime;
        [Export("lastTime", ArgumentSemantic.Strong)]
        string LastTime { get; set; }
    }

    // @interface BMKPlaneVehicleInfo : BMKBaseVehicleInfo
    [BaseType(typeof(BMKBaseVehicleInfo))]
    interface BMKPlaneVehicleInfo
    {
        // @property (assign, nonatomic) CGFloat price;
        [Export("price")]
        nfloat Price { get; set; }

        // @property (assign, nonatomic) CGFloat discount;
        [Export("discount")]
        nfloat Discount { get; set; }

        // @property (nonatomic, strong) NSString * airlines;
        [Export("airlines", ArgumentSemantic.Strong)]
        string Airlines { get; set; }

        // @property (nonatomic, strong) NSString * bookingUrl;
        [Export("bookingUrl", ArgumentSemantic.Strong)]
        string BookingUrl { get; set; }
    }

    // @interface BMKTrainVehicleInfo : BMKBaseVehicleInfo
    [BaseType(typeof(BMKBaseVehicleInfo))]
    interface BMKTrainVehicleInfo
    {
        // @property (assign, nonatomic) CGFloat price;
        [Export("price")]
        nfloat Price { get; set; }

        // @property (nonatomic, strong) NSString * booking;
        [Export("booking", ArgumentSemantic.Strong)]
        string Booking { get; set; }
    }

    // @interface BMKCoachVehicleInfo : BMKBaseVehicleInfo
    [BaseType(typeof(BMKBaseVehicleInfo))]
    interface BMKCoachVehicleInfo
    {
        // @property (assign, nonatomic) CGFloat price;
        [Export("price")]
        nfloat Price { get; set; }

        // @property (nonatomic, strong) NSString * bookingUrl;
        [Export("bookingUrl", ArgumentSemantic.Strong)]
        string BookingUrl { get; set; }

        // @property (nonatomic, strong) NSString * providerName;
        [Export("providerName", ArgumentSemantic.Strong)]
        string ProviderName { get; set; }

        // @property (nonatomic, strong) NSString * providerUrl;
        [Export("providerUrl", ArgumentSemantic.Strong)]
        string ProviderUrl { get; set; }
    }

    // @interface BMKMassTransitStep : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKMassTransitStep
    {
        // @property (assign, nonatomic) BOOL isSubStep;
        [Export("isSubStep")]
        bool IsSubStep { get; set; }

        // @property (nonatomic, strong) NSArray * steps;
        [Export("steps", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKMassTransitSubStep[] Steps { get; set; }
    }

    // @interface BMKMassTransitSubStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKMassTransitSubStep
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D entraceCoor;
        [Export("entraceCoor", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D EntraceCoor { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D exitCoor;
        [Export("exitCoor", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D ExitCoor { get; set; }

        // @property (nonatomic, strong) NSString * instructions;
        [Export("instructions", ArgumentSemantic.Strong)]
        string Instructions { get; set; }

        // @property (nonatomic) BMKMassTransitType stepType;
        [Export("stepType", ArgumentSemantic.Assign)]
        BMKMassTransitType StepType { get; set; }

        // @property (nonatomic, strong) BMKBaseVehicleInfo * vehicleInfo;
        [Export("vehicleInfo", ArgumentSemantic.Strong)]
        BMKBaseVehicleInfo VehicleInfo { get; set; }
    }

    // @interface BMKDrivingStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKDrivingStep
    {
        // @property (nonatomic) int direction;
        [Export("direction")]
        int Direction { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * entrace;
        [Export("entrace", ArgumentSemantic.Strong)]
        BMKRouteNode Entrace { get; set; }

        // @property (nonatomic, strong) NSString * entraceInstruction;
        [Export("entraceInstruction", ArgumentSemantic.Strong)]
        string EntraceInstruction { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * exit;
        [Export("exit", ArgumentSemantic.Strong)]
        BMKRouteNode Exit { get; set; }

        // @property (nonatomic, strong) NSString * exitInstruction;
        [Export("exitInstruction", ArgumentSemantic.Strong)]
        string ExitInstruction { get; set; }

        // @property (nonatomic, strong) NSString * instruction;
        [Export("instruction", ArgumentSemantic.Strong)]
        string Instruction { get; set; }

        // @property (nonatomic) int numTurns;
        [Export("numTurns")]
        int NumTurns { get; set; }

        // @property (nonatomic) BOOL hasTrafficsInfo;
        [Export("hasTrafficsInfo")]
        bool HasTrafficsInfo { get; set; }

        // @property (nonatomic, strong) NSArray * traffics;
        [Export("traffics", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Traffics { get; set; }
    }

    // @interface BMKIndoorStepNode : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKIndoorStepNode
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D coordinate;
        [Export("coordinate", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Coordinate { get; set; }

        // @property (assign, nonatomic) BMKIndoorStepNodeType type;
        [Export("type", ArgumentSemantic.Assign)]
        BMKIndoorStepNodeType Type { get; set; }

        // @property (nonatomic, strong) NSString * desc;
        [Export("desc", ArgumentSemantic.Strong)]
        string Desc { get; set; }
    }

    // @interface BMKIndoorRouteStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKIndoorRouteStep
    {
        // @property (nonatomic, strong) BMKRouteNode * entrace;
        [Export("entrace", ArgumentSemantic.Strong)]
        BMKRouteNode Entrace { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * exit;
        [Export("exit", ArgumentSemantic.Strong)]
        BMKRouteNode Exit { get; set; }

        // @property (nonatomic, strong) NSString * instructions;
        [Export("instructions", ArgumentSemantic.Strong)]
        string Instructions { get; set; }

        // @property (nonatomic, strong) NSString * buildingid;
        [Export("buildingid", ArgumentSemantic.Strong)]
        string Buildingid { get; set; }

        // @property (nonatomic, strong) NSString * floorid;
        [Export("floorid", ArgumentSemantic.Strong)]
        string Floorid { get; set; }

        // @property (nonatomic, strong) NSArray * indoorStepNodes;
        [Export("indoorStepNodes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKIndoorStepNode[] IndoorStepNodes { get; set; }
    }

    // @interface BMKWalkingStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKWalkingStep
    {
        // @property (nonatomic) int direction;
        [Export("direction")]
        int Direction { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * entrace;
        [Export("entrace", ArgumentSemantic.Strong)]
        BMKRouteNode Entrace { get; set; }

        // @property (nonatomic, strong) NSString * entraceInstruction;
        [Export("entraceInstruction", ArgumentSemantic.Strong)]
        string EntraceInstruction { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * exit;
        [Export("exit", ArgumentSemantic.Strong)]
        BMKRouteNode Exit { get; set; }

        // @property (nonatomic, strong) NSString * exitInstruction;
        [Export("exitInstruction", ArgumentSemantic.Strong)]
        string ExitInstruction { get; set; }

        // @property (nonatomic, strong) NSString * instruction;
        [Export("instruction", ArgumentSemantic.Strong)]
        string Instruction { get; set; }
    }

    // @interface BMKRidingStep : BMKRouteStep
    [BaseType(typeof(BMKRouteStep))]
    interface BMKRidingStep
    {
        // @property (nonatomic) NSInteger direction;
        [Export("direction")]
        nint Direction { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * entrace;
        [Export("entrace", ArgumentSemantic.Strong)]
        BMKRouteNode Entrace { get; set; }

        // @property (nonatomic, strong) NSString * entraceInstruction;
        [Export("entraceInstruction", ArgumentSemantic.Strong)]
        string EntraceInstruction { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * exit;
        [Export("exit", ArgumentSemantic.Strong)]
        BMKRouteNode Exit { get; set; }

        // @property (nonatomic, strong) NSString * exitInstruction;
        [Export("exitInstruction", ArgumentSemantic.Strong)]
        string ExitInstruction { get; set; }

        // @property (nonatomic, strong) NSString * instruction;
        [Export("instruction", ArgumentSemantic.Strong)]
        string Instruction { get; set; }
    }

    // @interface BMKRouteLine : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRouteLine
    {
        // @property (nonatomic) int distance;
        [Export("distance")]
        int Distance { get; set; }

        // @property (nonatomic, strong) BMKTime * duration;
        [Export("duration", ArgumentSemantic.Strong)]
        BMKTime Duration { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * starting;
        [Export("starting", ArgumentSemantic.Strong)]
        BMKRouteNode Starting { get; set; }

        // @property (nonatomic, strong) BMKRouteNode * terminal;
        [Export("terminal", ArgumentSemantic.Strong)]
        BMKRouteNode Terminal { get; set; }

        // @property (nonatomic, strong) NSString * title;
        [Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (nonatomic, strong) NSArray * steps;
        [Export("steps", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] Steps { get; set; }
    }

    // @interface BMKTransitRouteLine : BMKRouteLine
    [BaseType(typeof(BMKRouteLine))]
    interface BMKTransitRouteLine
    {
    }

    // @interface BMKMassTransitRouteLine : BMKRouteLine
    [BaseType(typeof(BMKRouteLine))]
    interface BMKMassTransitRouteLine
    {
        // @property (assign, nonatomic) CGFloat price;
        [Export("price")]
        nfloat Price { get; set; }
    }

    // @interface BMKIndoorRouteLine : BMKRouteLine
    [BaseType(typeof(BMKRouteLine))]
    interface BMKIndoorRouteLine
    {
    }

    // @interface BMKDrivingRouteLine : BMKRouteLine
    [BaseType(typeof(BMKRouteLine))]
    interface BMKDrivingRouteLine
    {
        // @property (nonatomic) _Bool isSupportTraffic;
        [Export("isSupportTraffic")]
        bool IsSupportTraffic { get; set; }

        // @property (nonatomic, strong) NSArray * wayPoints;
        [Export("wayPoints", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKPlanNode[] WayPoints { get; set; }

        // @property (assign, nonatomic) NSInteger lightNum;
        [Export("lightNum")]
        nint LightNum { get; set; }

        // @property (assign, nonatomic) NSInteger congestionMetres;
        [Export("congestionMetres")]
        nint CongestionMetres { get; set; }

        // @property (assign, nonatomic) NSInteger taxiFares;
        [Export("taxiFares")]
        nint TaxiFares { get; set; }
    }

    // @interface BMKWalkingRouteLine : BMKRouteLine
    [BaseType(typeof(BMKRouteLine))]
    interface BMKWalkingRouteLine
    {
    }

    // @interface BMKRidingRouteLine : BMKRouteLine
    [BaseType(typeof(BMKRouteLine))]
    interface BMKRidingRouteLine
    {
    }

    // @interface BMKSuggestAddrInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKSuggestAddrInfo
    {
        // @property (nonatomic, strong) NSArray * startPoiList;
        [Export("startPoiList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKPoiInfo[] StartPoiList { get; set; }

        // @property (nonatomic, strong) NSArray * startCityList;
        [Export("startCityList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKCityListInfo[] StartCityList { get; set; }

        // @property (nonatomic, strong) NSArray * endPoiList;
        [Export("endPoiList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKPoiInfo[] EndPoiList { get; set; }

        // @property (nonatomic, strong) NSArray * endCityList;
        [Export("endCityList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKCityListInfo[] EndCityList { get; set; }

        // @property (nonatomic, strong) NSArray * wayPointPoiList;
        [Export("wayPointPoiList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] WayPointPoiList { get; set; }

        // @property (nonatomic, strong) NSArray * wayPointCityList;
        [Export("wayPointCityList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] WayPointCityList { get; set; }
    }

    // @interface BMKBusLineResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKBusLineResult
    {
        // @property (nonatomic, strong) NSString * busCompany;
        [Export("busCompany", ArgumentSemantic.Strong)]
        string BusCompany { get; set; }

        // @property (nonatomic, strong) NSString * busLineName;
        [Export("busLineName", ArgumentSemantic.Strong)]
        string BusLineName { get; set; }

        // @property (nonatomic, strong) NSString * busLineDirection;
        [Export("busLineDirection", ArgumentSemantic.Strong)]
        string BusLineDirection { get; set; }

        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }

        // @property (nonatomic, strong) NSString * startTime;
        [Export("startTime", ArgumentSemantic.Strong)]
        string StartTime { get; set; }

        // @property (nonatomic, strong) NSString * endTime;
        [Export("endTime", ArgumentSemantic.Strong)]
        string EndTime { get; set; }

        // @property (nonatomic) int isMonTicket;
        [Export("isMonTicket")]
        int IsMonTicket { get; set; }

        // @property (assign, nonatomic) CGFloat basicPrice;
        [Export("basicPrice")]
        nfloat BasicPrice { get; set; }

        // @property (assign, nonatomic) CGFloat totalPrice;
        [Export("totalPrice")]
        nfloat TotalPrice { get; set; }

        // @property (nonatomic, strong) NSArray * busStations;
        [Export("busStations", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKBusStation[] BusStations { get; set; }

        // @property (nonatomic, strong) NSArray * busSteps;
        [Export("busSteps", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKBusStep[] BusSteps { get; set; }
    }

    // @interface BMKWalkingRouteResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKWalkingRouteResult
    {
        // @property (nonatomic, strong) BMKTaxiInfo * taxiInfo;
        [Export("taxiInfo", ArgumentSemantic.Strong)]
        BMKTaxiInfo TaxiInfo { get; set; }

        // @property (nonatomic, strong) BMKSuggestAddrInfo * suggestAddrResult;
        [Export("suggestAddrResult", ArgumentSemantic.Strong)]
        BMKSuggestAddrInfo SuggestAddrResult { get; set; }

        // @property (nonatomic, strong) NSArray * routes;
        [Export("routes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKWalkingRouteLine[] Routes { get; set; }
    }

    // @interface BMKDrivingRouteResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKDrivingRouteResult
    {
        // @property (nonatomic, strong) BMKTaxiInfo * taxiInfo;
        [Export("taxiInfo", ArgumentSemantic.Strong)]
        BMKTaxiInfo TaxiInfo { get; set; }

        // @property (nonatomic, strong) BMKSuggestAddrInfo * suggestAddrResult;
        [Export("suggestAddrResult", ArgumentSemantic.Strong)]
        BMKSuggestAddrInfo SuggestAddrResult { get; set; }

        // @property (nonatomic, strong) NSArray * routes;
        [Export("routes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKDrivingRouteLine[] Routes { get; set; }
    }

    // @interface BMKTransitRouteResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKTransitRouteResult
    {
        // @property (nonatomic, strong) BMKTaxiInfo * taxiInfo;
        [Export("taxiInfo", ArgumentSemantic.Strong)]
        BMKTaxiInfo TaxiInfo { get; set; }

        // @property (nonatomic, strong) BMKSuggestAddrInfo * suggestAddrResult;
        [Export("suggestAddrResult", ArgumentSemantic.Strong)]
        BMKSuggestAddrInfo SuggestAddrResult { get; set; }

        // @property (nonatomic, strong) NSArray * routes;
        [Export("routes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKTransitRouteLine[] Routes { get; set; }
    }

    // @interface BMKMassTransitRouteResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKMassTransitRouteResult
    {
        // @property (nonatomic, strong) BMKSuggestAddrInfo * suggestAddrResult;
        [Export("suggestAddrResult", ArgumentSemantic.Strong)]
        BMKSuggestAddrInfo SuggestAddrResult { get; set; }

        // @property (nonatomic, strong) NSArray * routes;
        [Export("routes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKMassTransitRouteLine[] Routes { get; set; }

        // @property (assign, nonatomic) NSInteger totalRoutes;
        [Export("totalRoutes")]
        nint TotalRoutes { get; set; }

        // @property (nonatomic, strong) BMKTaxiInfo * taxiInfo;
        [Export("taxiInfo", ArgumentSemantic.Strong)]
        BMKTaxiInfo TaxiInfo { get; set; }
    }

    // @interface BMKRidingRouteResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRidingRouteResult
    {
        // @property (nonatomic, strong) BMKSuggestAddrInfo * suggestAddrResult;
        [Export("suggestAddrResult", ArgumentSemantic.Strong)]
        BMKSuggestAddrInfo SuggestAddrResult { get; set; }

        // @property (nonatomic, strong) NSArray * routes;
        [Export("routes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKRidingRouteLine[] Routes { get; set; }
    }

    // @interface BMKIndoorRouteResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKIndoorRouteResult
    {
        // @property (nonatomic, strong) NSArray * routes;
        [Export("routes", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        BMKIndoorRouteLine[] Routes { get; set; }
    }

    // @interface BMKBasePoiSearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKBasePoiSearchOption
    {
        // @property (nonatomic, strong) NSString * keyword;
        [Export("keyword", ArgumentSemantic.Strong)]
        string Keyword { get; set; }

        // @property (assign, nonatomic) int pageIndex;
        [Export("pageIndex")]
        int PageIndex { get; set; }

        // @property (assign, nonatomic) int pageCapacity;
        [Export("pageCapacity")]
        int PageCapacity { get; set; }
    }

    // @interface BMKCitySearchOption : BMKBasePoiSearchOption
    [BaseType(typeof(BMKBasePoiSearchOption))]
    interface BMKCitySearchOption
    {
        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (assign, nonatomic) BOOL requestPoiAddressInfoList;
        [Export("requestPoiAddressInfoList")]
        bool RequestPoiAddressInfoList { get; set; }
    }

    // @interface BMKNearbySearchOption : BMKBasePoiSearchOption
    [BaseType(typeof(BMKBasePoiSearchOption))]
    interface BMKNearbySearchOption
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D location;
        [Export("location", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Location { get; set; }

        // @property (assign, nonatomic) int radius;
        [Export("radius")]
        int Radius { get; set; }

        // @property (assign, nonatomic) BMKPoiSortType sortType;
        [Export("sortType", ArgumentSemantic.Assign)]
        BMKPoiSortType SortType { get; set; }
    }

    // @interface BMKBoundSearchOption : BMKBasePoiSearchOption
    [BaseType(typeof(BMKBasePoiSearchOption))]
    interface BMKBoundSearchOption
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D leftBottom;
        [Export("leftBottom", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D LeftBottom { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D rightTop;
        [Export("rightTop", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D RightTop { get; set; }
    }

    // @interface BMKPoiIndoorSearchOption : BMKBasePoiSearchOption
    [BaseType(typeof(BMKBasePoiSearchOption))]
    interface BMKPoiIndoorSearchOption
    {
        // @property (nonatomic, strong) NSString * indoorId;
        [Export("indoorId", ArgumentSemantic.Strong)]
        string IndoorId { get; set; }

        // @property (nonatomic, strong) NSString * floor;
        [Export("floor", ArgumentSemantic.Strong)]
        string Floor { get; set; }
    }

    // @interface BMKPoiDetailSearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiDetailSearchOption
    {
        // @property (nonatomic, strong) NSString * poiUid;
        [Export("poiUid", ArgumentSemantic.Strong)]
        string PoiUid { get; set; }
    }

    // @interface BMKSearchBase : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKSearchBase
    {
    }

    // @interface BMKPoiSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKPoiSearch
    {
        [Wrap("WeakDelegate")]
        BMKPoiSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKPoiSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)poiSearchInCity:(BMKCitySearchOption *)option;
        [Export("poiSearchInCity:")]
        bool PoiSearchInCity(BMKCitySearchOption option);

        // -(BOOL)poiSearchInbounds:(BMKBoundSearchOption *)option;
        [Export("poiSearchInbounds:")]
        bool PoiSearchInbounds(BMKBoundSearchOption option);

        // -(BOOL)poiSearchNearBy:(BMKNearbySearchOption *)option;
        [Export("poiSearchNearBy:")]
        bool PoiSearchNearBy(BMKNearbySearchOption option);

        // -(BOOL)poiDetailSearch:(BMKPoiDetailSearchOption *)option;
        [Export("poiDetailSearch:")]
        bool PoiDetailSearch(BMKPoiDetailSearchOption option);

        // -(BOOL)poiIndoorSearch:(BMKPoiIndoorSearchOption *)option;
        [Export("poiIndoorSearch:")]
        bool PoiIndoorSearch(BMKPoiIndoorSearchOption option);
    }

    // @protocol BMKPoiSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKPoiSearchDelegate
    {
        // @optional -(void)onGetPoiResult:(BMKPoiSearch *)searcher result:(BMKPoiResult *)poiResult errorCode:(BMKSearchErrorCode)errorCode;
        [Export("onGetPoiResult:result:errorCode:")]
        void OnGetPoiResult(BMKPoiSearch searcher, BMKPoiResult poiResult, BMKSearchErrorCode errorCode);

        // @optional -(void)onGetPoiDetailResult:(BMKPoiSearch *)searcher result:(BMKPoiDetailResult *)poiDetailResult errorCode:(BMKSearchErrorCode)errorCode;
        [Export("onGetPoiDetailResult:result:errorCode:")]
        void OnGetPoiDetailResult(BMKPoiSearch searcher, BMKPoiDetailResult poiDetailResult, BMKSearchErrorCode errorCode);

        // @optional -(void)onGetPoiIndoorResult:(BMKPoiSearch *)searcher result:(BMKPoiIndoorResult *)poiIndoorResult errorCode:(BMKSearchErrorCode)errorCode;
        [Export("onGetPoiIndoorResult:result:errorCode:")]
        void OnGetPoiIndoorResult(BMKPoiSearch searcher, BMKPoiIndoorResult poiIndoorResult, BMKSearchErrorCode errorCode);
    }

    // @interface BMKGeoCodeSearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKGeoCodeSearchOption
    {
        // @property (nonatomic, strong) NSString * address;
        [Export("address", ArgumentSemantic.Strong)]
        string Address { get; set; }

        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }
    }

    // @interface BMKReverseGeoCodeOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKReverseGeoCodeOption
    {
        // @property (assign, nonatomic) CLLocationCoordinate2D reverseGeoPoint;
        [Export("reverseGeoPoint", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D ReverseGeoPoint { get; set; }
    }

    // @interface BMKGeoCodeSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKGeoCodeSearch
    {
        [Wrap("WeakDelegate")]
        BMKGeoCodeSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKGeoCodeSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)geoCode:(BMKGeoCodeSearchOption *)geoCodeOption;
        [Export("geoCode:")]
        bool GeoCode(BMKGeoCodeSearchOption geoCodeOption);

        // -(BOOL)reverseGeoCode:(BMKReverseGeoCodeOption *)reverseGeoCodeOption;
        [Export("reverseGeoCode:")]
        bool ReverseGeoCode(BMKReverseGeoCodeOption reverseGeoCodeOption);
    }

    // @protocol BMKGeoCodeSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKGeoCodeSearchDelegate
    {
        // @optional -(void)onGetGeoCodeResult:(BMKGeoCodeSearch *)searcher result:(BMKGeoCodeResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetGeoCodeResult:result:errorCode:")]
        void OnGetGeoCodeResult(BMKGeoCodeSearch searcher, BMKGeoCodeResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetReverseGeoCodeResult:(BMKGeoCodeSearch *)searcher result:(BMKReverseGeoCodeResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetReverseGeoCodeResult:result:errorCode:")]
        void OnGetReverseGeoCodeResult(BMKGeoCodeSearch searcher, BMKReverseGeoCodeResult result, BMKSearchErrorCode error);
    }

    // @interface BMKPoiDetailShareURLOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKPoiDetailShareURLOption
    {
        // @property (nonatomic, strong) NSString * uid;
        [Export("uid", ArgumentSemantic.Strong)]
        string Uid { get; set; }
    }

    // @interface BMKLocationShareURLOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKLocationShareURLOption
    {
        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSString * snippet;
        [Export("snippet", ArgumentSemantic.Strong)]
        string Snippet { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D location;
        [Export("location", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Location { get; set; }
    }

    // @interface BMKRoutePlanShareURLOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKRoutePlanShareURLOption
    {
        // @property (assign, nonatomic) BMKRoutePlanShareURLType routePlanType;
        [Export("routePlanType", ArgumentSemantic.Assign)]
        BMKRoutePlanShareURLType RoutePlanType { get; set; }

        // @property (nonatomic, strong) BMKPlanNode * from;
        [Export("from", ArgumentSemantic.Strong)]
        BMKPlanNode From { get; set; }

        // @property (nonatomic, strong) BMKPlanNode * to;
        [Export("to", ArgumentSemantic.Strong)]
        BMKPlanNode To { get; set; }

        // @property (assign, nonatomic) NSUInteger cityID;
        [Export("cityID")]
        nuint CityID { get; set; }

        // @property (assign, nonatomic) NSUInteger routeIndex;
        [Export("routeIndex")]
        nuint RouteIndex { get; set; }
    }

    // @interface BMKShareURLResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKShareURLResult
    {
        // @property (nonatomic, strong) NSString * url;
        [Export("url", ArgumentSemantic.Strong)]
        string Url { get; set; }
    }

    // @interface BMKShareURLSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKShareURLSearch
    {
        [Wrap("WeakDelegate")]
        BMKShareURLSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKShareURLSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)requestPoiDetailShareURL:(BMKPoiDetailShareURLOption *)poiDetailShareUrlSearchOption;
        [Export("requestPoiDetailShareURL:")]
        bool RequestPoiDetailShareURL(BMKPoiDetailShareURLOption poiDetailShareUrlSearchOption);

        // -(BOOL)requestLocationShareURL:(BMKLocationShareURLOption *)reverseGeoShareUrlSearchOption;
        [Export("requestLocationShareURL:")]
        bool RequestLocationShareURL(BMKLocationShareURLOption reverseGeoShareUrlSearchOption);

        // -(BOOL)requestRoutePlanShareURL:(BMKRoutePlanShareURLOption *)routePlanShareUrlSearchOption;
        [Export("requestRoutePlanShareURL:")]
        bool RequestRoutePlanShareURL(BMKRoutePlanShareURLOption routePlanShareUrlSearchOption);
    }

    // @protocol BMKShareURLSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKShareURLSearchDelegate
    {
        // @optional -(void)onGetPoiDetailShareURLResult:(BMKShareURLSearch *)searcher result:(BMKShareURLResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetPoiDetailShareURLResult:result:errorCode:")]
        void OnGetPoiDetailShareURLResult(BMKShareURLSearch searcher, BMKShareURLResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetLocationShareURLResult:(BMKShareURLSearch *)searcher result:(BMKShareURLResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetLocationShareURLResult:result:errorCode:")]
        void OnGetLocationShareURLResult(BMKShareURLSearch searcher, BMKShareURLResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetRoutePlanShareURLResult:(BMKShareURLSearch *)searcher result:(BMKShareURLResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetRoutePlanShareURLResult:result:errorCode:")]
        void OnGetRoutePlanShareURLResult(BMKShareURLSearch searcher, BMKShareURLResult result, BMKSearchErrorCode error);
    }

    // @interface BMKSuggestionSearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKSuggestionSearchOption
    {
        // @property (nonatomic, strong) NSString * keyword;
        [Export("keyword", ArgumentSemantic.Strong)]
        string Keyword { get; set; }

        // @property (nonatomic, strong) NSString * cityname;
        [Export("cityname", ArgumentSemantic.Strong)]
        string Cityname { get; set; }

        // @property (nonatomic, assign) BOOL cityLimit;
        [Export("cityLimit", ArgumentSemantic.Assign)]
        bool CityLimit { get; set; }
    }

    // @interface BMKSuggestionResult : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKSuggestionResult
    {
        // @property (nonatomic, strong) NSArray * keyList;
        [Export("keyList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        string[] KeyList { get; set; }

        // @property (nonatomic, strong) NSArray * cityList;
        [Export("cityList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        string[] CityList { get; set; }

        // @property (nonatomic, strong) NSArray * districtList;
        [Export("districtList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        string[] DistrictList { get; set; }

        // @property (nonatomic, strong) NSArray * poiIdList;
        [Export("poiIdList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        string[] PoiIdList { get; set; }

        // @property (nonatomic, strong) NSArray * ptList;
        [Export("ptList", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] PtList { get; set; }
    }

    // @interface BMKSuggestionSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKSuggestionSearch
    {
        [Wrap("WeakDelegate")]
        BMKSuggestionSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKSuggestionSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)suggestionSearch:(BMKSuggestionSearchOption *)suggestionSearchOption;
        [Export("suggestionSearch:")]
        bool SuggestionSearch(BMKSuggestionSearchOption suggestionSearchOption);
    }

    // @protocol BMKSuggestionSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKSuggestionSearchDelegate
    {
        // @optional -(void)onGetSuggestionResult:(BMKSuggestionSearch *)searcher result:(BMKSuggestionResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetSuggestionResult:result:errorCode:")]
        void Result(BMKSuggestionSearch searcher, BMKSuggestionResult result, BMKSearchErrorCode error);
    }

    // @interface BMKBusLineSearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKBusLineSearchOption
    {
        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic, strong) NSString * busLineUid;
        [Export("busLineUid", ArgumentSemantic.Strong)]
        string BusLineUid { get; set; }
    }

    // @interface BMKBusLineSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKBusLineSearch
    {
        [Wrap("WeakDelegate")]
        BMKBusLineSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKBusLineSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)busLineSearch:(BMKBusLineSearchOption *)busLineSearchOption;
        [Export("busLineSearch:")]
        bool BusLineSearch(BMKBusLineSearchOption busLineSearchOption);
    }

    // @protocol BMKBusLineSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKBusLineSearchDelegate
    {
        // @optional -(void)onGetBusDetailResult:(BMKBusLineSearch *)searcher result:(BMKBusLineResult *)busLineResult errorCode:(BMKSearchErrorCode)error;
        [Export("onGetBusDetailResult:result:errorCode:")]
        void Result(BMKBusLineSearch searcher, BMKBusLineResult busLineResult, BMKSearchErrorCode error);
    }

    // @interface BMKBaseRoutePlanOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKBaseRoutePlanOption
    {
        // @property (nonatomic, strong) BMKPlanNode * from;
        [Export("from", ArgumentSemantic.Strong)]
        BMKPlanNode From { get; set; }

        // @property (nonatomic, strong) BMKPlanNode * to;
        [Export("to", ArgumentSemantic.Strong)]
        BMKPlanNode To { get; set; }
    }

    // @interface BMKWalkingRoutePlanOption : BMKBaseRoutePlanOption
    [BaseType(typeof(BMKBaseRoutePlanOption))]
    interface BMKWalkingRoutePlanOption
    {
    }

    // @interface BMKDrivingRoutePlanOption : BMKBaseRoutePlanOption
    [BaseType(typeof(BMKBaseRoutePlanOption))]
    interface BMKDrivingRoutePlanOption
    {
        // @property (nonatomic, strong) NSArray * wayPointsArray;
        [Export("wayPointsArray", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] WayPointsArray { get; set; }

        // @property (nonatomic) BMKDrivingPolicy drivingPolicy;
        [Export("drivingPolicy", ArgumentSemantic.Assign)]
        BMKDrivingPolicy DrivingPolicy { get; set; }

        // @property (nonatomic) BMKDrivingRequestTrafficType drivingRequestTrafficType;
        [Export("drivingRequestTrafficType", ArgumentSemantic.Assign)]
        BMKDrivingRequestTrafficType DrivingRequestTrafficType { get; set; }
    }

    // @interface BMKTransitRoutePlanOption : BMKBaseRoutePlanOption
    [BaseType(typeof(BMKBaseRoutePlanOption))]
    interface BMKTransitRoutePlanOption
    {
        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic) BMKTransitPolicy transitPolicy;
        [Export("transitPolicy", ArgumentSemantic.Assign)]
        BMKTransitPolicy TransitPolicy { get; set; }
    }

    // @interface BMKMassTransitRoutePlanOption : BMKBaseRoutePlanOption
    [BaseType(typeof(BMKBaseRoutePlanOption))]
    interface BMKMassTransitRoutePlanOption
    {
        // @property (assign, nonatomic) NSUInteger pageIndex;
        [Export("pageIndex")]
        nuint PageIndex { get; set; }

        // @property (assign, nonatomic) NSUInteger pageCapacity;
        [Export("pageCapacity")]
        nuint PageCapacity { get; set; }

        // @property (assign, nonatomic) BMKMassTransitIncityPolicy incityPolicy;
        [Export("incityPolicy", ArgumentSemantic.Assign)]
        BMKMassTransitIncityPolicy IncityPolicy { get; set; }

        // @property (assign, nonatomic) BMKMassTransitIntercityPolicy intercityPolicy;
        [Export("intercityPolicy", ArgumentSemantic.Assign)]
        BMKMassTransitIntercityPolicy IntercityPolicy { get; set; }

        // @property (assign, nonatomic) BMKMassTransitIntercityTransPolicy intercityTransPolicy;
        [Export("intercityTransPolicy", ArgumentSemantic.Assign)]
        BMKMassTransitIntercityTransPolicy IntercityTransPolicy { get; set; }
    }

    // @interface BMKRidingRoutePlanOption : BMKBaseRoutePlanOption
    [BaseType(typeof(BMKBaseRoutePlanOption))]
    interface BMKRidingRoutePlanOption
    {
    }

    // @interface BMKIndoorRoutePlanOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKIndoorRoutePlanOption
    {
        // @property (nonatomic, strong) BMKIndoorPlanNode * from;
        [Export("from", ArgumentSemantic.Strong)]
        BMKIndoorPlanNode From { get; set; }

        // @property (nonatomic, strong) BMKIndoorPlanNode * to;
        [Export("to", ArgumentSemantic.Strong)]
        BMKIndoorPlanNode To { get; set; }
    }

    // @interface BMKRouteSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKRouteSearch
    {
        [Wrap("WeakDelegate")]
        BMKRouteSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKRouteSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)transitSearch:(BMKTransitRoutePlanOption *)transitRoutePlanOption;
        [Export("transitSearch:")]
        bool TransitSearch(BMKTransitRoutePlanOption transitRoutePlanOption);

        // -(BOOL)massTransitSearch:(BMKMassTransitRoutePlanOption *)routePlanOption;
        [Export("massTransitSearch:")]
        bool MassTransitSearch(BMKMassTransitRoutePlanOption routePlanOption);

        // -(BOOL)drivingSearch:(BMKDrivingRoutePlanOption *)drivingRoutePlanOption;
        [Export("drivingSearch:")]
        bool DrivingSearch(BMKDrivingRoutePlanOption drivingRoutePlanOption);

        // -(BOOL)walkingSearch:(BMKWalkingRoutePlanOption *)walkingRoutePlanOption;
        [Export("walkingSearch:")]
        bool WalkingSearch(BMKWalkingRoutePlanOption walkingRoutePlanOption);

        // -(BOOL)ridingSearch:(BMKRidingRoutePlanOption *)ridingRoutePlanOption;
        [Export("ridingSearch:")]
        bool RidingSearch(BMKRidingRoutePlanOption ridingRoutePlanOption);

        // -(BOOL)indoorRoutePlanSearch:(BMKIndoorRoutePlanOption *)indoorRoutePlanOption;
        [Export("indoorRoutePlanSearch:")]
        bool IndoorRoutePlanSearch(BMKIndoorRoutePlanOption indoorRoutePlanOption);
    }

    // @protocol BMKRouteSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKRouteSearchDelegate
    {
        // @optional -(void)onGetTransitRouteResult:(BMKRouteSearch *)searcher result:(BMKTransitRouteResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetTransitRouteResult:result:errorCode:")]
        void OnGetTransitRouteResult(BMKRouteSearch searcher, BMKTransitRouteResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetMassTransitRouteResult:(BMKRouteSearch *)searcher result:(BMKMassTransitRouteResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetMassTransitRouteResult:result:errorCode:")]
        void OnGetMassTransitRouteResult(BMKRouteSearch searcher, BMKMassTransitRouteResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetDrivingRouteResult:(BMKRouteSearch *)searcher result:(BMKDrivingRouteResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetDrivingRouteResult:result:errorCode:")]
        void OnGetDrivingRouteResult(BMKRouteSearch searcher, BMKDrivingRouteResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetWalkingRouteResult:(BMKRouteSearch *)searcher result:(BMKWalkingRouteResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetWalkingRouteResult:result:errorCode:")]
        void OnGetWalkingRouteResult(BMKRouteSearch searcher, BMKWalkingRouteResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetRidingRouteResult:(BMKRouteSearch *)searcher result:(BMKRidingRouteResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetRidingRouteResult:result:errorCode:")]
        void OnGetRidingRouteResult(BMKRouteSearch searcher, BMKRidingRouteResult result, BMKSearchErrorCode error);

        // @optional -(void)onGetIndoorRouteResult:(BMKRouteSearch *)searcher result:(BMKIndoorRouteResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetIndoorRouteResult:result:errorCode:")]
        void OnGetIndoorRouteResult(BMKRouteSearch searcher, BMKIndoorRouteResult result, BMKSearchErrorCode error);
    }

    // @interface BMKDistrictSearchOption : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKDistrictSearchOption
    {
        // @property (nonatomic, strong) NSString * city;
        [Export("city", ArgumentSemantic.Strong)]
        string City { get; set; }

        // @property (nonatomic, strong) NSString * district;
        [Export("district", ArgumentSemantic.Strong)]
        string District { get; set; }
    }

    // @interface BMKDistrictResult : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKDistrictResult
    {
        // @property (assign, nonatomic) NSInteger code;
        [Export("code")]
        nint Code { get; set; }

        // @property (nonatomic, strong) NSString * name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (assign, nonatomic) CLLocationCoordinate2D center;
        [Export("center", ArgumentSemantic.Assign)]
        CLLocationCoordinate2D Center { get; set; }

        // @property (nonatomic, strong) NSArray * paths;
        [Export("paths", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        string[] Paths { get; set; }
    }

    // @interface BMKDistrictSearch : BMKSearchBase
    [BaseType(typeof(BMKSearchBase))]
    interface BMKDistrictSearch
    {
        [Wrap("WeakDelegate")]
        BMKDistrictSearchDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKDistrictSearchDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)districtSearch:(BMKDistrictSearchOption *)districtSearchOption;
        [Export("districtSearch:")]
        bool DistrictSearch(BMKDistrictSearchOption districtSearchOption);
    }

    // @protocol BMKDistrictSearchDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKDistrictSearchDelegate
    {
        // @optional -(void)onGetDistrictResult:(BMKDistrictSearch *)searcher result:(BMKDistrictResult *)result errorCode:(BMKSearchErrorCode)error;
        [Export("onGetDistrictResult:result:errorCode:")]
        void Result(BMKDistrictSearch searcher, BMKDistrictResult result, BMKSearchErrorCode error);
    }

}
