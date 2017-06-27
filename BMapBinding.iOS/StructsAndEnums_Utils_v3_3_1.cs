using System;

using System.Runtime.InteropServices;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace BMapBinding
{
    public enum BMKNaviType : uint
    {
        Native = 0,
        Web
    }

    public enum BMKOpenTransitPolicy : uint
    {
        Recommand = 3,
        TransferFirst,
        WalkFirst,
        NoSubway,
        TimeFirst
    }

    public static partial class CFunctions
    {
        // NSString * BMKGetMapApiVersion ();
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static string BMKGetMapApiVersion()
        {
            return "3.3.1";
        }

        // BMKCoordinateSpan BMKCoordinateSpanMake (CLLocationDegrees latitudeDelta, CLLocationDegrees longitudeDelta);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern BMKCoordinateSpan BMKCoordinateSpanMake (double latitudeDelta, double longitudeDelta);
        public static BMKCoordinateSpan BMKCoordinateSpanMake(double latitudeDelta, double longitudeDelta)
        {
            return new BMKCoordinateSpan { latitudeDelta = latitudeDelta, longitudeDelta = longitudeDelta };
        }

        // BMKCoordinateRegion BMKCoordinateRegionMake (CLLocationCoordinate2D centerCoordinate, BMKCoordinateSpan span);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern BMKCoordinateRegion BMKCoordinateRegionMake (CLLocationCoordinate2D centerCoordinate, BMKCoordinateSpan span);
        public static BMKCoordinateRegion BMKCoordinateRegionMake (CLLocationCoordinate2D centerCoordinate, BMKCoordinateSpan span)
        {
            return new BMKCoordinateRegion { center = centerCoordinate, span = span };
        }

        // extern BMKCoordinateRegion BMKCoordinateRegionMakeWithDistance (CLLocationCoordinate2D centerCoordinate, CLLocationDistance latitudinalMeters, CLLocationDistance longitudinalMeters) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKCoordinateRegion BMKCoordinateRegionMakeWithDistance (CLLocationCoordinate2D centerCoordinate, double latitudinalMeters, double longitudinalMeters);

        // extern BMKMapPoint BMKMapPointForCoordinate (CLLocationCoordinate2D coordinate) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKMapPoint BMKMapPointForCoordinate (CLLocationCoordinate2D coordinate);

        // extern CLLocationCoordinate2D BMKCoordinateForMapPoint (BMKMapPoint mapPoint) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern CLLocationCoordinate2D BMKCoordinateForMapPoint (BMKMapPoint mapPoint);

        // extern CLLocationDistance BMKMetersPerMapPointAtLatitude (CLLocationDegrees latitude) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern double BMKMetersPerMapPointAtLatitude (double latitude);

        // extern double BMKMapPointsPerMeterAtLatitude (CLLocationDegrees latitude) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern double BMKMapPointsPerMeterAtLatitude (double latitude);

        // extern double BMKMetersBetweenMapPoints (BMKMapPoint a, BMKMapPoint b) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern double BMKMetersBetweenMapPoints (BMKMapPoint a, BMKMapPoint b);

        // int BMKMapPointMake (double x, double y);
        // BMKMapPoint BMKMapPointMake (double x, double y);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern BMKMapPoint BMKMapPointMake (double x, double y);
        public static BMKMapPoint BMKMapPointMake (double x, double y)
        {
            return new BMKMapPoint { x = x, y = y };
        }

        // BMKMapSize BMKMapSizeMake (double width, double height);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern BMKMapSize BMKMapSizeMake (double width, double height);
        public static BMKMapSize BMKMapSizeMake (double width, double height)
        {
            return new BMKMapSize { width = width, height = height };
        }

        // BMKMapRect BMKMapRectMake (double x, double y, double width, double height);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern BMKMapRect BMKMapRectMake (double x, double y, double width, double height);
        public static BMKMapRect BMKMapRectMake (double x, double y, double width, double height)
        {

            return new BMKMapRect { origin = BMKMapPointMake(x, y), size = BMKMapSizeMake(width, height) };
        }

        // double BMKMapRectGetMinX (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetMinX (BMKMapRect rect);
        public static double BMKMapRectGetMinX (BMKMapRect rect)
        {
            return rect.origin.x;
        }

        // double BMKMapRectGetMinY (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetMinY (BMKMapRect rect);
        public static double BMKMapRectGetMinY (BMKMapRect rect)
        {
            return rect.origin.y;
        }

        // double BMKMapRectGetMidX (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetMidX (BMKMapRect rect);
        public static double BMKMapRectGetMidX (BMKMapRect rect)
        {
            return rect.origin.x + rect.size.width / 2.0;
        }

        // double BMKMapRectGetMidY (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetMidY (BMKMapRect rect);
        public static double BMKMapRectGetMidY (BMKMapRect rect)
        {
            return rect.origin.y + rect.size.height / 2.0;
        }

        // double BMKMapRectGetMaxX (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetMaxX (BMKMapRect rect);
        public static double BMKMapRectGetMaxX (BMKMapRect rect)
        {
            return rect.origin.x + rect.size.width;
        }

        // double BMKMapRectGetMaxY (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetMaxY (BMKMapRect rect);
        public static double BMKMapRectGetMaxY (BMKMapRect rect)
        {
            return rect.origin.y + rect.size.height;
        }

        // double BMKMapRectGetWidth (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetWidth (BMKMapRect rect);
        public static double BMKMapRectGetWidth (BMKMapRect rect)
        {
            return rect.size.width;
        }

        // double BMKMapRectGetHeight (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern double BMKMapRectGetHeight (BMKMapRect rect);
        public static double BMKMapRectGetHeight (BMKMapRect rect)
        {
            return rect.size.height;
        }

        // BOOL BMKMapPointEqualToPoint (BMKMapPoint point1, BMKMapPoint point2);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern bool BMKMapPointEqualToPoint (BMKMapPoint point1, BMKMapPoint point2);
        public static bool BMKMapPointEqualToPoint (BMKMapPoint point1, BMKMapPoint point2)
        {
            return point1.x == point2.x && point1.y == point2.y;
        }

        // BOOL BMKMapSizeEqualToSize (BMKMapSize size1, BMKMapSize size2);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern bool BMKMapSizeEqualToSize (BMKMapSize size1, BMKMapSize size2);
        public static bool BMKMapSizeEqualToSize (BMKMapSize size1, BMKMapSize size2)
        {
            return size1.width == size2.width && size1.height == size2.height;
        }

        // BOOL BMKMapRectEqualToRect (BMKMapRect rect1, BMKMapRect rect2);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern bool BMKMapRectEqualToRect (BMKMapRect rect1, BMKMapRect rect2);
        public static bool BMKMapRectEqualToRect (BMKMapRect rect1, BMKMapRect rect2)
        {
            return BMKMapPointEqualToPoint(rect1.origin, rect2.origin)
                && BMKMapSizeEqualToSize(rect1.size, rect2.size);
        }

        // BOOL BMKMapRectIsNull (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern bool BMKMapRectIsNull (BMKMapRect rect);
        public static bool BMKMapRectIsNull (BMKMapRect rect)
        {
            // return isinf(rect.origin.x) || isinf(rect.origin.y);
            return double.IsInfinity(rect.origin.x) || double.IsInfinity(rect.origin.y);
        }

        // BOOL BMKMapRectIsEmpty (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern bool BMKMapRectIsEmpty (BMKMapRect rect);
        public static bool BMKMapRectIsEmpty (BMKMapRect rect)
        {
            return BMKMapRectIsNull(rect) || (0.0 == rect.size.width && 0.0 == rect.size.height);
        }

        // NSString * BMKStringFromMapPoint (BMKMapPoint point);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern NSString BMKStringFromMapPoint (BMKMapPoint point);
        public static string BMKStringFromMapPoint (BMKMapPoint point)
        {
            // "{%.1f, %.1f}"
            return $"{{point.x:f1, {point.y:f1}}}";
        }

        // NSString * BMKStringFromMapSize (BMKMapSize size);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern NSString BMKStringFromMapSize (BMKMapSize size);
        public static string BMKStringFromMapSize (BMKMapSize size)
        {
            // "{%.1f, %.1f}"
            return $"{{size.width:f1, {size.height:f1}}}";
        }

        // NSString * BMKStringFromMapRect (BMKMapRect rect);
        //[DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        //static extern NSString BMKStringFromMapRect (BMKMapRect rect);
        public static string BMKStringFromMapRect (BMKMapRect rect)
        {
            // "{%@, %@}"
            return $"{{{BMKStringFromMapPoint(rect.origin)}, {BMKStringFromMapSize(rect.size)}}}";
        }

        // extern BMKMapRect BMKMapRectUnion (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKMapRect BMKMapRectUnion (BMKMapRect rect1, BMKMapRect rect2);

        // extern BMKMapRect BMKMapRectIntersection (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKMapRect BMKMapRectIntersection (BMKMapRect rect1, BMKMapRect rect2);

        // extern BMKMapRect BMKMapRectInset (BMKMapRect rect, double dx, double dy) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKMapRect BMKMapRectInset (BMKMapRect rect, double dx, double dy);

        // extern BMKMapRect BMKMapRectOffset (BMKMapRect rect, double dx, double dy) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKMapRect BMKMapRectOffset (BMKMapRect rect, double dx, double dy);

        // extern void BMKMapRectDivide (BMKMapRect rect, BMKMapRect *slice, BMKMapRect *remainder, double amount, CGRectEdge edge) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern unsafe void BMKMapRectDivide (BMKMapRect rect, BMKMapRect* slice, BMKMapRect* remainder, double amount, CGRectEdge edge);

        // extern BOOL BMKMapRectContainsPoint (BMKMapRect rect, BMKMapPoint point) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKMapRectContainsPoint (BMKMapRect rect, BMKMapPoint point);

        // extern BOOL BMKMapRectContainsRect (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKMapRectContainsRect (BMKMapRect rect1, BMKMapRect rect2);

        // extern BOOL BMKMapRectIntersectsRect (BMKMapRect rect1, BMKMapRect rect2) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKMapRectIntersectsRect (BMKMapRect rect1, BMKMapRect rect2);

        // extern BMKCoordinateRegion BMKCoordinateRegionForMapRect (BMKMapRect rect) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern BMKCoordinateRegion BMKCoordinateRegionForMapRect (BMKMapRect rect);

        // extern BOOL BMKMapRectSpans180thMeridian (BMKMapRect rect) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKMapRectSpans180thMeridian (BMKMapRect rect);

        // extern int BMKMapRectRemainder (BMKMapRect rect) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern int BMKMapRectRemainder (BMKMapRect rect);

        // extern BOOL BMKCircleContainsPoint (BMKMapPoint point, BMKMapPoint center, double radius) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKCircleContainsPoint (BMKMapPoint point, BMKMapPoint center, double radius);

        // extern BOOL BMKCircleContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D center, double radius) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKCircleContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D center, double radius);

        // extern BOOL BMKPolygonContainsPoint (BMKMapPoint point, BMKMapPoint *polygon, NSUInteger count) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern unsafe bool BMKPolygonContainsPoint (BMKMapPoint point, BMKMapPoint* polygon, nuint count);

        // extern BOOL BMKPolygonContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D *polygon, NSUInteger count) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern unsafe bool BMKPolygonContainsCoordinate (CLLocationCoordinate2D point, CLLocationCoordinate2D* polygon, nuint count);

        // extern BMKMapPoint BMKGetNearestMapPointFromPolyline (BMKMapPoint point, BMKMapPoint *polyline, NSUInteger count) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern unsafe BMKMapPoint BMKGetNearestMapPointFromPolyline (BMKMapPoint point, BMKMapPoint* polyline, nuint count);

        // extern double BMKAreaBetweenCoordinates (CLLocationCoordinate2D leftTop, CLLocationCoordinate2D rightBottom) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern double BMKAreaBetweenCoordinates (CLLocationCoordinate2D leftTop, CLLocationCoordinate2D rightBottom);

        // extern NSDictionary * BMKConvertBaiduCoorFrom (CLLocationCoordinate2D coordinate, BMKCoordType type) __attribute__((visibility("default")));
        [DllImport ("__Internal", EntryPoint="BMKConvertBaiduCoorFrom")]
        //[Verify (PlatformInvoke)]
        public static extern IntPtr BMKConvertBaiduCoorFrom(CLLocationCoordinate2D coordinate, BMKCoordType type);
        public static NSDictionary BMKConvertBaiduCoorFrom2(CLLocationCoordinate2D coordinate, BMKCoordType type)
        {
            return Runtime.GetNSObject<NSDictionary>(BMKConvertBaiduCoorFrom(coordinate, type));
        }

        // extern CLLocationCoordinate2D BMKCoorDictionaryDecode (NSDictionary *dictionary) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern CLLocationCoordinate2D BMKCoorDictionaryDecode (IntPtr dictionary);

        // extern NSString * BMKGetMapApiUtilsComponentVersion () __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern NSString BMKGetMapApiUtilsComponentVersion ();

        // extern BOOL BMKCheckUtilsComponentIsLegal () __attribute__((visibility("default")));
        [DllImport ("__Internal")]
        //[Verify (PlatformInvoke)]
        public static extern bool BMKCheckUtilsComponentIsLegal ();
    }
}
