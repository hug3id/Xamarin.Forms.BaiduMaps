using Android.App;
using Com.Baidu.Mapapi;

namespace Xamarin
{
    public static class FormsBaiduMaps
    {
        public static void Init(string APIKey)
        {
            SDKInitializer.Initialize(Application.Context);
        }
    }
}
