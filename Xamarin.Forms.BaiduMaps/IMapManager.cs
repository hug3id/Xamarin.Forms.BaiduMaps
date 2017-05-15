using System;

namespace Xamarin.Forms.BaiduMaps
{
    public enum CoordType
    {
    	BD09LL,
    	GCJ02
    }

    public interface IMapManager
    {
        CoordType CoordinateType { get; set; }
    }
}
