# Xamarin.Forms.BaiduMaps
A simply packaging for baidu maps sdk(android v4.0/ios v3.0)

**************************************************
iOS Project configuration:
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

***********************************************
Android Project configuration:
1. Open MainActiveity.cs，add init code before LoadApplication: 
Xamarin.FormsBaiduMaps.Init(null);

2. Open Properties/AndroidManifest.xml
2.1 package must accord with your baidu key
2.2 Add items:
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="com.android.launcher.permission.READ_SETTINGS" />
<uses-permission android:name="android.permission.WAKE_LOCK" />
<uses-permission android:name="android.permission.CHANGE_WIFI_STATE" />
<uses-permission android:name="android.permission.ACCESS_COARSE_LOCATION"></uses-permission>
<uses-permission android:name="android.permission.ACCESS_FINE_LOCATION"></uses-permission>
<uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />
<uses-permission android:name="android.permission.READ_PHONE_STATE"></uses-permission>
<uses-permission android:name="android.permission.GET_TASKS" />
<!-- For offline map -->
<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
<uses-permission android:name="android.permission.MOUNT_UNMOUNT_FILESYSTEMS"></uses-permission>
<uses-permission android:name="android.permission.WRITE_SETTINGS" />
<uses-permission android:name="android.permission.CLEAR_APP_CACHE" />
<uses-permission android:name="android.permission.CLEAR_APP_USER_DATA" />
<uses-permission android:name="android.permission.DELETE_CACHE_FILES" />
<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
<uses-permission android:name="android.permission.WRITE_USER_DICTIONARY" />
<uses-permission android:name="android.permission.CHANGE_NETWORK_STATE" />
<uses-permission android:name="android.permission.CHANGE_WIFI_MULTICAST_STATE" />
<uses-permission android:name="android.permission.LOCATION_HARDWARE" />
<uses-permission android:name="android.permission.MEDIA_CONTENT_CONTROL" />
<uses-permission android:name="android.permission.CAMERA" />
<uses-permission android:name="android.permission.READ_LOGS" />
<application android:label="Sample">
    <service android:name="com.baidu.location.f" android:enabled="true" android:process=":remote"></service>
    <meta-data android:name="com.baidu.lbsapi.API_KEY" android:value="your baidu android key" />
</application>
