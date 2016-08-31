# Xamarin.Forms.BaiduMaps
A simply packaging for baidu maps sdk(android v4.0/ios v3.0)

iOS Project configuration:
###
        1. Right click project, enter Options->iOS Build
        1.1 Linker behavior choose 'LinkALL'
        1.2 Additional mtouch arguments:
        -gcc_flags "-L${ProjectDir}  -framework MapKit -framework CoreMotion -framework CoreGraphics -framework QuartzCore -framework CoreText -framework CoreLocation -framework SystemConfiguration -lz -lstdc++.6.0.9 -lz -lsqlite3.0 -framework CoreTelephony -framework OpenGLES -framework Foundation -framework Security -ObjC"

        2. Open Info.plist
        2.1 Bundle identifier must accord with your baidu key
        2.2 Add items:
        <key>NSApptransportSecurity</key>
        <dict>
            <key>NSAllowsArbitraryLoads</key>
            <true />
        </dict>
        2.3 Add NSLocationWhenInUseUsageDescription or NSLocationAlwaysUsageDescription
        3. Add whole mapapi.bundle to project
        4. Open AppDelegate.cs, add init code before LoadApplication:
        Xamarin.FormsBaiduMaps.Init(“your baidu ios key”);

Android Project configuration:
###
        1. Open MainActiveity.cs，add init code before LoadApplication: Xamarin.FormsBaiduMaps.Init(null);
        2. Open Properties/AndroidManifest.xml, add permissions and your baidukey, also package must accord with your baidu key
