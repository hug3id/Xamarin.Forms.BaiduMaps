using System;
using BMapBinding;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public class MapManagerImpl : IMapManager
    {
        public CoordType CoordinateType
        {
            get
            {
                if (BMKCoordType.Common == BMKMapManager.CoordinateTypeUsedInBaiduMapSDK) {
                    return CoordType.GCJ02;
                }

                return CoordType.BD09LL;
            }

            set {
                if (CoordType.GCJ02 == value) {
                    BMKMapManager.SetCoordinateTypeUsedInBaiduMapSDK(BMKCoordType.Common);
                }
                else {
                    BMKMapManager.SetCoordinateTypeUsedInBaiduMapSDK(BMKCoordType.BD09LL);
                }
            }
        }
    }
}
