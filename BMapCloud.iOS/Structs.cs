using System;

using System.Runtime.InteropServices;
using Foundation;

namespace BMapCloud
{
	/*static class CFunctions
	{
		// extern NSString * BMKGetMapApiCloudComponentVersion () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern NSString BMKGetMapApiCloudComponentVersion ();

		// extern BOOL BMKCheckCloudComponentIsLegal () __attribute__((visibility("default")));
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern bool BMKCheckCloudComponentIsLegal ();
	}*/

	public enum BMKCloudSearchType : uint
	{
		NoneSearch = 0,
		CloudLocalSearch = 1,
		CloudNearbySearch = 2,
		CloudBoundSearch = 3,
		CloudDetailSearch = 4
	}

	public enum BMKCloudErrorCode
	{
		NetwokrError = -3,
		NetwokrTimeout = -2,
		ResultNotFound = -1,
		NoError = 0
	}
}
