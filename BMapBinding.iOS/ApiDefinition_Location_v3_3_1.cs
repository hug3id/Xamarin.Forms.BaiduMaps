using System;

namespace BMapBinding
{
    using Foundation;
    using ObjCRuntime;

    // @protocol BMKLocationServiceDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface BMKLocationServiceDelegate
    {
        // @optional -(void)willStartLocatingUser;
        [Export("willStartLocatingUser")]
        void WillStartLocatingUser();

        // @optional -(void)didStopLocatingUser;
        [Export("didStopLocatingUser")]
        void DidStopLocatingUser();

        // @optional -(void)didUpdateUserHeading:(id)userLocation;
        [Export("didUpdateUserHeading:")]
        void DidUpdateUserHeading(BMKUserLocation userLocation);

        // @optional -(void)didUpdateBMKUserLocation:(id)userLocation;
        [Export("didUpdateBMKUserLocation:")]
        void DidUpdateBMKUserLocation(BMKUserLocation userLocation);

        // @optional -(void)didFailToLocateUserWithError:(NSError *)error;
        [Export("didFailToLocateUserWithError:")]
        void DidFailToLocateUserWithError(NSError error);
    }

    // @interface BMKLocationService : NSObject
    [BaseType(typeof(NSObject))]
    interface BMKLocationService
    {
        // @property (readonly, nonatomic) BMKUserLocation * userLocation;
        [Export("userLocation")]
        BMKUserLocation UserLocation { get; }

        [Wrap("WeakDelegate")]
        BMKLocationServiceDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<BMKLocationServiceDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(void)startUserLocationService;
        [Export("startUserLocationService")]
        void StartUserLocationService();

        // -(void)stopUserLocationService;
        [Export("stopUserLocationService")]
        void StopUserLocationService();

        // @property (assign, nonatomic) CLLocationDistance distanceFilter;
        [Export("distanceFilter")]
        double DistanceFilter { get; set; }

        // @property (assign, nonatomic) CLLocationAccuracy desiredAccuracy;
        [Export("desiredAccuracy")]
        double DesiredAccuracy { get; set; }

        // @property (assign, nonatomic) CLLocationDegrees headingFilter;
        [Export("headingFilter")]
        double HeadingFilter { get; set; }

        // @property (assign, nonatomic) BOOL pausesLocationUpdatesAutomatically;
        [Export("pausesLocationUpdatesAutomatically")]
        bool PausesLocationUpdatesAutomatically { get; set; }

        // @property (assign, nonatomic) BOOL allowsBackgroundLocationUpdates;
        [Export("allowsBackgroundLocationUpdates")]
        bool AllowsBackgroundLocationUpdates { get; set; }

        // +(void)setLocationDistanceFilter:(id)distanceFilter __attribute__((deprecated("废弃方法（空实现），使用distanceFilter属性替换")));
        //[Static]
        //[Export("setLocationDistanceFilter:")]
        //void SetLocationDistanceFilter(NSObject distanceFilter);

        // +(id)getCurrentLocationDistanceFilter __attribute__((deprecated("废弃方法（空实现），使用distanceFilter属性替换")));
        //[Static]
        //[Export("getCurrentLocationDistanceFilter")]
        //[Verify(MethodToProperty)]
        //NSObject CurrentLocationDistanceFilter { get; }

        // +(void)setLocationDesiredAccuracy:(id)desiredAccuracy __attribute__((deprecated("废弃方法（空实现），使用desiredAccuracy属性替换")));
        //[Static]
        //[Export("setLocationDesiredAccuracy:")]
        //void SetLocationDesiredAccuracy(NSObject desiredAccuracy);

        // +(id)getCurrentLocationDesiredAccuracy __attribute__((deprecated("废弃方法（空实现），使用desiredAccuracy属性替换")));
        //[Static]
        //[Export("getCurrentLocationDesiredAccuracy")]
        //[Verify(MethodToProperty)]
        //NSObject CurrentLocationDesiredAccuracy { get; }
    }
}
