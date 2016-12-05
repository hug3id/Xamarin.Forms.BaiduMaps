using System.Diagnostics;
using BMapBinding;

namespace Xamarin
{
    public static class FormsBaiduMaps
    {
        public static void Init(string APIKey)
        {
            BMKMapManager mgr = new BMKMapManager();
            mgr.Start(APIKey, new GeneralDelegate());
        }
    }

    class GeneralDelegate : BMKGeneralDelegate
    {
        public override void OnGetNetworkState(int iError)
        {
            Debug.WriteLine("OnGetNetworkState: " + iError);
        }

        public override void OnGetPermissionState(int iError)
        {
            Debug.WriteLine("OnGetPermissionState: " + iError);
        }
    }
}

