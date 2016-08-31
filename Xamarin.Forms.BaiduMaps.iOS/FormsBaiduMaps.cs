using BMapBase;
using Xamarin.Forms;
using Xamarin.Forms.BaiduMaps;
using Xamarin.Forms.BaiduMaps.iOS;

namespace Xamarin
{
    public static class FormsBaiduMaps
    {
        public static void Init(string APIKey)
        {
            BMKMapManager mgr = new BMKMapManager();
            mgr.Start(APIKey, new BMKGeneralDelegate());
        }
    }
}

