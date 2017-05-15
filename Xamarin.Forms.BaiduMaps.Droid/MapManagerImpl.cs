using System;
using Com.Baidu.Mapapi;

namespace Xamarin.Forms.BaiduMaps.Droid
{
    public class MapManagerImpl : IMapManager
    {
        public CoordType CoordinateType
        {
            get
            {
                var type = SDKInitializer.CoordType;
                if (Com.Baidu.Mapapi.CoordType.Gcj02 == type) {
                    return CoordType.GCJ02;
                }

                return CoordType.BD09LL;
            }

            set {
                if (CoordType.GCJ02 == value) {
                    SDKInitializer.CoordType = Com.Baidu.Mapapi.CoordType.Gcj02;
                }
                else {
                    SDKInitializer.CoordType = Com.Baidu.Mapapi.CoordType.Bd09ll;
                }
            }
        }
    }
}
