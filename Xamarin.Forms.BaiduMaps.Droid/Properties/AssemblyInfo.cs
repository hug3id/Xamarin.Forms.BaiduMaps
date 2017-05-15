using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Internals;

using Xamarin.Forms.BaiduMaps;
using Xamarin.Forms.BaiduMaps.Droid;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Xamarin.Forms.BaiduMaps.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Booway")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Copyleft _hug3id 2016.9")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.0.0")]

// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly: ExportRenderer(typeof(Map), typeof(MapRenderer))]
[assembly: Dependency(typeof(OfflineMapImpl))]
[assembly: Dependency(typeof(CalculateUtilsImpl))]
[assembly: Dependency(typeof(MapManagerImpl))]
[assembly: Preserve]

