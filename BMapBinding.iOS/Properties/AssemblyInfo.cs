using System.Reflection;
using System.Runtime.CompilerServices;

using Foundation;
using ObjCRuntime;

// This attribute allows you to mark your assemblies as “safe to link”. 
// When the attribute is present, the linker—if enabled—will process the assembly 
// even if you’re using the “Link SDK assemblies only” option, which is the default for device builds.

[assembly: LinkerSafe]

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("BMapBinding.iOS")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Booway")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Copyleft _hug3id 2016.12")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.*")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly: LinkWith("BaiduMapAPI_Base_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    Frameworks = "CoreTelephony SystemConfiguration",
    LinkerFlags = "-ObjC -lsqlite3.0",
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("BaiduMapAPI_Utils_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    LinkerFlags = "-ObjC",
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("BaiduMapAPI_Map_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    Frameworks = "Security OpenGLES QuartzCore",
    LinkerFlags = "-ObjC -lstdc++.6.0.9",
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("BaiduMapAPI_Location_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    Frameworks = "CoreLocation",
    LinkerFlags = "-ObjC",
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("BaiduMapAPI_Search_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    LinkerFlags = "-ObjC",
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("BaiduMapAPI_Radar_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    LinkerFlags = "-ObjC",
    SmartLink = true,
    ForceLoad = true)]

[assembly: LinkWith("BaiduMapAPI_Cloud_v3_3_1",
    LinkTarget.ArmV7 | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64,
    LinkerFlags = "-ObjC",
    SmartLink = true,
    ForceLoad = true)]
