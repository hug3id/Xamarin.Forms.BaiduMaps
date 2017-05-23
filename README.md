# Xamarin.Forms.BaiduMaps
A simply packaging of baidu maps sdk(update to android v4.3.1/ios v3.3.1)


# 1.3.1
 
* Update baidu sdk to v4.3.1(android) and v3.3.1(ios)
* Add IMapManager interface to support GCJ-02

# 1.3

* Update baidu sdk to v4.2.1(android) and v3.2.1(ios)

# 1.2.2

## New Features

* Replace MapStateChanged to MapStateChangedFinish (Android)

## Bug fix

* Fix crash problem (Android)
* ZoomLevel setting conflict with map moving (iOS)

# 1.2.1

## Bug fix

* Fix crash problem (iOS)

# 1.2

* Update baidu sdk to v4.1.1(android) and v3.1(ios)
* Update Xamarin.Forms to v2.3.2.127

# 1.1.2

## New Features

* Support change Pin.Image(Android)

# 1.1.1

## Bug fix

* Pin.Title now can be null (iOS)
* ILocationService callback satellites always -1 (Android)

# 1.1.0

## New Features

* Add Polygon support
* Add Circle support
* Add ICalculateUtils interface
* Add IProjection interface

iOS Project configuration:
###
        1. Open Info.plist
        1.1 Bundle identifier must accord with your baidu key
        1.2 Add NSLocationWhenInUseUsageDescription or NSLocationAlwaysUsageDescription
        
        2. Add whole mapapi.bundle(in the baidu ios sdk) to project
        
        3. Open AppDelegate.cs, add init code before LoadApplication:  
           Xamarin.FormsBaiduMaps.Init(“your baidu ios key”);

        Extra configuation below version v1.3:
###
        1. Right click project, enter Options->iOS Build->Additional mtouch arguments:  
        -gcc_flags "-L${ProjectDir} -framework MapKit -framework CoreMotion -framework CoreGraphics
        -framework QuartzCore -framework CoreText -framework CoreLocation -framework SystemConfiguration  
        -framework CoreTelephony -framework OpenGLES -framework Foundation -framework Security  
        -lz -lstdc++.6.0.9 -lsqlite3.0 -ObjC"

        2. Open Info.plist and add items:
        <key>NSAppTransportSecurity</key>
        <dict>
            <key>NSAllowsArbitraryLoads</key>
            <true />
        </dict>

Android Project configuration:
###
        1. Open MainActiveity.cs，add init code before LoadApplication:  
           Xamarin.FormsBaiduMaps.Init(null);
        2. Open Properties/AndroidManifest.xml, add permissions and your baidukey,  
           also package must accord with your baidu key
